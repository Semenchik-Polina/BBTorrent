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
    //    private string basicTorrentsPath;
    //    private string basicDownloadsPath;
        public string torrentsPath;
        public string downloadsPath;
        public int port;
        private Engine engine;
        private StringBuilder sb = new StringBuilder(1024);

        public FormMain()
        {
            //listBox listBoxtT = new ListBox();
            //        listBoxtT.Select();
            //    this.listBoxtT.SelectedItem = this.listBoxtT.Items[0];
            InitializeComponent();
            timer.Interval = 10000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            using (FormAdd formAdd = new FormAdd())
            {
                if (formAdd.ShowDialog() == DialogResult.OK)
                {
                    torrentsPath = formAdd.TorrentsPath;
                    downloadsPath = formAdd.DownloadsPath;
                    port = formAdd.Port;
                }
            }
            if ((torrentsPath != null) && (downloadsPath != null) && (port != 0))
            {
                engine = new Engine(torrentsPath, downloadsPath, port);               
            }
        }
               

        private void ShowStats()
        {
            foreach (TorrentManager manager in engine.torrents)
            {
                DataGridViewRow row = (DataGridViewRow)dgwTorrents.Rows[0].Clone();
                row.Cells[0].Value = manager.Torrent == null ? "MetaDataMode" : manager.Torrent.Name;
                row.Cells[1].Value = manager.Torrent.Size;
                row.Cells[2].Value = string.Format("{0:0.00}  kB / s", manager.Monitor.DownloadSpeed / 1024.0);
                row.Cells[3].Value = string.Format("{0:0.00}  kB / s", manager.Monitor.UploadSpeed / 1024.0);
                dgwTorrents.Rows.Add(row);
            }
        }

       /* public void manager_PeersFound(object sender, PeersAddedEventArgs e)
        {
            lock (engine.listener)
                engine.listener.WriteLine(string.Format("Found {0} new peers and {1} existing peers", e.NewPeers, e.ExistingPeers));//throw new Exception("The method or operation is not implemented.");
        }*/

        public static void Download(string torrentFilePath, string downloadFolderPath)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (dgwTorrents.Rows.Count < engine.torrents.Count)
            {
                ShowStats();
            }
            else
            {
                dgwTorrents.Rows.Clear();
                ShowStats();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }

        private void listBoxtT_SelectedValueChanged(object sender, EventArgs e)
        {
         //   ShowStats(listBoxtT.SelectedItem.ToString());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            engine = new Engine(Path.Combine(Environment.CurrentDirectory, "Torrents"), Path.Combine(Environment.CurrentDirectory, "Downloads"), 6969);
        }
      
    }
}