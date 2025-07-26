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
            pnlFilters = new Panel();
            btnGenerateChart = new Button();
            groupBox2 = new GroupBox();
            chkRpm = new CheckBox();
            chkWaterLevel = new CheckBox();
            chkTemperature = new CheckBox();
            groupBox1 = new GroupBox();
            clbMachines = new CheckedListBox();
            dtpEndTime = new DateTimePicker();
            label2 = new Label();
            dtpStartTime = new DateTimePicker();
            label1 = new Label();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            pnlFilters.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.Controls.Add(btnGenerateChart);
            pnlFilters.Controls.Add(groupBox2);
            pnlFilters.Controls.Add(groupBox1);
            pnlFilters.Controls.Add(dtpEndTime);
            pnlFilters.Controls.Add(label2);
            pnlFilters.Controls.Add(dtpStartTime);
            pnlFilters.Controls.Add(label1);
            pnlFilters.Dock = DockStyle.Left;
            pnlFilters.Location = new Point(0, 0);
            pnlFilters.Margin = new Padding(3, 2, 3, 2);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(219, 507);
            pnlFilters.TabIndex = 0;
            // 
            // btnGenerateChart
            // 
            btnGenerateChart.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            btnGenerateChart.Location = new Point(12, 443);
            btnGenerateChart.Margin = new Padding(3, 2, 3, 2);
            btnGenerateChart.Name = "btnGenerateChart";
            btnGenerateChart.Size = new Size(192, 30);
            btnGenerateChart.TabIndex = 6;
            btnGenerateChart.Text = "Grafiği Oluştur";
            btnGenerateChart.UseVisualStyleBackColor = true;
            btnGenerateChart.Click += btnGenerateChart_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkRpm);
            groupBox2.Controls.Add(chkWaterLevel);
            groupBox2.Controls.Add(chkTemperature);
            groupBox2.Location = new Point(12, 313);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(192, 111);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Görüntülenecek Veriler";
            // 
            // chkRpm
            // 
            chkRpm.AutoSize = true;
            chkRpm.Location = new Point(13, 69);
            chkRpm.Margin = new Padding(3, 2, 3, 2);
            chkRpm.Name = "chkRpm";
            chkRpm.Size = new Size(53, 19);
            chkRpm.TabIndex = 2;
            chkRpm.Text = "Devir";
            chkRpm.UseVisualStyleBackColor = true;
            // 
            // chkWaterLevel
            // 
            chkWaterLevel.AutoSize = true;
            chkWaterLevel.Location = new Point(13, 47);
            chkWaterLevel.Margin = new Padding(3, 2, 3, 2);
            chkWaterLevel.Name = "chkWaterLevel";
            chkWaterLevel.Size = new Size(83, 19);
            chkWaterLevel.TabIndex = 1;
            chkWaterLevel.Text = "Su Seviyesi";
            chkWaterLevel.UseVisualStyleBackColor = true;
            // 
            // chkTemperature
            // 
            chkTemperature.AutoSize = true;
            chkTemperature.Checked = true;
            chkTemperature.CheckState = CheckState.Checked;
            chkTemperature.Location = new Point(13, 24);
            chkTemperature.Margin = new Padding(3, 2, 3, 2);
            chkTemperature.Name = "chkTemperature";
            chkTemperature.Size = new Size(65, 19);
            chkTemperature.TabIndex = 0;
            chkTemperature.Text = "Sıcaklık";
            chkTemperature.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(clbMachines);
            groupBox1.Location = new Point(12, 103);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(192, 202);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Makineler";
            // 
            // clbMachines
            // 
            clbMachines.Dock = DockStyle.Fill;
            clbMachines.FormattingEnabled = true;
            clbMachines.Location = new Point(3, 18);
            clbMachines.Margin = new Padding(3, 2, 3, 2);
            clbMachines.Name = "clbMachines";
            clbMachines.Size = new Size(186, 182);
            clbMachines.TabIndex = 0;
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(12, 78);
            dtpEndTime.Margin = new Padding(3, 2, 3, 2);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.Size = new Size(193, 23);
            dtpEndTime.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Bitiş Tarihi:";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(12, 38);
            dtpStartTime.Margin = new Padding(3, 2, 3, 2);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.Size = new Size(193, 23);
            dtpStartTime.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Başlangıç Tarihi:";
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Dock = DockStyle.Fill;
            formsPlot1.Location = new Point(219, 0);
            formsPlot1.Margin = new Padding(3, 2, 3, 2);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(569, 507);
            formsPlot1.TabIndex = 1;
            // 
            // TrendAnaliz_Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(formsPlot1);
            Controls.Add(pnlFilters);
            Margin = new Padding(3, 2, 3, 2);
            Name = "TrendAnaliz_Control";
            Size = new Size(788, 507);
            Load += TrendAnaliz_Control_Load;
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
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