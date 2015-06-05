using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8_Tracks_Downloader
{
    public partial class Form1 : Form
    {
        List<CustomPanel> panels = new List<CustomPanel>();
        private const int maxHeight = 600;
        Downloader d;
        int uraTick = 0;
        private string Title
        {
            set
            {
                titleMsg.Text = value;
            }
        }
        private string formTitle
        {
            set
            {
                this.Text = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
            slave.RunWorkerCompleted += aziat_doneWorking;
            this.Height = 80 + formPanel.Height;
        }
        private void ButtonChange()
        {
            button2.Enabled = true;
            saveLocation.Enabled = true;
            createFolder.Enabled = true;
            Title = "Click the Download button now.";
        }
       
        //Next gumb
        private void button1_Click(object sender, EventArgs e)
        {
            showStatus("Trying to fetch mix id...");
            slave.RunWorkerAsync();
        }
        private void aziat_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    d = new Downloader(textBox1.Text);
                    d.ChgButton += ButtonChange;
                    d.OnTrackDone += AddSong;
                    saveLocation.Text = d.SaveLocation;
                    formPanel.Hide();
                    int x = downloaderPanel.Height - formPanel.Height + 5;
                    for (int i = x; i > 0; i--)
                    {
                        this.Height++;
                        Application.DoEvents();
                    }

                    formTitle = "8Tracks DLing: " + d.playlistTitle;
                    Title = "Preparing to download...";
                    downloaderPanel.Show();
                    d.loadSongs();
                    d.client.DownloadProgressChanged += updateProgressbar;
                    d.client.DownloadFileCompleted += downloadNextSong;
                    //tracks = d.playlist;
                }
                catch (Exception a)
                {
                    showError(a.Message);
                }
            }));
        }

        void aziat_doneWorking(object sender, RunWorkerCompletedEventArgs e)
        {
            statusPan.Hide();
        }
        private void AddSong(string name, string performer, int index)
        {
            //holder
            CustomPanel trackHolder = new CustomPanel(d.currentSong);        
            trackHolder.Size = new Size(257, 40);
            trackHolder.BackColor = Color.FromArgb(70, 170, 70);
            //Author
            Label AuthorLabel = new Label();
            AuthorLabel.AutoSize = true;
            AuthorLabel.Font = new Font("Dosis", 9F, System.Drawing.FontStyle.Bold);
            AuthorLabel.Text = "Author:";
            AuthorLabel.Location = new Point(14, 4);
            Label author = new Label();
            author.AutoSize = true;
            author.Text = performer;
            author.Location = new Point(60, 4);
            trackHolder.Controls.Add(AuthorLabel);
            trackHolder.Controls.Add(author);
            //title
            Label NameLabel = new Label();
            NameLabel.Text = "Title:";
            NameLabel.Font = new Font("Dosis", 9F, FontStyle.Bold);
            NameLabel.Location = new Point(14, 18);
            NameLabel.AutoSize = true;
            Label title = new Label();
            title.Text = name;
            title.AutoSize = true;
            title.Location = new Point(60, 18);
            trackHolder.Controls.Add(NameLabel);
            trackHolder.Controls.Add(title);
            tracksPanel.Controls.Add(trackHolder);
            trackHolder.Click += ChangeDownloadBool;
            AuthorLabel.Click += ChangeDownloadBool;
            NameLabel.Click += ChangeDownloadBool;
            author.Click += ChangeDownloadBool;
            title.Click += ChangeDownloadBool;
            Application.DoEvents();
        }

        void ChangeDownloadBool(object sender, EventArgs e)
        {
            CustomPanel p;
            if (sender is Label)
            {
                Label a = sender as Label;
                p = a.Parent as CustomPanel;
            }
            else
            {
                p = sender as CustomPanel;
            }
            if (d.playlist[p.i].download)
            {
                p.BackColor = Color.FromArgb(170, 70, 70);
                d.playlist[p.i].download = false;
            }
            else
            {
                p.BackColor = Color.FromArgb(70, 170, 70);
                d.playlist[p.i].download = true;
            }
        }
        
        private void showStatus(string message)
        {
            statusMsg.Text = message;
            statusPan.Show();
        }
        private void showError(string message)
        {
            errorMsg.Text = message;
            errorPan.Show();
            Timer ura = new Timer();
            ura.Interval = 1000;
            ura.Tick += hideAfter;
            ura.Start();
        }

        void hideAfter(object sender, EventArgs e)
        {
            Timer ticker = sender as Timer;
            if (uraTick++ > 2)
            {
                uraTick = 0;
                ticker.Stop();
                errorPan.Hide();
            }
        }

        private void updateTitle(string downloading, int index)
        {
            Title = "Downloading: " + downloading;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string backupPath = d.SaveLocation;
            d.OnChangeTitle += updateTitle;
            if (createFolder.Checked)
            {
               
                    d.SaveLocation = Path.Combine(d.SaveLocation, d.playlistTitle);
            }

            if (!System.IO.Directory.Exists(d.SaveLocation))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(d.SaveLocation);
                }
                catch
                {
                    showError("Unable to create playlist folder.");
                    d.SaveLocation = backupPath;
                    System.IO.Directory.CreateDirectory(d.SaveLocation);
                }
            }
            downloadWorker.RunWorkerAsync();
            saveLocation.Enabled = false;
            createFolder.Enabled = false;
            button2.Enabled = false;
        }

        void downloadNextSong(object sender, AsyncCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            tracksPanel.Controls[d.currentSong-1].BackColor = Color.Gray;
            if (!downloadWorker.IsBusy)
                downloadWorker.RunWorkerAsync();
            else
                this.Invoke(new Action(() =>
                {
                    d.dlSong();
                }));
        }

        void updateProgressbar(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void downloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
                this.Invoke(new Action(() =>
                {
                    try
                    {
                        d.dlSong();
                    }
                    catch (Exception a)
                    {
                        Console.WriteLine(a.Message);
                        Title = "Download complete.";
                        int x = downloaderPanel.Height;
                        for (int i = x; i > 0; i--)
                        {
                            this.Height--;
                            Application.DoEvents();
                        }
                        downloaderPanel.Hide();
                        openFolder.Show();
                        linkLabel2.Show();
                    }
                }));
        }

        private void createFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (createFolder.Checked)
                d.CreateFolder = false;
            else
                d.CreateFolder = true;
        }

        private void saveLocation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the location where you wish to save the playlist";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                d.SaveLocation = fbd.SelectedPath;
                saveLocation.Text = d.SaveLocation;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(d.SaveLocation);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Restart();
        }
    }
    class CustomPanel : Panel
    {
        public int i;
        public CustomPanel(int index)
        {
            i = index;
        }
    }
}
