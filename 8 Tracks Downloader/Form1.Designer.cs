namespace _8_Tracks_Downloader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.titleMsg = new System.Windows.Forms.Label();
            this.slave = new System.ComponentModel.BackgroundWorker();
            this.formPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.statusPan = new System.Windows.Forms.Panel();
            this.statusMsg = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.downloaderPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.createFolder = new System.Windows.Forms.CheckBox();
            this.saveLocation = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tracksPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.errorPan = new System.Windows.Forms.Panel();
            this.errorMsg = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.downloadWorker = new System.ComponentModel.BackgroundWorker();
            this.openFolder = new System.Windows.Forms.LinkLabel();
            this.formPanel.SuspendLayout();
            this.statusPan.SuspendLayout();
            this.downloaderPanel.SuspendLayout();
            this.errorPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleMsg
            // 
            this.titleMsg.AutoSize = true;
            this.titleMsg.Font = new System.Drawing.Font("Dosis", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.titleMsg.Location = new System.Drawing.Point(31, 9);
            this.titleMsg.Name = "titleMsg";
            this.titleMsg.Size = new System.Drawing.Size(190, 25);
            this.titleMsg.TabIndex = 0;
            this.titleMsg.Text = "Enter your playlist URL";
            // 
            // aziat
            // 
            this.slave.DoWork += new System.ComponentModel.DoWorkEventHandler(this.aziat_DoWork);
            this.slave.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.aziat_doneWorking);
            // 
            // formPanel
            // 
            this.formPanel.Controls.Add(this.button1);
            this.formPanel.Controls.Add(this.statusPan);
            this.formPanel.Controls.Add(this.textBox1);
            this.formPanel.Location = new System.Drawing.Point(5, 37);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(557, 125);
            this.formPanel.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "Next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusPan
            // 
            this.statusPan.BackColor = System.Drawing.Color.LimeGreen;
            this.statusPan.Controls.Add(this.statusMsg);
            this.statusPan.Location = new System.Drawing.Point(63, 38);
            this.statusPan.Name = "statusPan";
            this.statusPan.Size = new System.Drawing.Size(268, 22);
            this.statusPan.TabIndex = 7;
            this.statusPan.Visible = false;
            // 
            // statusMsg
            // 
            this.statusMsg.AutoSize = true;
            this.statusMsg.BackColor = System.Drawing.Color.Transparent;
            this.statusMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusMsg.Location = new System.Drawing.Point(3, 4);
            this.statusMsg.Name = "statusMsg";
            this.statusMsg.Size = new System.Drawing.Size(113, 15);
            this.statusMsg.TabIndex = 0;
            this.statusMsg.Text = "Status message.";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Dosis", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(63, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(454, 32);
            this.textBox1.TabIndex = 6;
            // 
            // downloaderPanel
            // 
            this.downloaderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloaderPanel.AutoSize = true;
            this.downloaderPanel.Controls.Add(this.panel1);
            this.downloaderPanel.Controls.Add(this.createFolder);
            this.downloaderPanel.Controls.Add(this.saveLocation);
            this.downloaderPanel.Controls.Add(this.label2);
            this.downloaderPanel.Controls.Add(this.button2);
            this.downloaderPanel.Controls.Add(this.label1);
            this.downloaderPanel.Controls.Add(this.tracksPanel);
            this.downloaderPanel.Controls.Add(this.progressBar1);
            this.downloaderPanel.Location = new System.Drawing.Point(5, 168);
            this.downloaderPanel.Name = "downloaderPanel";
            this.downloaderPanel.Size = new System.Drawing.Size(570, 312);
            this.downloaderPanel.TabIndex = 7;
            this.downloaderPanel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(4, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(9, 224);
            this.panel1.TabIndex = 7;
            // 
            // createFolder
            // 
            this.createFolder.AutoSize = true;
            this.createFolder.Checked = true;
            this.createFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createFolder.Enabled = false;
            this.createFolder.Location = new System.Drawing.Point(3, 276);
            this.createFolder.Name = "createFolder";
            this.createFolder.Size = new System.Drawing.Size(120, 17);
            this.createFolder.TabIndex = 6;
            this.createFolder.Text = "Create playlist folder";
            this.createFolder.UseVisualStyleBackColor = true;
            this.createFolder.CheckedChanged += new System.EventHandler(this.createFolder_CheckedChanged);
            // 
            // saveLocation
            // 
            this.saveLocation.AutoSize = true;
            this.saveLocation.Enabled = false;
            this.saveLocation.Location = new System.Drawing.Point(73, 261);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.Size = new System.Drawing.Size(73, 13);
            this.saveLocation.TabIndex = 5;
            this.saveLocation.TabStop = true;
            this.saveLocation.Text = "SaveLocation";
            this.saveLocation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.saveLocation_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Saving to";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(454, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Download";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Uncheck the songs you don\'t wish to download.";
            // 
            // tracksPanel
            // 
            this.tracksPanel.AutoScroll = true;
            this.tracksPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tracksPanel.Location = new System.Drawing.Point(13, 33);
            this.tracksPanel.Name = "tracksPanel";
            this.tracksPanel.Size = new System.Drawing.Size(538, 224);
            this.tracksPanel.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(24, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(513, 10);
            this.progressBar1.TabIndex = 0;
            // 
            // errorPan
            // 
            this.errorPan.BackColor = System.Drawing.Color.Orange;
            this.errorPan.Controls.Add(this.errorMsg);
            this.errorPan.Location = new System.Drawing.Point(314, 12);
            this.errorPan.Name = "errorPan";
            this.errorPan.Size = new System.Drawing.Size(248, 22);
            this.errorPan.TabIndex = 8;
            this.errorPan.Visible = false;
            // 
            // errorMsg
            // 
            this.errorMsg.AutoSize = true;
            this.errorMsg.BackColor = System.Drawing.Color.Transparent;
            this.errorMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorMsg.Location = new System.Drawing.Point(3, 4);
            this.errorMsg.Name = "errorMsg";
            this.errorMsg.Size = new System.Drawing.Size(113, 15);
            this.errorMsg.TabIndex = 0;
            this.errorMsg.Text = "Status message.";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(311, 18);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(94, 13);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Download another";
            this.linkLabel2.Visible = false;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // downloadWorker
            // 
            this.downloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.downloadWorker_DoWork);
            // 
            // openFolder
            // 
            this.openFolder.AutoSize = true;
            this.openFolder.Location = new System.Drawing.Point(243, 18);
            this.openFolder.Name = "openFolder";
            this.openFolder.Size = new System.Drawing.Size(62, 13);
            this.openFolder.TabIndex = 9;
            this.openFolder.TabStop = true;
            this.openFolder.Text = "Open folder";
            this.openFolder.Visible = false;
            this.openFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 492);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.openFolder);
            this.Controls.Add(this.errorPan);
            this.Controls.Add(this.downloaderPanel);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.titleMsg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "8Tracks Downloader - Select playlist";
            this.formPanel.ResumeLayout(false);
            this.formPanel.PerformLayout();
            this.statusPan.ResumeLayout(false);
            this.statusPan.PerformLayout();
            this.downloaderPanel.ResumeLayout(false);
            this.downloaderPanel.PerformLayout();
            this.errorPan.ResumeLayout(false);
            this.errorPan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleMsg;
        private System.ComponentModel.BackgroundWorker slave;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel statusPan;
        private System.Windows.Forms.Label statusMsg;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel downloaderPanel;
        private System.Windows.Forms.FlowLayoutPanel tracksPanel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel errorPan;
        private System.Windows.Forms.Label errorMsg;
        private System.ComponentModel.BackgroundWorker downloadWorker;
        private System.Windows.Forms.LinkLabel saveLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox createFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel openFolder;
    }
}

