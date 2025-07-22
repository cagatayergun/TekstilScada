// UI/FtpSync_Form.Designer.cs
namespace TekstilScada.UI
{
    partial class FtpSync_Form
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.cmbMachines = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstLocalRecipes = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.btnGetFromHmi = new System.Windows.Forms.Button();
            this.btnSendToHmi = new System.Windows.Forms.Button();
            this.lstHmiRecipes = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRefreshHmiList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cmbMachines);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(982, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // cmbMachines
            // 
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.FormattingEnabled = true;
            this.cmbMachines.Location = new System.Drawing.Point(143, 16);
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(350, 28);
            this.cmbMachines.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Makineyi Seçiniz:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(982, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 20);
            this.lblStatus.Text = "Hazır.";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 18);
            this.progressBar.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstLocalRecipes);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMiddle);
            this.splitContainer1.Panel2.Controls.Add(this.lstHmiRecipes);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(982, 467);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 2;
            // 
            // lstLocalRecipes
            // 
            this.lstLocalRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLocalRecipes.FormattingEnabled = true;
            this.lstLocalRecipes.ItemHeight = 20;
            this.lstLocalRecipes.Location = new System.Drawing.Point(5, 45);
            this.lstLocalRecipes.Name = "lstLocalRecipes";
            this.lstLocalRecipes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstLocalRecipes.Size = new System.Drawing.Size(390, 417);
            this.lstLocalRecipes.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 40);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "SCADA Kayıtlı Reçeteler";
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.btnGetFromHmi);
            this.pnlMiddle.Controls.Add(this.btnSendToHmi);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMiddle.Location = new System.Drawing.Point(405, 45);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(150, 417);
            this.pnlMiddle.TabIndex = 2;
            // 
            // btnGetFromHmi
            // 
            this.btnGetFromHmi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetFromHmi.Location = new System.Drawing.Point(25, 220);
            this.btnGetFromHmi.Name = "btnGetFromHmi";
            this.btnGetFromHmi.Size = new System.Drawing.Size(100, 50);
            this.btnGetFromHmi.TabIndex = 1;
            this.btnGetFromHmi.Text = "<< Al";
            this.btnGetFromHmi.UseVisualStyleBackColor = true;
            // 
            // btnSendToHmi
            // 
            this.btnSendToHmi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSendToHmi.Location = new System.Drawing.Point(25, 150);
            this.btnSendToHmi.Name = "btnSendToHmi";
            this.btnSendToHmi.Size = new System.Drawing.Size(100, 50);
            this.btnSendToHmi.TabIndex = 0;
            this.btnSendToHmi.Text = "Gönder >>";
            this.btnSendToHmi.UseVisualStyleBackColor = true;
            // 
            // lstHmiRecipes
            // 
            this.lstHmiRecipes.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstHmiRecipes.FormattingEnabled = true;
            this.lstHmiRecipes.ItemHeight = 20;
            this.lstHmiRecipes.Location = new System.Drawing.Point(5, 45);
            this.lstHmiRecipes.Name = "lstHmiRecipes";
            this.lstHmiRecipes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstHmiRecipes.Size = new System.Drawing.Size(400, 417);
            this.lstHmiRecipes.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRefreshHmiList);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 40);
            this.panel2.TabIndex = 0;
            // 
            // btnRefreshHmiList
            // 
            this.btnRefreshHmiList.Location = new System.Drawing.Point(296, 5);
            this.btnRefreshHmiList.Name = "btnRefreshHmiList";
            this.btnRefreshHmiList.Size = new System.Drawing.Size(94, 29);
            this.btnRefreshHmiList.TabIndex = 1;
            this.btnRefreshHmiList.Text = "Yenile";
            this.btnRefreshHmiList.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "HMI Reçete Dosyaları";
            // 
            // FtpSync_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FtpSync_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FTP ile Reçete Senkronizasyonu";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cmbMachines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstLocalRecipes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstHmiRecipes;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Button btnGetFromHmi;
        private System.Windows.Forms.Button btnSendToHmi;
        private System.Windows.Forms.Button btnRefreshHmiList;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}
