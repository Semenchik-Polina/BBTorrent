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
        private FormAdd formAdd;

        public FormMain()
        {
            InitializeComponent();
            formAdd = new FormAdd();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            formAdd.Show();
        }

        public static void Download(string torrentFilePath, string downloadFolderPath)
        {

        }
    }
}
