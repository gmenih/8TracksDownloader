using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _8_Tracks_Downloader
{
    public delegate void UpdateInterface(string name, string performer, int index);
    public delegate void UpdateTitle(string downloading, int index);
    public delegate void ChangeButton();
    class Downloader
    {
        public UpdateInterface OnTrackDone;
        public UpdateTitle OnChangeTitle;
        public ChangeButton ChgButton;
        private string playlistURL; // url naslov seznama
        private string playlistID; // id
        private string playToken; //token za predvajanje
        private string playTokenURL = "http://8tracks.com/sets/new?format=jsonh";
        public string SaveLocation;
        public WebClient client;
        public List<RealTrack> playlist = new List<RealTrack>();
        public string playlistTitle;
        public bool CreateFolder = true;
        public int currentSong = 0;

        public Downloader(string url)
        {
            SaveLocation = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents", "8Tracks Downloader");
            client = new WebClient();
            playlistURL = url;
            playlistID = getPlaylistId();
            playToken = getNewToken();
        }
        public void dlSong()
        {
            try
            {
                if (currentSong < playlist.Count)
                {
                    while (!playlist[currentSong].download)
                        currentSong++;
                    string extension = Path.GetExtension(playlist[currentSong].url);
                    extension = extension != "" ? extension : ".mp3";
                    string FileName = playlist[currentSong].performer + " - " + playlist[currentSong].name;
                    OnChangeTitle(FileName, currentSong);
                    string fileName = SaveLocation + @"\" + FileName +extension;
                    client.DownloadFileAsync(new Uri(playlist[currentSong].url), fileName);
                    currentSong++;
                }
                else
                {
                    throw new Exception("Napaka");
                }
                
            }
            catch (Exception)
            {
                throw new Exception("Error downloading songs.");
            }
            
        }
        public void loadSongs()
        {
            try
            {
                string playURL = "http://8tracks.com/sets/" + playToken + "/play?mix_id=" + playlistID + "&format=jsonh";
                Loop: //GOTO
                JavaScriptSerializer parser = new JavaScriptSerializer(); //razčlenjevalnik
                string songJSON = HttpSend(playURL); //prenesem JSON za trenutno skladbo
                Playlist root = parser.Deserialize<Playlist>(songJSON); //razčlenim JSON
                RealTrack temp = new RealTrack();
                temp.download = true;
                temp.name = root.set.track.name;
                temp.performer = root.set.track.performer;
                temp.url = root.set.track.track_file_stream_url;
                playlist.Add(temp); //skladbo dodam v tabelo
                //Console.WriteLine(root.set.track.name);
                OnTrackDone(root.set.track.name, root.set.track.performer, currentSong); //delgate metoda, ki doda checkbox
                if (!root.set.at_last_track) //če trenutna skladba na seznamu še ni zadnja se zanka ponovi
                {
                    currentSong++;
                    playURL = "http://8tracks.com/sets/" + playToken + "/next?mix_id=" + playlistID + "&format=jsonh";
                    goto Loop;
                }
                else
                {
                    //Console.WriteLine("Current song reset.");
                    currentSong = 0;
                    ChgButton();
                    //throw new WebException("Prenos končan");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error loading songs.");
            }
        }
        private string getPlaylistId()
        {
            try
            {
                string pageSource = HttpSend(playlistURL); //shranim izvorno html kodo strani
                //iz kode izluščimo ID seznama
                string[] pieces = pageSource.Split(new string[] { "mixes/" }, StringSplitOptions.None);
                string[] temp = pieces[1].Split(new string[] { "/" }, StringSplitOptions.None);
                //pridobimo še ime seznama
                playlistTitle = Regex.Match(pageSource,
                @"\<title[^>]*\>[^|]*\|\s*(?<Title>[^|]*?)\|[^<]*\</title\>",
                RegexOptions.IgnoreCase).Groups["Title"].Value;
                //vrnemo ID seznama v obliki string
                return temp[0];
            }
            catch (Exception)
            {
                //v primeru, da pride do napake pri prenosu izvorne html kode dodam novo izjemo
                throw new Exception("Not a valid playlist.");
            }
        }
        private string getNewToken()
        {
            try
            {
                string tokenJSON = HttpSend(playTokenURL); //shranim JSON, v katerem je žeton
                JavaScriptSerializer parser = new JavaScriptSerializer(); //definiram nov razčlenjevalnik
                TokenJSON temp = parser.Deserialize<TokenJSON>(tokenJSON); //razčlenim JSON v objekte
                //Console.WriteLine(temp.play_token);
                return temp.play_token; //vrnem žeton predvajanja
            }
            catch (Exception)
            {
                throw new Exception("Error fetching token.");
            }
        }

        private string HttpSend(string url, string data = null, string type = "GET")
        {
            Uri scvURI = new Uri("http://149.62.80.19:8080");
            WebProxy scvProxy = new WebProxy();
            scvProxy.Address = scvURI;
            scvProxy.Credentials = new NetworkCredential("scv-proxy", "scvproxy", "ad");
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Proxy = scvProxy;
                request.KeepAlive = false;
                request.Timeout = 5000;
                request.Method = type;
                //data
                request.ContentType = "application/x-www-form-urlencoded";


                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                string FinalResult = streamReader.ReadToEnd();
                //Console.WriteLine(FinalResult);
                return FinalResult;
            }
            catch (Exception webception)
            {
                //timeout - sklepamo da ni povezave
                throw new Exception("Timeout error");
            }

        }
    }
    class TokenJSON
    {
        public string play_token { get; set; }
        string status { get; set; }
        string errors { get; set; }
        string notices { get; set; }
        int api_version { get; set; }
    }
    class Playlist
    {
        public Set set { get; set; }
        string status { get; set; }
        string errors { get; set; }
        string notices { get; set; }
        string api_version { get; set; }
    }
    class Set
    {
        bool at_beginning { get; set; }
        bool at_end { get; set; }
        public bool at_last_track { get; set; }
        public Track track { get; set; }
    }
    public class Track
    {
        bool faved_by_current_user { get; set; }
        string buy_link { get; set; }
        string buy_icon { get; set; }
        string buy_text { get; set; }
        public string track_file_stream_url { get; set; }
        string stream_source { get; set; }
        string user_id { get; set; }
        string track_annotation { get; set; }
        string you_tube_id { get; set; }
        string you_tube_status { get; set; }
        string id { get; set; }
        public string name { get; set; }
        public string performer { get; set; }
        string release_name { get; set; }
        string url { get; set; }
        string year { get; set; }
        string uid { get; set; }
        bool full_length { get; set; }
    }
    public class RealTrack
    {
        public string name { get; set; }
        public string performer { get; set; }
        public string url { get; set; }
        public bool download { get; set; }
    }

}
