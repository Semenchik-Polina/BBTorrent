﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoTorrent;
using System.Windows.Forms;
using MonoTorrent.Common;

namespace BBTorrent_1._0
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
            buttonAdd.DialogResult = DialogResult.OK;
        }

        public string TorrentsPath
        {
            get { return labelTorrent.Text; }
        }

        public string DownloadsPath
        {
            get { return labelFPath.Text; }
        }

        public int Port
        {
            get { return Convert.ToInt32(textBoxPort.Text); }
        }

        private void buttonAddEnable()
        {
            if ((labelFPath.Text != "") && (labelTorrent.Text != "") && (textBoxPort.Text != ""))
            {
                buttonAdd.Enabled = true;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog.FileName);
                labelTorrent.Text = openFileDialog.FileName;
            }
            buttonAddEnable();
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                labelFPath.Text = folderBrowserDialog.SelectedPath;
            }
            buttonAddEnable();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 )
            { e.Handled = true; }
            buttonAddEnable();
        }
    }
}
