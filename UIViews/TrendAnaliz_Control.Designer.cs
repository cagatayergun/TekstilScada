namespace TekstilScada.UI.Views
{
    partial class TrendAnaliz_Control
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Component Designer generated code // HATA GİDERİLDİ: Bu satır eklendi

        private void InitializeComponent()
        {
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnGenerateChart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkRpm = new System.Windows.Forms.CheckBox();
            this.chkWaterLevel = new System.Windows.Forms.CheckBox();
            this.chkTemperature = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clbMachines = new System.Windows.Forms.CheckedListBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.pnlFilters.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnGenerateChart);
            this.pnlFilters.Controls.Add(this.groupBox2);
            this.pnlFilters.Controls.Add(this.groupBox1);
            this.pnlFilters.Controls.Add(this.dtpEndTime);
            this.pnlFilters.Controls.Add(this.label2);
            this.pnlFilters.Controls.Add(this.dtpStartTime);
            this.pnlFilters.Controls.Add(this.label1);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(250, 600);
            this.pnlFilters.TabIndex = 0;
            // 
            // btnGenerateChart
            // 
            this.btnGenerateChart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnGenerateChart.Location = new System.Drawing.Point(14, 550);
            this.btnGenerateChart.Name = "btnGenerateChart";
            this.btnGenerateChart.Size = new System.Drawing.Size(220, 40);
            this.btnGenerateChart.TabIndex = 6;
            this.btnGenerateChart.Text = "Grafiği Oluştur";
            this.btnGenerateChart.UseVisualStyleBackColor = true;
            this.btnGenerateChart.Click += new System.EventHandler(this.btnGenerateChart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkRpm);
            this.groupBox2.Controls.Add(this.chkWaterLevel);
            this.groupBox2.Controls.Add(this.chkTemperature);
            this.groupBox2.Location = new System.Drawing.Point(14, 380);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 150);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Görüntülenecek Veriler";
            // 
            // chkRpm
            // 
            this.chkRpm.AutoSize = true;
            this.chkRpm.Location = new System.Drawing.Point(15, 95);
            this.chkRpm.Name = "chkRpm";
            this.chkRpm.Size = new System.Drawing.Size(65, 24);
            this.chkRpm.TabIndex = 2;
            this.chkRpm.Text = "Devir";
            this.chkRpm.UseVisualStyleBackColor = true;
            // 
            // chkWaterLevel
            // 
            this.chkWaterLevel.AutoSize = true;
            this.chkWaterLevel.Location = new System.Drawing.Point(15, 65);
            this.chkWaterLevel.Name = "chkWaterLevel";
            this.chkWaterLevel.Size = new System.Drawing.Size(102, 24);
            this.chkWaterLevel.TabIndex = 1;
            this.chkWaterLevel.Text = "Su Seviyesi";
            this.chkWaterLevel.UseVisualStyleBackColor = true;
            // 
            // chkTemperature
            // 
            this.chkTemperature.AutoSize = true;
            this.chkTemperature.Checked = true;
            this.chkTemperature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTemperature.Location = new System.Drawing.Point(15, 35);
            this.chkTemperature.Name = "chkTemperature";
            this.chkTemperature.Size = new System.Drawing.Size(81, 24);
            this.chkTemperature.TabIndex = 0;
            this.chkTemperature.Text = "Sıcaklık";
            this.chkTemperature.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clbMachines);
            this.groupBox1.Location = new System.Drawing.Point(14, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 270);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Makineler";
            // 
            // clbMachines
            // 
            this.clbMachines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbMachines.FormattingEnabled = true;
            this.clbMachines.Location = new System.Drawing.Point(3, 23);
            this.clbMachines.Name = "clbMachines";
            this.clbMachines.Size = new System.Drawing.Size(214, 244);
            this.clbMachines.TabIndex = 0;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(14, 67);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(220, 27);
            this.dtpEndTime.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bitiş Tarihi:";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(14, 14);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(220, 27);
            this.dtpStartTime.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, -13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç Tarihi:";
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(250, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(650, 600);
            this.formsPlot1.TabIndex = 1;
            // 
            // TrendAnaliz_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.pnlFilters);
            this.Name = "TrendAnaliz_Control";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.TrendAnaliz_Control_Load);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Button btnGenerateChart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label1;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.CheckedListBox clbMachines;
        private System.Windows.Forms.CheckBox chkRpm;
        private System.Windows.Forms.CheckBox chkWaterLevel;
        private System.Windows.Forms.CheckBox chkTemperature;
    }
}