using MonoTorrent.BEncoding;
using MonoTorrent.Client;
using MonoTorrent.Client.Encryption;
using MonoTorrent.Common;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBTorrent_1._0
{
    public partial class FormMain : Form
    {
        public string torrentsPath;
        public string dowmloadsPath;
        public int port;
        private Engine engine;
        public StringBuilder sb = new StringBuilder(1024);

        public FormMain()
        {
           //listBox listBoxtT = new ListBox();
            //        listBoxtT.Select();
        //    this.listBoxtT.SelectedItem = this.listBoxtT.Items[0];
            InitializeComponent();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (FormAdd formAdd = new FormAdd())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    torrentsPath = formAdd.TorrentsPath;
                    dowmloadsPath = formAdd.DownloadsPath;
                    port = formAdd.Port;
                }
            }
            if (torrentsPath != "")
            {
                engine = new Engine(torrentsPath, dowmloadsPath, port);
            }
            timer.Enabled = true;
            listBoxtT.Items.Add(engine.torrents[0].Torrent.Name);
        }

        private void ShowStats(string name)
        {
            bool running = true;
        //    while (running)
        //    {
                if ((name == "All torrents") || (name == ""))
                {
                    sb.Remove(0, sb.Length);
                    running = engine.torrents.Exists(delegate (TorrentManager m) { return m.State != TorrentState.Stopped; });

                    AppendFormat(sb, "Total Download Rate: {0:0.00}kB/sec", engine.engine.TotalDownloadSpeed / 1024.0);
                    AppendFormat(sb, "Total Upload Rate:   {0:0.00}kB/sec", engine.engine.TotalUploadSpeed / 1024.0);
                    AppendFormat(sb, "Disk Read Rate:      {0:0.00} kB/s", engine.engine.DiskManager.ReadRate / 1024.0);
                    AppendFormat(sb, "Disk Write Rate:     {0:0.00} kB/s", engine.engine.DiskManager.WriteRate / 1024.0);
                    AppendFormat(sb, "Total Read:         {0:0.00} kB", engine.engine.DiskManager.TotalRead / 1024.0);
                    AppendFormat(sb, "Total Written:      {0:0.00} kB", engine.engine.DiskManager.TotalWritten / 1024.0);
                    AppendFormat(sb, "Open Connections:    {0}", engine.engine.ConnectionManager.OpenConnections);
                }
                else
                {
                    foreach (TorrentManager manager in engine.torrents)
                    {
                        if (name == manager.Torrent.Name)
                        {
                            sb.Remove(0, sb.Length);
                            AppendFormat(sb, "State:           {0}", manager.State);
                            AppendFormat(sb, "Name:            {0}", manager.Torrent == null ? "MetaDataMode" : manager.Torrent.Name);
                            AppendFormat(sb, "Progress:           {0:0.00}", manager.Progress);
                            AppendFormat(sb, "Download Speed:     {0:0.00} kB/s", manager.Monitor.DownloadSpeed / 1024.0);
                            AppendFormat(sb, "Upload Speed:       {0:0.00} kB/s", manager.Monitor.UploadSpeed / 1024.0);
                            AppendFormat(sb, "Total Downloaded:   {0:0.00} MB", manager.Monitor.DataBytesDownloaded / (1024.0 * 1024.0));
                            AppendFormat(sb, "Total Uploaded:     {0:0.00} MB", manager.Monitor.DataBytesUploaded / (1024.0 * 1024.0));
                            MonoTorrent.Client.Tracker.Tracker tracker = manager.TrackerManager.CurrentTracker;
                            //AppendFormat(sb, "Tracker Status:     {0}", tracker == null ? "<no tracker>" : tracker.State.ToString());
                            AppendFormat(sb, "Warning Message:    {0}", tracker == null ? "<no tracker>" : tracker.WarningMessage);
                            AppendFormat(sb, "Failure Message:    {0}", tracker == null ? "<no tracker>" : tracker.FailureMessage);
                            AppendFormat(sb, "", null);
                            if (manager.Torrent != null)
                                foreach (TorrentFile file in manager.Torrent.Files)
                                    AppendFormat(sb, "{1:0.00}% - {0}", file.Path, file.BitField.PercentComplete);
                        }
                    }
                }
                textBoxProp.Text = sb.ToString();
            }  

        public void manager_PeersFound(object sender, PeersAddedEventArgs e)
        {
            lock (engine.listener)
                engine.listener.WriteLine(string.Format("Found {0} new peers and {1} existing peers", e.NewPeers, e.ExistingPeers));//throw new Exception("The method or operation is not implemented.");
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

        public static void Download(string torrentFilePath, string downloadFolderPath)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowStats(listBoxtT.SelectedItem.ToString());
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }
    }
}
