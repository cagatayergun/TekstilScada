namespace TekstilScada.UI.Views
{
    partial class Raporlar_Control
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
        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.tabControlReports = new System.Windows.Forms.TabControl();
            this.tabPageAlarmReport = new System.Windows.Forms.TabPage();
            this.tabPageProductionReport = new System.Windows.Forms.TabPage();
            // YENİ: Yeni sekmeler eklendi
            this.tabPageOeeReport = new System.Windows.Forms.TabPage();
            this.tabPageTrendAnalysis = new System.Windows.Forms.TabPage();
            this.tabPageRecipeOptimization = new System.Windows.Forms.TabPage();
            this.tabControlReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlReports
            // 
            this.tabControlReports.Controls.Add(this.tabPageProductionReport);
            this.tabControlReports.Controls.Add(this.tabPageAlarmReport);
            this.tabControlReports.Controls.Add(this.tabPageOeeReport);
            this.tabControlReports.Controls.Add(this.tabPageTrendAnalysis);
            this.tabControlReports.Controls.Add(this.tabPageRecipeOptimization);
            this.tabControlReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReports.Location = new System.Drawing.Point(0, 0);
            this.tabControlReports.Name = "tabControlReports";
            this.tabControlReports.SelectedIndex = 0;
            this.tabControlReports.Size = new System.Drawing.Size(800, 600);
            this.tabControlReports.TabIndex = 0;
            // 
            // tabPageAlarmReport
            // 
            this.tabPageAlarmReport.Location = new System.Drawing.Point(4, 29);
            this.tabPageAlarmReport.Name = "tabPageAlarmReport";
            this.tabPageAlarmReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlarmReport.Size = new System.Drawing.Size(792, 567);
            this.tabPageAlarmReport.TabIndex = 0;
            this.tabPageAlarmReport.Text = "Geçmiş Alarmlar";
            this.tabPageAlarmReport.UseVisualStyleBackColor = true;
            // 
            // tabPageProductionReport
            // 
            this.tabPageProductionReport.Location = new System.Drawing.Point(4, 29);
            this.tabPageProductionReport.Name = "tabPageProductionReport";
            this.tabPageProductionReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductionReport.Size = new System.Drawing.Size(792, 567);
            this.tabPageProductionReport.TabIndex = 1;
            this.tabPageProductionReport.Text = "Üretim Raporu";
            this.tabPageProductionReport.UseVisualStyleBackColor = true;
            //
            // tabPageOeeReport
            //
            this.tabPageOeeReport.Name = "tabPageOeeReport";
            this.tabPageOeeReport.TabIndex = 2;
            this.tabPageOeeReport.Text = "OEE Raporu";
            //
            // tabPageTrendAnalysis
            //
            this.tabPageTrendAnalysis.Name = "tabPageTrendAnalysis";
            this.tabPageTrendAnalysis.TabIndex = 3;
            this.tabPageTrendAnalysis.Text = "Trend Analizi";
            //
            // tabPageRecipeOptimization
            //
            this.tabPageRecipeOptimization.Name = "tabPageRecipeOptimization";
            this.tabPageRecipeOptimization.TabIndex = 4;
            this.tabPageRecipeOptimization.Text = "Reçete Optimizasyon";
            // 
            // Raporlar_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlReports);
            this.Name = "Raporlar_Control";
            this.Size = new System.Drawing.Size(800, 600);
            this.tabControlReports.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TabControl tabControlReports;
        private System.Windows.Forms.TabPage tabPageAlarmReport;
        private System.Windows.Forms.TabPage tabPageProductionReport;
        private System.Windows.Forms.TabPage tabPageOeeReport;
        private System.Windows.Forms.TabPage tabPageTrendAnalysis;
        private System.Windows.Forms.TabPage tabPageRecipeOptimization;
    }
}