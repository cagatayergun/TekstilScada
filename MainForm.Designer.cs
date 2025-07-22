// MainForm.Designer.cs
namespace TekstilScada
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlNavigation = new Panel();
            // YENİ: Buton eklendi
            btnGenelBakis = new Button();
            btnAyarlar = new Button();
            btnRaporlar = new Button();
            btnProsesKontrol = new Button();
            btnProsesIzleme = new Button();
            pnlContent = new Panel();
            pnlNavigation.SuspendLayout();
            SuspendLayout();
            // 
            // pnlNavigation
            // 
            pnlNavigation.BackColor = Color.FromArgb(45, 52, 54);
            pnlNavigation.Controls.Add(btnAyarlar);
            pnlNavigation.Controls.Add(btnRaporlar);
            // YENİ: Buton eklendi
            pnlNavigation.Controls.Add(btnGenelBakis);
            pnlNavigation.Controls.Add(btnProsesKontrol);
            pnlNavigation.Controls.Add(btnProsesIzleme);
            pnlNavigation.Dock = DockStyle.Left;
            pnlNavigation.Location = new Point(0, 0);
            pnlNavigation.Margin = new Padding(3, 2, 3, 2);
            pnlNavigation.Name = "pnlNavigation";
            pnlNavigation.Size = new Size(175, 450);
            pnlNavigation.TabIndex = 0;
            // 
            // btnAyarlar
            // 
            btnAyarlar.Dock = DockStyle.Top;
            btnAyarlar.FlatAppearance.BorderSize = 0;
            btnAyarlar.FlatStyle = FlatStyle.Flat;
            btnAyarlar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnAyarlar.ForeColor = Color.White;
            btnAyarlar.Location = new Point(0, 135);
            btnAyarlar.Margin = new Padding(3, 2, 3, 2);
            btnAyarlar.Name = "btnAyarlar";
            btnAyarlar.Padding = new Padding(9, 0, 0, 0);
            btnAyarlar.Size = new Size(175, 45);
            btnAyarlar.TabIndex = 3;
            btnAyarlar.Text = "Ayarlar";
            btnAyarlar.TextAlign = ContentAlignment.MiddleLeft;
            btnAyarlar.UseVisualStyleBackColor = true;
            btnAyarlar.Click += btnAyarlar_Click;

            // 
            // btnGenelBakis
            // 
            btnGenelBakis.Dock = DockStyle.Top;
            btnGenelBakis.FlatAppearance.BorderSize = 0;
            btnGenelBakis.FlatStyle = FlatStyle.Flat;
            btnGenelBakis.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnGenelBakis.ForeColor = Color.White;
            btnGenelBakis.Location = new Point(0, 0);
            btnGenelBakis.Name = "btnGenelBakis";
            btnGenelBakis.Padding = new Padding(9, 0, 0, 0);
            btnGenelBakis.Size = new Size(175, 45);
            btnGenelBakis.TabIndex = 4; // Sırası en üste geldi
            btnGenelBakis.Text = "Genel Bakış";
            btnGenelBakis.TextAlign = ContentAlignment.MiddleLeft;
            btnGenelBakis.UseVisualStyleBackColor = true;
            btnGenelBakis.Click += btnGenelBakis_Click;
            // 
            // btnRaporlar
            // 
            btnRaporlar.Dock = DockStyle.Top;
            btnRaporlar.FlatAppearance.BorderSize = 0;
            btnRaporlar.FlatStyle = FlatStyle.Flat;
            btnRaporlar.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnRaporlar.ForeColor = Color.White;
            btnRaporlar.Location = new Point(0, 90);
            btnRaporlar.Margin = new Padding(3, 2, 3, 2);
            btnRaporlar.Name = "btnRaporlar";
            btnRaporlar.Padding = new Padding(9, 0, 0, 0);
            btnRaporlar.Size = new Size(175, 45);
            btnRaporlar.TabIndex = 2;
            btnRaporlar.Text = "Raporlar";
            btnRaporlar.TextAlign = ContentAlignment.MiddleLeft;
            btnRaporlar.UseVisualStyleBackColor = true;
            btnRaporlar.Click += btnRaporlar_Click;
            // 
            // btnProsesKontrol
            // 
            btnProsesKontrol.Dock = DockStyle.Top;
            btnProsesKontrol.FlatAppearance.BorderSize = 0;
            btnProsesKontrol.FlatStyle = FlatStyle.Flat;
            btnProsesKontrol.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnProsesKontrol.ForeColor = Color.White;
            btnProsesKontrol.Location = new Point(0, 45);
            btnProsesKontrol.Margin = new Padding(3, 2, 3, 2);
            btnProsesKontrol.Name = "btnProsesKontrol";
            btnProsesKontrol.Padding = new Padding(9, 0, 0, 0);
            btnProsesKontrol.Size = new Size(175, 45);
            btnProsesKontrol.TabIndex = 1;
            btnProsesKontrol.Text = "Proses Kontrol";
            btnProsesKontrol.TextAlign = ContentAlignment.MiddleLeft;
            btnProsesKontrol.UseVisualStyleBackColor = true;
            btnProsesKontrol.Click += btnProsesKontrol_Click;
            // 
            // btnProsesIzleme
            // 
            btnProsesIzleme.Dock = DockStyle.Top;
            btnProsesIzleme.FlatAppearance.BorderSize = 0;
            btnProsesIzleme.FlatStyle = FlatStyle.Flat;
            btnProsesIzleme.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnProsesIzleme.ForeColor = Color.White;
            btnProsesIzleme.Location = new Point(0, 0);
            btnProsesIzleme.Margin = new Padding(3, 2, 3, 2);
            btnProsesIzleme.Name = "btnProsesIzleme";
            btnProsesIzleme.Padding = new Padding(9, 0, 0, 0);
            btnProsesIzleme.Size = new Size(175, 45);
            btnProsesIzleme.TabIndex = 0;
            btnProsesIzleme.Text = "Proses İzleme";
            btnProsesIzleme.TextAlign = ContentAlignment.MiddleLeft;
            btnProsesIzleme.UseVisualStyleBackColor = true;
            btnProsesIzleme.Click += btnProsesIzleme_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(175, 0);
            pnlContent.Margin = new Padding(3, 2, 3, 2);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(700, 450);
            pnlContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 450);
            Controls.Add(pnlContent);
            Controls.Add(pnlNavigation);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Tekstil SCADA Sistemi";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            pnlNavigation.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnProsesKontrol;
        private System.Windows.Forms.Button btnProsesIzleme;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnGenelBakis;
    }
}