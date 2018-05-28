namespace BBTorrent_1._0
{
    partial class FormAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdd));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonFind = new System.Windows.Forms.Button();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.labelTorrent = new System.Windows.Forms.Label();
            this.labelFPath = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(323, 18);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(122, 51);
            this.buttonFind.TabIndex = 0;
            this.buttonFind.Text = "Find torrent";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(323, 126);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(122, 52);
            this.buttonFolder.TabIndex = 1;
            this.buttonFolder.Text = "Choose folder to download";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(159, 345);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(160, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add torrent";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // labelTorrent
            // 
            this.labelTorrent.AutoSize = true;
            this.labelTorrent.Location = new System.Drawing.Point(31, 91);
            this.labelTorrent.Name = "labelTorrent";
            this.labelTorrent.Size = new System.Drawing.Size(77, 17);
            this.labelTorrent.TabIndex = 3;
            this.labelTorrent.Text = "Torrent file";
            // 
            // labelFPath
            // 
            this.labelFPath.AutoSize = true;
            this.labelFPath.Location = new System.Drawing.Point(31, 201);
            this.labelFPath.Name = "labelFPath";
            this.labelFPath.Size = new System.Drawing.Size(48, 17);
            this.labelFPath.TabIndex = 4;
            this.labelFPath.Text = "Folder";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(53, 300);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(34, 17);
            this.labelPort.TabIndex = 5;
            this.labelPort.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(117, 297);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(276, 22);
            this.textBoxPort.TabIndex = 6;
            this.textBoxPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPort_KeyPress);
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 418);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelFPath);
            this.Controls.Add(this.labelTorrent);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.buttonFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label labelTorrent;
        private System.Windows.Forms.Label labelFPath;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxPort;
    }
}