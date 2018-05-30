using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using MonoTorrent.Common;
using MonoTorrent.Client;
using System.Net;
using System.Diagnostics;
using System.Threading;
using MonoTorrent.BEncoding;
using MonoTorrent.Client.Encryption;
using MonoTorrent.Client.Tracker;
using MonoTorrent.Dht;

namespace BBTorrent_1._0
{


    class Engine
    {
        private string dhtNodeFile;
     //   private string basePath;
        public string downloadsPath;
        public string fastResumeFile;
        public string torrentsPath;
  //      private string basicTorrentsPath;
  //      private string basicDownloadsPath;
        public ClientEngine engine;				// The engine used for downloading
        public List<TorrentManager> torrents;	// The list where all the torrentManagers will be stored that the engine gives us
        public Top10Listener listener;          // This is a subclass of TraceListener which remembers the last 20 statements sent to it

        public string BasicTorrentsPath
        {
            get { return Path.Combine(Environment.CurrentDirectory, "Torrents");}
        }

        public string BasicDownloadsPath
        {
            get { return Path.Combine(Environment.CurrentDirectory, "Downloads"); }
        }

        public Engine(string TorrentsPath, string DownloadsPath, int Port)
        {
            torrentsPath = TorrentsPath;				// This is the directory we will save .torrents to
            downloadsPath = DownloadsPath;            // This is the directory we will save downloads to
            fastResumeFile = Path.Combine(torrentsPath, "fastresume.data");
            dhtNodeFile = Path.Combine(Environment.CurrentDirectory, "DhtNodes");
            torrents = new List<TorrentManager>();							// This is where we will store the torrentmanagers
            listener = new Top10Listener(10);

            try
            {
                if (BasicTorrentsPath != torrentsPath)
                {
                    string fName = torrentsPath.Substring(torrentsPath.LastIndexOf((char)92) + 1, torrentsPath.Length - torrentsPath.LastIndexOf((char)92) - 1);
                    File.Copy(torrentsPath, Path.Combine(BasicTorrentsPath, fName), true);
                }
            }
            catch
            {
                MessageBox.Show("Catch");
            }
            

            // We need to cleanup correctly when the user closes the window by using ctrl-c
            // or an unhandled exception happens
            AppDomain.CurrentDomain.ProcessExit += delegate { shutdown(); };
            AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs e) { Console.WriteLine(e.ExceptionObject); shutdown(); };
            Thread.GetDomain().UnhandledException += delegate (object sender, UnhandledExceptionEventArgs e) { Console.WriteLine(e.ExceptionObject); shutdown(); };

            StartEngine(Port);
        }

