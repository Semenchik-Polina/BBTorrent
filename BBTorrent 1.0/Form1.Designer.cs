namespace BBTorrent_1._0
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonAddTor = new System.Windows.Forms.Button();
            this.buttonTDelete = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dgwTorrents = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploadSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTorrents)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddTor
            // 
            this.buttonAddTor.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddTor.Location = new System.Drawing.Point(35, 49);
            this.buttonAddTor.Name = "buttonAddTor";
            this.buttonAddTor.Size = new System.Drawing.Size(110, 31);
            this.buttonAddTor.TabIndex = 0;
            this.buttonAddTor.Text = "Add";
            this.buttonAddTor.UseVisualStyleBackColor = false;
            this.buttonAddTor.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonTDelete
            // 
            this.buttonTDelete.Location = new System.Drawing.Point(35, 86);
            this.buttonTDelete.Name = "buttonTDelete";
            this.buttonTDelete.Size = new System.Drawing.Size(110, 31);
            this.buttonTDelete.TabIndex = 1;
            this.buttonTDelete.Text = "Delete";
            this.buttonTDelete.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(190, 357);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(710, 44);
            this.progressBar.TabIndex = 3;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // dgwTorrents
            // 
            this.dgwTorrents.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwTorrents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwTorrents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTorrents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.size,
            this.downloadSpeed,
            this.uploadSpeed});
            this.dgwTorrents.GridColor = System.Drawing.SystemColors.Control;
            this.dgwTorrents.Location = new System.Drawing.Point(190, 49);
            this.dgwTorrents.Name = "dgwTorrents";
            this.dgwTorrents.ReadOnly = true;
            this.dgwTorrents.RowTemplate.Height = 24;
            this.dgwTorrents.Size = new System.Drawing.Size(710, 242);
            this.dgwTorrents.TabIndex = 5;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 300;
            // 
            // size
            // 
            this.size.HeaderText = "Size";
            this.size.Name = "size";
            this.size.ReadOnly = true;
            this.size.Width = 50;
            // 
            // downloadSpeed
            // 
            this.downloadSpeed.HeaderText = "Download speed";
            this.downloadSpeed.Name = "downloadSpeed";
            this.downloadSpeed.ReadOnly = true;
            this.downloadSpeed.Width = 70;
            // 
            // uploadSpeed
            // 
            this.uploadSpeed.HeaderText = "Upload speed";
            this.uploadSpeed.Name = "uploadSpeed";
            this.uploadSpeed.ReadOnly = true;
            this.uploadSpeed.Width = 70;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(35, 223);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(110, 31);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(35, 260);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(110, 31);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // buttonStats
            // 
            this.buttonStats.Location = new System.Drawing.Point(35, 357);
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Size = new System.Drawing.Size(110, 31);
            this.buttonStats.TabIndex = 8;
            this.buttonStats.Text = "Show total stats";
            this.buttonStats.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(967, 449);
            this.Controls.Add(this.buttonStats);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.dgwTorrents);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonTDelete);
            this.Controls.Add(this.buttonAddTor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "BBTorrent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTorrents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddTor;
        private System.Windows.Forms.Button buttonTDelete;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.DataGridView dgwTorrents;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn size;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadSpeed;
    }
}

