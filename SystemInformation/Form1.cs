using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemInformation.Properties;

namespace SystemInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logger.Log("Uygulama başlatıldı.");
            CheckForUpdate(); // burada kontrol ediliyor

            notifyIcon1.ContextMenuStrip = trayMenu;
            notifyIcon1.BalloonTipTitle = "Uygulama Arka Planda";
            notifyIcon1.BalloonTipText = "Uygulama sistem tepsisinde çalışıyor.";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            bool isDarkTheme = Properties.Settings.Default.AppTheme == "dark";
            ApplyTheme(isDarkTheme);


            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Bilgi Türü";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Name = "Değer";
            dataGridView1.Columns[1].Width = 430;
            //dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;


            //// DataGridView ayarları
            //dgvBilgi.ColumnCount = 2;
            //dgvBilgi.Columns[0].Name = "Bilgi Türü";
            //dgvBilgi.Columns[1].Name = "Değer";
            //dgvBilgi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvBilgi.RowHeadersVisible = false;

            //// Örnek veriler ekleyelim
            //dgvBilgi.Rows.Add("İşlemci", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            //dgvBilgi.Rows.Add("Bilgisayar Adı", Environment.MachineName);
            //dgvBilgi.Rows.Add("Kullanıcı", Environment.UserName);
            //dgvBilgi.Rows.Add("İşletim Sistemi", Environment.OSVersion.ToString());

            //KoyuTemaUygula();

           

        }

        //private void KoyuTemaUygula()
        //{
        //    dgvBilgi.BackgroundColor = Color.FromArgb(30, 30, 30);
        //    dgvBilgi.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
        //    dgvBilgi.DefaultCellStyle.ForeColor = Color.White;
        //    dgvBilgi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 60, 60);
        //    dgvBilgi.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgvBilgi.EnableHeadersVisualStyles = false;
        //}



        private void FillDataGridView(SystemInfo info)
        {
     
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("Property", "Bilgi");
            dataGridView1.Columns.Add("Value", "Değer");
       

            // Yeni eklenen alanlar
            dataGridView1.Rows.Add("Tarih", DateTime.Now);
            dataGridView1.Rows.Add("Kullanıcı Adı", info.UserName);
            dataGridView1.Rows.Add("Bilgisayar Adı", info.ComputerName);
            dataGridView1.Rows.Add("Kurulum Tarihi", info.InstallDate);
            dataGridView1.Rows.Add("Marka", info.Manufacturer);
            dataGridView1.Rows.Add("Model", info.Model);
            dataGridView1.Rows.Add("Seri No", info.SerialNumber);
            dataGridView1.Rows.Add("Bilgisayar Tipi", info.PCType);
            dataGridView1.Rows.Add("CPU", info.CPU);
            dataGridView1.Rows.Add("RAM", info.RAM);
            dataGridView1.Rows.Add("İşletim Sistemi", info.OSName);
            if (info.GPUs != null && info.GPUs.Count > 0)
            {
                for (int i = 0; i < info.GPUs.Count; i++)
                    dataGridView1.Rows.Add($"{i + 1}.GPU", info.GPUs[i]);
            }
            else
            {
                dataGridView1.Rows.Add("GPU", "Bilinmiyor");
            }

            if (info.Disks != null && info.Disks.Count > 0)
            {
                for (int i = 0; i < info.Disks.Count; i++)
                    dataGridView1.Rows.Add($"{i + 1}.Disk", info.Disks[i]);
            }
            else
            {
                dataGridView1.Rows.Add("Disk", "Bilinmiyor");
            }
            dataGridView1.Rows.Add("Wi-Fi", info.MAC_WiFi);
            dataGridView1.Rows.Add("Ethernet", info.MAC_Ethernet);

            dataGridView1.Rows.Add("BIOS Modu", info.BIOSMode);
            dataGridView1.Rows.Add("Secure Boot", info.SecureBoot);
            dataGridView1.Rows.Add("TPM Versiyonu", info.TPMVersion);


            //dataGridView1.Rows.Add("OS Versiyon", info.OSVersion);
            //dataGridView1.Rows.Add("Domain Tipi", info.DomainOrLocal);
 
          
         
          
            
          



        
        }

        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text Files (*.txt)|*.txt";
                sfd.FileName = $"SystemInfo_{DateTime.Now:ddMMyyyy_HHmmss}.txt";
                sfd.Title = "TXT Dosyasını Kaydet";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;
                                string key = row.Cells[0].Value?.ToString() ?? "";
                                string value = row.Cells[1].Value?.ToString() ?? "";
                                sw.WriteLine($"{key}: {value}");
                            }
                        }
                        MessageBox.Show($"Dosya başarıyla kaydedildi:\n{sfd.FileName}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportXml_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Dışa aktarılacak veri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "XML Files (*.xml)|*.xml";
                sfd.FileName = $"SystemInfo_{DateTime.Now:ddMMyyyy_HHmmss}.xml";
                sfd.Title = "XML Dosyasını Kaydet";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var doc = new System.Xml.XmlDocument();
                        var root = doc.CreateElement("SystemInfo");
                        doc.AppendChild(root);

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var item = doc.CreateElement("InfoItem");

                            var keyElem = doc.CreateElement("Key");
                            keyElem.InnerText = row.Cells[0].Value?.ToString() ?? "";
                            item.AppendChild(keyElem);

                            var valElem = doc.CreateElement("Value");
                            valElem.InnerText = row.Cells[1].Value?.ToString() ?? "";
                            item.AppendChild(valElem);

                            root.AppendChild(item);
                        }

                        doc.Save(sfd.FileName);

                        MessageBox.Show($"Dosya başarıyla kaydedildi:\n{sfd.FileName}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnLoadInfo_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Bilgiler yükleniyor...";
                var info = await SystemInfoCollector.GetSystemInfoAsync();
                FillDataGridView(info);
                lblStatus.Text = "Bilgiler yüklendi.";
                btnExport.Enabled = true;
                Logger.Log("Bilgiler yüklendi");
                //// Secure Boot durumuna göre Label rengini değiştir (isteğe bağlı)
                //if (info.SecureBoot == "Etkin")
                //    labelSecureBoot.ForeColor = Color.Green;
                //else if (info.SecureBoot == "Devre Dışı")
                //    labelSecureBoot.ForeColor = Color.Red;
                //else
                //    labelSecureBoot.ForeColor = Color.Orange;

                //labelSecureBoot.Text = $"Secure Boot: {info.SecureBoot}";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Bilgi yüklenirken hata oluştu: " + ex.Message);
                lblStatus.Text = "Hata oluştu.";
            }
        }

        public static void ExportToHtml(string filePath, Dictionary<string, string> data)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset='UTF-8'><title>Sistem Bilgisi</title></head><body>");
            sb.AppendLine("<h2>Sistem Bilgileri</h2><table border='1' cellpadding='5' cellspacing='0'>");
            sb.AppendLine("<tr><th>Özellik</th><th>Değer</th></tr>");

            foreach (var item in data)
            {
                sb.AppendLine($"<tr><td>{item.Key}</td><td>{item.Value}</td></tr>");
            }

            sb.AppendLine("</table></body></html>");
            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        public static void ExportToCsv(string filePath, Dictionary<string, string> data)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("Özellik;Değer");
                foreach (var item in data)
                {
                    writer.WriteLine($"{item.Key};{item.Value}");
                }
            }
        }

        private void ExportToTxt(string filePath, Dictionary<string, string> data)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var item in data)
                {
                    writer.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }

        public static void ExportToJson(string filePath, Dictionary<string, string> data)
        {
            var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(data);
            File.WriteAllText(filePath, json, Encoding.UTF8);
        }


        private void ExportToXml(string filePath, Dictionary<string, string> data)
        {
            var doc = new System.Xml.XmlDocument();
            var root = doc.CreateElement("SystemInfo");
            doc.AppendChild(root);

            foreach (var item in data)
            {
                var itemNode = doc.CreateElement("InfoItem");

                var keyNode = doc.CreateElement("Key");
                keyNode.InnerText = item.Key;
                itemNode.AppendChild(keyNode);

                var valueNode = doc.CreateElement("Value");
                valueNode.InnerText = item.Value;
                itemNode.AppendChild(valueNode);

                root.AppendChild(itemNode);
            }

            doc.Save(filePath);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> systemInfo = GetSystemInfoAsDictionary();
            ExportDataWithDialog(systemInfo);
            Logger.Log("Kullanıcı sistem bilgilerini dışa aktardı.");
        }


        private void ExportDataWithDialog(Dictionary<string, string> data)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Veriyi Dışa Aktar";
                saveFileDialog.Filter = "TXT Dosyası (*.txt)|*.txt|XML Dosyası (*.xml)|*.xml|HTML Dosyası (*.html)|*.html|CSV Dosyası (*.csv)|*.csv";
                saveFileDialog.FileName = $"SystemInfo_{DateTime.Now:ddMMyyyy_HHmmss}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".txt":
                                ExportToTxt(saveFileDialog.FileName, data);
                                break;
                            case ".xml":
                                ExportToXml(saveFileDialog.FileName, data);
                                break;
                            case ".html":
                                ExportToHtml(saveFileDialog.FileName, data);
                                break;
                            case ".csv":
                                ExportToCsv(saveFileDialog.FileName, data);
                                break;
                            default:
                                MessageBox.Show("Desteklenmeyen dosya uzantısı.");
                                return;
                        }

                        MessageBox.Show("Veri başarıyla dışa aktarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Dosya kaydedilirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private Dictionary<string, string> GetSystemInfoAsDictionary()
        {
            var data = new Dictionary<string, string>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string key = row.Cells[0].Value?.ToString() ?? "";
                string value = row.Cells[1].Value?.ToString() ?? "";

                // Aynı key varsa sonuna numara ekle
                if (data.ContainsKey(key))
                {
                    int i = 2;
                    string newKey;
                    do
                    {
                        newKey = $"{key} ({i++})";
                    } while (data.ContainsKey(newKey));

                    key = newKey;
                }

                data[key] = value;
            }

            return data;
        }





        //TEMA 



        private void ApplyTheme(bool isDarkTheme)
        {
            Color backColor = isDarkTheme ? Color.FromArgb(30, 30, 30) : Color.White;
            Color foreColor = isDarkTheme ? Color.White : Color.Black;
            Color boxBack = isDarkTheme ? Color.FromArgb(45, 45, 45) : Color.White;

            this.BackColor = backColor;

            foreach (Control ctrl in this.Controls)
            {
                ctrl.ForeColor = foreColor;

                if (ctrl is TextBox tb)
                {
                    tb.BackColor = boxBack;
                    tb.ForeColor = foreColor;
                }
                else if (ctrl is CheckBox cb)
                {
                    cb.BackColor = backColor;
                    cb.ForeColor = foreColor;
                }
                else if (ctrl is Button btn)
                {
                    btn.BackColor = isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                    btn.ForeColor = foreColor;
                    btn.FlatStyle = FlatStyle.Flat;
                    //btn.BackColor = isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;

                    //if (!btn.Enabled)
                    //{
                    //    btn.ForeColor = Color.White; // disabled ama yazı beyaz olsun
                    //    btn.BackColor = Color.DarkGray; // biraz daha koyu arka plan
                    //}
                    //else
                    //{
                    //    btn.ForeColor = foreColor;
                    //}

                    //btn.FlatStyle = FlatStyle.Flat;
                }

                else if (ctrl is NumericUpDown num)
                {
                    num.BackColor = boxBack;
                    num.ForeColor = foreColor;
                    num.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ListBox list)
                {
                    list.BackColor = boxBack;
                    list.ForeColor = foreColor;
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.BackgroundColor = backColor;
                    dgv.DefaultCellStyle.BackColor = boxBack;
                    dgv.DefaultCellStyle.ForeColor = foreColor;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = foreColor;
                    dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                    dgv.EnableHeadersVisualStyles = false;

                    // Okunabilirlik için pasif satır renkleri ayarlanabilir burada (opsiyonel)
                    // Pasif hücreler için CellFormatting eventi ayarlanacak, aşağıda örnek var
                }
                else if (ctrl is MenuStrip menu)
                {
                    menu.BackColor = boxBack; // MenuStrip arka plan rengini ayarlıyoruz
                    menu.ForeColor = foreColor; // MenuStrip yazı rengini ayarlıyoruz

                    // Menülerdeki her item için renkleri ayarlıyoruz
                    foreach (ToolStripMenuItem item in menu.Items)
                    {
                        item.BackColor = boxBack; // Menu öğelerinin arka plan rengini ayarlıyoruz
                        item.ForeColor = foreColor; // Menu öğelerinin yazı rengini ayarlıyoruz

                        foreach (ToolStripItem subItem in item.DropDownItems)
                        {
                            if (subItem is ToolStripMenuItem subMenuItem)
                            {
                                subMenuItem.BackColor = boxBack; // Alt menü öğelerinin arka plan rengini ayarlıyoruz
                                subMenuItem.ForeColor = foreColor; // Alt menü öğelerinin yazı rengini ayarlıyoruz
                            }
                        }
                    }

                    // Menüde açılır (drop-down) menülerde stil ve renk değişiklikleri yapmak için:
                    menu.Renderer = new ToolStripProfessionalRenderer(new CustomMenuColorTable(isDarkTheme));
                }

            }

            // Menüdeki tema seçimini ayarlıyoruz:
            darktoolStripMenuItem.Checked = isDarkTheme;
            whitetoolStripMenuItem.Checked = !isDarkTheme;
        }

        private void SetButtonDisabled(Button btn, bool disabled)
        {
            if (disabled)
            {
                btn.BackColor = Color.Gray; // koyu gri arka plan
                btn.ForeColor = Color.White; // okunur yazı
                btn.Enabled = true;          // hala etkin ama tıklanamaz yapacağız
                btn.Click -= btnExport_Click;      // örnek tıklama event’ini çıkar
                btn.Cursor = Cursors.Default;
            }
            else
            {
                btn.BackColor = Color.FromArgb(60, 60, 60); // dark theme or normal
                btn.ForeColor = Color.White;
                btn.Enabled = true;
                btn.Click += btnExport_Click;      // tekrar tıklama eventi ekle
                btn.Cursor = Cursors.Hand;
            }
        }



        // Tema durumuna göre renkleri ayarlamak için özel bir MenuColorTable oluşturuyoruz.
        public class CustomMenuColorTable : ProfessionalColorTable
        {
            private bool isDarkTheme;

            public CustomMenuColorTable(bool isDarkTheme)
            {
                this.isDarkTheme = isDarkTheme;
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return isDarkTheme ? Color.FromArgb(60, 60, 60) : Color.LightGray;
                }
            }

            public override Color MenuItemBorder
            {
                get
                {
                    return isDarkTheme ? Color.FromArgb(100, 100, 100) : Color.DarkGray;
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return isDarkTheme ? Color.FromArgb(100, 100, 100) : Color.DarkGray;
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return isDarkTheme ? Color.FromArgb(100, 100, 100) : Color.DarkGray;
                }
            }
        }



        //diller

        Dictionary<string, string> langTR = new Dictionary<string, string>
        {
            {"lblTitle", "Sistem Bilgileri"},
            {"btnExport", "Dışarı Aktar"},
            {"btnLoadInfo", "Bilgileri Getir"},
            // diğer metinler...
        };

        Dictionary<string, string> langEN = new Dictionary<string, string>
        {
            {"lblTitle", "System Information"},
            {"btnExport", "Export Save"},
            {"btnLoadInfo", "System"},
            // diğer metinler...
        };

        private void ApplyLanguage(Dictionary<string, string> lang)
        {
            lblStatus.Text = lang["lblTitle"];
            btnExport.Text = lang["btnExport"];
            btnLoadInfo.Text = lang["btnLoadInfo"];
            // diğer kontrolleri aynı şekilde...
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguage.SelectedItem.ToString() == "Türkçe")
                ApplyLanguage(langTR);
            else
                ApplyLanguage(langEN);
        }

 

        private void darktoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!darktoolStripMenuItem.Checked)
            {
                darktoolStripMenuItem.Checked = true;
                whitetoolStripMenuItem.Checked = false;

                ApplyTheme(true);
                Properties.Settings.Default.AppTheme = "dark";
                Properties.Settings.Default.Save();
            }
        }

        private void whitetoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!whitetoolStripMenuItem.Checked)
            {
                whitetoolStripMenuItem.Checked = true;
                darktoolStripMenuItem.Checked = false;

                ApplyTheme(false);
                Properties.Settings.Default.AppTheme = "light";
                Properties.Settings.Default.Save();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistem Bilgisi Uygulaması\nVersiyon: 1.0.1\nGeliştirici: Eyüp Can BALABAN", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ayarlarıSıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tüm ayarlar varsayılana dönecek. Emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                Application.Restart(); // Uygulamayı yeniden başlat
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            }
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Log("Uygulama kapatıldı.");
        }


        private void CheckForUpdate()
        {
            try
            {
                string updateUrl = "https://raw.githubusercontent.com/epbalaban01/SystemInformation/refs/heads/main/version.txt"; // URL’yi değiştir
                WebClient client = new WebClient();
                string latestVersion = client.DownloadString(updateUrl).Trim();
                string currentVersion = Application.ProductVersion;

                if (latestVersion != currentVersion)
                {
                    Logger.Log($"Yeni sürüm bulundu: {latestVersion}, mevcut: {currentVersion}");
                    DialogResult result = MessageBox.Show($"Yeni sürüm ({latestVersion}) mevcut.\nGüncellemek ister misiniz?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://github.com/kullaniciadi/repoadi/releases"); // Güncelleme linkine yönlendir
                    }
                }
                else
                {
                    Logger.Log("Uygulama güncel.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
    
}
