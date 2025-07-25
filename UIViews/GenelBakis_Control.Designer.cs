namespace TekstilScada.UI.Views
{
    partial class GenelBakis_Control
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
            this.pnlTopKpis = new System.Windows.Forms.Panel();
            this.pnlKpi3 = new System.Windows.Forms.Panel();
            this.lblKpiValue3 = new System.Windows.Forms.Label();
            this.lblKpiTitle3 = new System.Windows.Forms.Label();
            this.pnlKpi2 = new System.Windows.Forms.Panel();
            this.lblKpiValue2 = new System.Windows.Forms.Label();
            this.lblKpiTitle2 = new System.Windows.Forms.Label();
            this.pnlKpi1 = new System.Windows.Forms.Panel();
            this.lblKpiValue1 = new System.Windows.Forms.Label();
            this.lblKpiTitle1 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.formsPlotOee = new ScottPlot.WinForms.FormsPlot();
            this.dgvTopAlarms = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTopKpis.SuspendLayout();
            this.pnlKpi3.SuspendLayout();
            this.pnlKpi2.SuspendLayout();
            this.pnlKpi1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopAlarms)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopKpis
            // 
            this.pnlTopKpis.Controls.Add(this.pnlKpi3);
            this.pnlTopKpis.Controls.Add(this.pnlKpi2);
            this.pnlTopKpis.Controls.Add(this.pnlKpi1);
            this.pnlTopKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopKpis.Location = new System.Drawing.Point(10, 10);
            this.pnlTopKpis.Name = "pnlTopKpis";
            this.pnlTopKpis.Size = new System.Drawing.Size(980, 120);
            this.pnlTopKpis.TabIndex = 0;
            // 
            // pnlKpi3
            // 
            this.pnlKpi3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnlKpi3.Controls.Add(this.lblKpiValue3);
            this.pnlKpi3.Controls.Add(this.lblKpiTitle3);
            this.pnlKpi3.Location = new System.Drawing.Point(670, 10);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.Size = new System.Drawing.Size(300, 100);
            this.pnlKpi3.TabIndex = 2;
            // 
            // lblKpiValue3
            // 
            this.lblKpiValue3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiValue3.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblKpiValue3.ForeColor = System.Drawing.Color.White;
            this.lblKpiValue3.Location = new System.Drawing.Point(0, 25);
            this.lblKpiValue3.Name = "lblKpiValue3";
            this.lblKpiValue3.Size = new System.Drawing.Size(300, 75);
            this.lblKpiValue3.TabIndex = 1;
            this.lblKpiValue3.Text = "0";
            this.lblKpiValue3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiTitle3
            // 
            this.lblKpiTitle3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitle3.ForeColor = System.Drawing.Color.White;
            this.lblKpiTitle3.Location = new System.Drawing.Point(0, 0);
            this.lblKpiTitle3.Name = "lblKpiTitle3";
            this.lblKpiTitle3.Size = new System.Drawing.Size(300, 25);
            this.lblKpiTitle3.TabIndex = 0;
            this.lblKpiTitle3.Text = "AKTİF ALARM SAYISI";
            this.lblKpiTitle3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKpi2
            // 
            this.pnlKpi2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlKpi2.Controls.Add(this.lblKpiValue2);
            this.pnlKpi2.Controls.Add(this.lblKpiTitle2);
            this.pnlKpi2.Location = new System.Drawing.Point(340, 10);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.Size = new System.Drawing.Size(300, 100);
            this.pnlKpi2.TabIndex = 1;
            // 
            // lblKpiValue2
            // 
            this.lblKpiValue2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiValue2.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblKpiValue2.ForeColor = System.Drawing.Color.White;
            this.lblKpiValue2.Location = new System.Drawing.Point(0, 25);
            this.lblKpiValue2.Name = "lblKpiValue2";
            this.lblKpiValue2.Size = new System.Drawing.Size(300, 75);
            this.lblKpiValue2.TabIndex = 1;
            this.lblKpiValue2.Text = "0 %";
            this.lblKpiValue2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiTitle2
            // 
            this.lblKpiTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitle2.ForeColor = System.Drawing.Color.White;
            this.lblKpiTitle2.Location = new System.Drawing.Point(0, 0);
            this.lblKpiTitle2.Name = "lblKpiTitle2";
            this.lblKpiTitle2.Size = new System.Drawing.Size(300, 25);
            this.lblKpiTitle2.TabIndex = 0;
            this.lblKpiTitle2.Text = "ORTALAMA PERFORMANS";
            this.lblKpiTitle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlKpi1
            // 
            this.pnlKpi1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.pnlKpi1.Controls.Add(this.lblKpiValue1);
            this.pnlKpi1.Controls.Add(this.lblKpiTitle1);
            this.pnlKpi1.Location = new System.Drawing.Point(10, 10);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.Size = new System.Drawing.Size(300, 100);
            this.pnlKpi1.TabIndex = 0;
            // 
            // lblKpiValue1
            // 
            this.lblKpiValue1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpiValue1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblKpiValue1.ForeColor = System.Drawing.Color.White;
            this.lblKpiValue1.Location = new System.Drawing.Point(0, 25);
            this.lblKpiValue1.Name = "lblKpiValue1";
            this.lblKpiValue1.Size = new System.Drawing.Size(300, 75);
            this.lblKpiValue1.TabIndex = 1;
            this.lblKpiValue1.Text = "0 %";
            this.lblKpiValue1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiTitle1
            // 
            this.lblKpiTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitle1.ForeColor = System.Drawing.Color.White;
            this.lblKpiTitle1.Location = new System.Drawing.Point(0, 0);
            this.lblKpiTitle1.Name = "lblKpiTitle1";
            this.lblKpiTitle1.Size = new System.Drawing.Size(300, 25);
            this.lblKpiTitle1.TabIndex = 0;
            this.lblKpiTitle1.Text = "GENEL OEE (24 SAAT)";
            this.lblKpiTitle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(10, 130);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(980, 460);
            this.pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.formsPlotOee);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvTopAlarms);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(980, 460);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.TabIndex = 0;
            // 
            // formsPlotOee
            // 
            this.formsPlotOee.DisplayScale = 1F;
            this.formsPlotOee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlotOee.Location = new System.Drawing.Point(0, 0);
            this.formsPlotOee.Name = "formsPlotOee";
            this.formsPlotOee.Size = new System.Drawing.Size(650, 460);
            this.formsPlotOee.TabIndex = 0;
            // 
            // dgvTopAlarms
            // 
            this.dgvTopAlarms.AllowUserToAddRows = false;
            this.dgvTopAlarms.AllowUserToDeleteRows = false;
            this.dgvTopAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopAlarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopAlarms.Location = new System.Drawing.Point(0, 25);
            this.dgvTopAlarms.Name = "dgvTopAlarms";
            this.dgvTopAlarms.ReadOnly = true;
            this.dgvTopAlarms.RowHeadersVisible = false;
            this.dgvTopAlarms.RowTemplate.Height = 25;
            this.dgvTopAlarms.Size = new System.Drawing.Size(326, 435);
            this.dgvTopAlarms.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "EN ÇOK TEKRAR EDEN 5 ALARM (24 SAAT)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GenelBakis_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTopKpis);
            this.Name = "GenelBakis_Control";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.GenelBakis_Control_Load);
            this.pnlTopKpis.ResumeLayout(false);
            this.pnlKpi3.ResumeLayout(false);
            this.pnlKpi2.ResumeLayout(false);
            this.pnlKpi1.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopAlarms)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlTopKpis;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlKpi1;
        private System.Windows.Forms.Label lblKpiValue1;
        private System.Windows.Forms.Label lblKpiTitle1;
        private System.Windows.Forms.Panel pnlKpi3;
        private System.Windows.Forms.Label lblKpiValue3;
        private System.Windows.Forms.Label lblKpiTitle3;
        private System.Windows.Forms.Panel pnlKpi2;
        private System.Windows.Forms.Label lblKpiValue2;
        private System.Windows.Forms.Label lblKpiTitle2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ScottPlot.WinForms.FormsPlot formsPlotOee;
        private System.Windows.Forms.DataGridView dgvTopAlarms;
        private System.Windows.Forms.Label label1;
    }
}