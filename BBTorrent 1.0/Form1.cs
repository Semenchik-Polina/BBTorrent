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

        public FormMain()
        {
            InitializeComponent();
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
                Engine engine = new Engine(torrentsPath, dowmloadsPath, port);
            }         
        }

        public static void Download(string torrentFilePath, string downloadFolderPath)
        {
            
        }
    }
}
