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
            this.buttonAddTor = new System.Windows.Forms.Button();
            this.buttonTDelete = new System.Windows.Forms.Button();
            this.listBoxtT = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.textBoxProp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonAddTor
            // 
            this.buttonAddTor.Location = new System.Drawing.Point(35, 33);
            this.buttonAddTor.Name = "buttonAddTor";
            this.buttonAddTor.Size = new System.Drawing.Size(110, 31);
            this.buttonAddTor.TabIndex = 0;
            this.buttonAddTor.Text = "Add torrent";
            this.buttonAddTor.UseVisualStyleBackColor = true;
            this.buttonAddTor.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonTDelete
            // 
            this.buttonTDelete.Location = new System.Drawing.Point(35, 102);
            this.buttonTDelete.Name = "buttonTDelete";
            this.buttonTDelete.Size = new System.Drawing.Size(110, 31);
            this.buttonTDelete.TabIndex = 1;
            this.buttonTDelete.Text = "Delete torrent";
            this.buttonTDelete.UseVisualStyleBackColor = true;
            // 
            // listBoxtT
            // 
            this.listBoxtT.FormattingEnabled = true;
            this.listBoxtT.ItemHeight = 16;
            this.listBoxtT.Location = new System.Drawing.Point(190, 33);
            this.listBoxtT.Name = "listBoxtT";
            this.listBoxtT.Size = new System.Drawing.Size(529, 100);
            this.listBoxtT.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(190, 166);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(529, 44);
            this.progressBar.TabIndex = 3;
            // 
            // textBoxProp
            // 
            this.textBoxProp.Location = new System.Drawing.Point(190, 256);
            this.textBoxProp.Multiline = true;
            this.textBoxProp.Name = "textBoxProp";
            this.textBoxProp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProp.Size = new System.Drawing.Size(529, 171);
            this.textBoxProp.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 490);
            this.Controls.Add(this.textBoxProp);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.listBoxtT);
            this.Controls.Add(this.buttonTDelete);
            this.Controls.Add(this.buttonAddTor);
            this.Name = "FormMain";
            this.Text = "BBTorrent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddTor;
        private System.Windows.Forms.Button buttonTDelete;
        private System.Windows.Forms.ListBox listBoxtT;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox textBoxProp;
    }
}