        private void StartEngine(int port)
        {
            Torrent torrent = null;
            // Create the settings which the engine will use
            // downloadsPath - this is the path where we will save all the files to
            // port - this is the port we listen for connections on
            EngineSettings engineSettings = new EngineSettings(downloadsPath, port);
            engineSettings.PreferEncryption = false;
            engineSettings.AllowedEncryption = EncryptionTypes.All;

            //engineSettings.GlobalMaxUploadSpeed = 30 * 1024;
            //engineSettings.GlobalMaxDownloadSpeed = 100 * 1024;
            //engineSettings.MaxReadRate = 1 * 1024 * 1024;


            // Create the default settings which a torrent will have.
            // 4 Upload slots 
            // 50 open connections 
            // Unlimited download, upload speed 
            TorrentSettings torrentDefaults = new TorrentSettings(4, 150, 0, 0);

            // Create an instance of the engine.
            engine = new ClientEngine(engineSettings);
            engine.ChangeListenEndpoint(new IPEndPoint(IPAddress.Any, port));
            byte[] nodes = null;
            try
            {
                nodes = File.ReadAllBytes(dhtNodeFile);
            }
            catch
            {
                MessageBox.Show("No existing dht nodes could be loaded");
            }

            DhtListener dhtListner = new DhtListener(new IPEndPoint(IPAddress.Any, port));
            DhtEngine dht = new DhtEngine(dhtListner);
            engine.RegisterDht(dht);
            dhtListner.Start();
            engine.DhtEngine.Start(nodes);

            // If the torrentsPath does not exist, we want to create it
            if (!Directory.Exists(BasicTorrentsPath))
                Directory.CreateDirectory(BasicTorrentsPath);

            // If the SavePath does not exist, we want to create it.
            if (!Directory.Exists(engine.Settings.SavePath))
                Directory.CreateDirectory(engine.Settings.SavePath);

            BEncodedDictionary fastResume;
            try
            {
                fastResume = BEncodedValue.Decode<BEncodedDictionary>(File.ReadAllBytes(fastResumeFile));
            }
            catch
            {
                fastResume = new BEncodedDictionary();
            }

            // For each file in the torrents path that is a .torrent file, load it into the engine.
          foreach (string file in Directory.GetFiles(BasicTorrentsPath))
          {

            if (file.EndsWith(".torrent"))
            {
                try
                {
                    // Load the .torrent from the file into a Torrent instance
                    // You can use this to do preprocessing should you need to
                    torrent = Torrent.Load(file);

                    // Console.WriteLine(torrent.InfoHash.ToString());
                }
                catch (Exception e)
                {
                    MessageBox.Show("Couldn't decode {0}: " + e.Message, file);
                    //   continue;
                }
                // When any preprocessing has been completed, you create a TorrentManager
                // which you then register with the engine.
                TorrentManager manager = new TorrentManager(torrent, downloadsPath, torrentDefaults);
                if (fastResume.ContainsKey(torrent.InfoHash.ToHex()))
                    manager.LoadFastResume(new FastResume((BEncodedDictionary)fastResume[torrent.InfoHash.ToHex()]));
                engine.Register(manager);

                // Store the torrent manager in our list so we can access it later
                torrents.Add(manager);
                manager.PeersFound += new EventHandler<PeersAddedEventArgs>(manager_PeersFound);
            }
           }

            // If we loaded no torrents, just exist. The user can put files in the torrents directory and start
            // the client again
            if (torrents.Count == 0)
            {
                MessageBox.Show("No torrents found in the Torrents directory");
                MessageBox.Show("Exiting...");
                engine.Dispose();
                return;
            }

            // For each torrent manager we loaded and stored in our list, hook into the events
            // in the torrent manager and start the engine.
            foreach (TorrentManager manager in torrents)
            {
                // Every time a piece is hashed, this is fired.
                manager.PieceHashed += delegate (object o, PieceHashedEventArgs e) {
                    lock (listener)
                        listener.WriteLine(string.Format("Piece Hashed: {0} - {1}", e.PieceIndex, e.HashPassed ? "Pass" : "Fail"));
                };

                // Every time the state changes (Stopped -> Seeding -> Downloading -> Hashing) this is fired
                manager.TorrentStateChanged += delegate (object o, TorrentStateChangedEventArgs e) {
                    lock (listener)
                        listener.WriteLine("OldState: " + e.OldState.ToString() + " NewState: " + e.NewState.ToString());
                };

                // Every time the tracker's state changes, this is fired
                foreach (TrackerTier tier in manager.TrackerManager)
                {
                    foreach (MonoTorrent.Client.Tracker.Tracker t in tier.GetTrackers())
                    {
                        t.AnnounceComplete += delegate (object sender, AnnounceResponseEventArgs e) {
                            listener.WriteLine(string.Format("{0}: {1}", e.Successful, e.Tracker.ToString()));
                        };
                    }
                }
                // Start the torrentmanager. The file will then hash (if required) and begin downloading/seeding
                manager.Start();
            }
        }

        public void manager_PeersFound(object sender, PeersAddedEventArgs e)
        {
            lock (listener)
                listener.WriteLine(string.Format("Found {0} new peers and {1} existing peers", e.NewPeers, e.ExistingPeers));//throw new Exception("The method or operation is not implemented.");
        }

        public void AppendSeperator(StringBuilder sb)
        {
            AppendFormat(sb, "", null);
            AppendFormat(sb, "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", null);
            AppendFormat(sb, "", null);
        }
        private void AppendFormat(StringBuilder sb, string str, params object[] formatting)
        {
            if (formatting != null)
                sb.AppendFormat(str, formatting);
            else
                sb.Append(str);
            sb.AppendLine();
        }

        private void shutdown()
        {
            BEncodedDictionary fastResume = new BEncodedDictionary();
            for (int i = 0; i < torrents.Count; i++)
            {
                torrents[i].Stop(); ;
                while (torrents[i].State != TorrentState.Stopped)
                {
                    Console.WriteLine("{0} is {1}", torrents[i].Torrent.Name, torrents[i].State);
                    Thread.Sleep(250);
                }

                fastResume.Add(torrents[i].Torrent.InfoHash.ToHex(), torrents[i].SaveFastResume().Encode());
            }

#if !DISABLE_DHT
            File.WriteAllBytes(dhtNodeFile, engine.DhtEngine.SaveNodes());
#endif
            File.WriteAllBytes(fastResumeFile, fastResume.Encode());
            engine.Dispose();

            foreach (TraceListener lst in Debug.Listeners)
            {
                lst.Flush();
                lst.Close();
            }

            System.Threading.Thread.Sleep(2000);
        }
    }
}