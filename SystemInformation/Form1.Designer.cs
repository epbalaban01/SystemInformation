namespace SystemInformation
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnExport = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadInfo = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtOlarakKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xmlOlarakKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLOlarakKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVOlarakKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONOlarakKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tEmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whitetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darktoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarıSıfırlaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(359, 365);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(119, 27);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Dışarı Aktar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(21, 365);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "lblStatus";
            this.lblStatus.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 51);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(600, 300);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // btnLoadInfo
            // 
            this.btnLoadInfo.Location = new System.Drawing.Point(493, 365);
            this.btnLoadInfo.Name = "btnLoadInfo";
            this.btnLoadInfo.Size = new System.Drawing.Size(119, 27);
            this.btnLoadInfo.TabIndex = 0;
            this.btnLoadInfo.Text = "Bilgileri Getir";
            this.btnLoadInfo.UseVisualStyleBackColor = true;
            this.btnLoadInfo.Click += new System.EventHandler(this.btnLoadInfo_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtOlarakKaydetToolStripMenuItem,
            this.xmlOlarakKaydetToolStripMenuItem,
            this.hTMLOlarakKaydetToolStripMenuItem,
            this.cSVOlarakKaydetToolStripMenuItem,
            this.jSONOlarakKaydetToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 114);
            // 
            // txtOlarakKaydetToolStripMenuItem
            // 
            this.txtOlarakKaydetToolStripMenuItem.Name = "txtOlarakKaydetToolStripMenuItem";
            this.txtOlarakKaydetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.txtOlarakKaydetToolStripMenuItem.Text = "TXT Olarak Kaydet";
            // 
            // xmlOlarakKaydetToolStripMenuItem
            // 
            this.xmlOlarakKaydetToolStripMenuItem.Name = "xmlOlarakKaydetToolStripMenuItem";
            this.xmlOlarakKaydetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.xmlOlarakKaydetToolStripMenuItem.Text = "XML Olarak Kaydet";
            // 
            // hTMLOlarakKaydetToolStripMenuItem
            // 
            this.hTMLOlarakKaydetToolStripMenuItem.Name = "hTMLOlarakKaydetToolStripMenuItem";
            this.hTMLOlarakKaydetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.hTMLOlarakKaydetToolStripMenuItem.Text = "HTML olarak kaydet";
            // 
            // cSVOlarakKaydetToolStripMenuItem
            // 
            this.cSVOlarakKaydetToolStripMenuItem.Name = "cSVOlarakKaydetToolStripMenuItem";
            this.cSVOlarakKaydetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cSVOlarakKaydetToolStripMenuItem.Text = "CSV olarak kaydet";
            // 
            // jSONOlarakKaydetToolStripMenuItem
            // 
            this.jSONOlarakKaydetToolStripMenuItem.Name = "jSONOlarakKaydetToolStripMenuItem";
            this.jSONOlarakKaydetToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jSONOlarakKaydetToolStripMenuItem.Text = "JSON olarak kaydet";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "Türkçe",
            "İngilizce"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(219, 369);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 9;
            this.comboBoxLanguage.Visible = false;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.ayarlarToolStripMenuItem,
            this.hakkındaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tEmaToolStripMenuItem,
            this.ayarlarıSıfırlaToolStripMenuItem});
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            // 
            // tEmaToolStripMenuItem
            // 
            this.tEmaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whitetoolStripMenuItem,
            this.darktoolStripMenuItem});
            this.tEmaToolStripMenuItem.Name = "tEmaToolStripMenuItem";
            this.tEmaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.tEmaToolStripMenuItem.Text = "Tema";
            // 
            // whitetoolStripMenuItem
            // 
            this.whitetoolStripMenuItem.Name = "whitetoolStripMenuItem";
            this.whitetoolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.whitetoolStripMenuItem.Text = "Açık";
            this.whitetoolStripMenuItem.Click += new System.EventHandler(this.whitetoolStripMenuItem_Click);
            // 
            // darktoolStripMenuItem
            // 
            this.darktoolStripMenuItem.Name = "darktoolStripMenuItem";
            this.darktoolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.darktoolStripMenuItem.Text = "Koyu";
            this.darktoolStripMenuItem.Click += new System.EventHandler(this.darktoolStripMenuItem_Click);
            // 
            // ayarlarıSıfırlaToolStripMenuItem
            // 
            this.ayarlarıSıfırlaToolStripMenuItem.Name = "ayarlarıSıfırlaToolStripMenuItem";
            this.ayarlarıSıfırlaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ayarlarıSıfırlaToolStripMenuItem.Text = "Ayarları Sıfırla";
            this.ayarlarıSıfırlaToolStripMenuItem.Click += new System.EventHandler(this.ayarlarıSıfırlaToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Uygulama sistem tepsisinde çalışıyor.";
            this.notifyIcon1.BalloonTipTitle = "Uygulama Arka Planda";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Sistem Bilgileri";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gösterToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(109, 48);
            // 
            // gösterToolStripMenuItem
            // 
            this.gösterToolStripMenuItem.Name = "gösterToolStripMenuItem";
            this.gösterToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.gösterToolStripMenuItem.Text = "Göster";
            this.gösterToolStripMenuItem.Click += new System.EventHandler(this.gösterToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 419);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLoadInfo);
            this.Controls.Add(this.btnExport);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLoadInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem txtOlarakKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xmlOlarakKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTMLOlarakKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVOlarakKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jSONOlarakKaydetToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tEmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whitetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darktoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayarlarıSıfırlaToolStripMenuItem;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem gösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
    }
}

