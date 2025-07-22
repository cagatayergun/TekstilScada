// UI/Views/MakineDetay_Control.Designer.cs
namespace TekstilScada.UI.Views
{
    partial class MakineDetay_Control
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnGeri = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblSiparisNo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBatchNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMusteriNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblOperator = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReceteAdi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMakineAdi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlGauges = new System.Windows.Forms.Panel();
            this.lblWaterValue = new System.Windows.Forms.Label();
            this.lblWaterTitle = new System.Windows.Forms.Label();
            this.lblTempValue = new System.Windows.Forms.Label();
            this.lblTempTitle = new System.Windows.Forms.Label();
            this.lblRpmValue = new System.Windows.Forms.Label();
            this.lblRpmTitle = new System.Windows.Forms.Label();
            this.pnlTimeline = new System.Windows.Forms.Panel();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.pnlTop.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlGauges.SuspendLayout();
            this.pnlTimeline.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnGeri);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 50);
            this.pnlTop.TabIndex = 0;
            // 
            // btnGeri
            // 
            this.btnGeri.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGeri.Location = new System.Drawing.Point(15, 10);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(94, 29);
            this.btnGeri.TabIndex = 0;
            this.btnGeri.Text = "< GERİ";
            this.btnGeri.UseVisualStyleBackColor = true;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInfo.Controls.Add(this.lblSiparisNo);
            this.pnlInfo.Controls.Add(this.label6);
            this.pnlInfo.Controls.Add(this.lblBatchNo);
            this.pnlInfo.Controls.Add(this.label5);
            this.pnlInfo.Controls.Add(this.lblMusteriNo);
            this.pnlInfo.Controls.Add(this.label4);
            this.pnlInfo.Controls.Add(this.lblOperator);
            this.pnlInfo.Controls.Add(this.label3);
            this.pnlInfo.Controls.Add(this.lblReceteAdi);
            this.pnlInfo.Controls.Add(this.label2);
            this.pnlInfo.Controls.Add(this.lblMakineAdi);
            this.pnlInfo.Controls.Add(this.label1);
            this.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInfo.Location = new System.Drawing.Point(0, 50);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(1000, 150);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblSiparisNo
            // 
            this.lblSiparisNo.AutoSize = true;
            this.lblSiparisNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSiparisNo.Location = new System.Drawing.Point(500, 110);
            this.lblSiparisNo.Name = "lblSiparisNo";
            this.lblSiparisNo.Size = new System.Drawing.Size(27, 23);
            this.lblSiparisNo.TabIndex = 11;
            this.lblSiparisNo.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(380, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Sipariş No:";
            // 
            // lblBatchNo
            // 
            this.lblBatchNo.AutoSize = true;
            this.lblBatchNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBatchNo.Location = new System.Drawing.Point(500, 80);
            this.lblBatchNo.Name = "lblBatchNo";
            this.lblBatchNo.Size = new System.Drawing.Size(27, 23);
            this.lblBatchNo.TabIndex = 9;
            this.lblBatchNo.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(380, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Batch No:";
            // 
            // lblMusteriNo
            // 
            this.lblMusteriNo.AutoSize = true;
            this.lblMusteriNo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMusteriNo.Location = new System.Drawing.Point(500, 50);
            this.lblMusteriNo.Name = "lblMusteriNo";
            this.lblMusteriNo.Size = new System.Drawing.Size(27, 23);
            this.lblMusteriNo.TabIndex = 7;
            this.lblMusteriNo.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(380, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Müşteri No:";
            // 
            // lblOperator
            // 
            this.lblOperator.AutoSize = true;
            this.lblOperator.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOperator.Location = new System.Drawing.Point(130, 80);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(27, 23);
            this.lblOperator.TabIndex = 5;
            this.lblOperator.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operatör:";
            // 
            // lblReceteAdi
            // 
            this.lblReceteAdi.AutoSize = true;
            this.lblReceteAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblReceteAdi.Location = new System.Drawing.Point(130, 50);
            this.lblReceteAdi.Name = "lblReceteAdi";
            this.lblReceteAdi.Size = new System.Drawing.Size(27, 23);
            this.lblReceteAdi.TabIndex = 3;
            this.lblReceteAdi.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reçete Adı:";
            // 
            // lblMakineAdi
            // 
            this.lblMakineAdi.AutoSize = true;
            this.lblMakineAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMakineAdi.Location = new System.Drawing.Point(130, 10);
            this.lblMakineAdi.Name = "lblMakineAdi";
            this.lblMakineAdi.Size = new System.Drawing.Size(35, 28);
            this.lblMakineAdi.TabIndex = 1;
            this.lblMakineAdi.Text = "---";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Makine Adı:";
            // 
            // pnlGauges
            // 
            this.pnlGauges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGauges.Controls.Add(this.lblWaterValue);
            this.pnlGauges.Controls.Add(this.lblWaterTitle);
            this.pnlGauges.Controls.Add(this.lblTempValue);
            this.pnlGauges.Controls.Add(this.lblTempTitle);
            this.pnlGauges.Controls.Add(this.lblRpmValue);
            this.pnlGauges.Controls.Add(this.lblRpmTitle);
            this.pnlGauges.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGauges.Location = new System.Drawing.Point(0, 200);
            this.pnlGauges.Name = "pnlGauges";
            this.pnlGauges.Size = new System.Drawing.Size(300, 400);
            this.pnlGauges.TabIndex = 2;
            // 
            // lblWaterValue
            // 
            this.lblWaterValue.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWaterValue.Location = new System.Drawing.Point(15, 290);
            this.lblWaterValue.Name = "lblWaterValue";
            this.lblWaterValue.Size = new System.Drawing.Size(265, 31);
            this.lblWaterValue.TabIndex = 5;
            this.lblWaterValue.Text = "0";
            this.lblWaterValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWaterTitle
            // 
            this.lblWaterTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWaterTitle.Location = new System.Drawing.Point(15, 260);
            this.lblWaterTitle.Name = "lblWaterTitle";
            this.lblWaterTitle.Size = new System.Drawing.Size(265, 23);
            this.lblWaterTitle.TabIndex = 4;
            this.lblWaterTitle.Text = "SU SEVİYESİ (LT)";
            this.lblWaterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTempValue
            // 
            this.lblTempValue.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTempValue.Location = new System.Drawing.Point(15, 180);
            this.lblTempValue.Name = "lblTempValue";
            this.lblTempValue.Size = new System.Drawing.Size(265, 31);
            this.lblTempValue.TabIndex = 3;
            this.lblTempValue.Text = "0";
            this.lblTempValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTempTitle
            // 
            this.lblTempTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTempTitle.Location = new System.Drawing.Point(15, 150);
            this.lblTempTitle.Name = "lblTempTitle";
            this.lblTempTitle.Size = new System.Drawing.Size(265, 23);
            this.lblTempTitle.TabIndex = 2;
            this.lblTempTitle.Text = "SICAKLIK (°C)";
            this.lblTempTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRpmValue
            // 
            this.lblRpmValue.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRpmValue.Location = new System.Drawing.Point(15, 70);
            this.lblRpmValue.Name = "lblRpmValue";
            this.lblRpmValue.Size = new System.Drawing.Size(265, 31);
            this.lblRpmValue.TabIndex = 1;
            this.lblRpmValue.Text = "0";
            this.lblRpmValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRpmTitle
            // 
            this.lblRpmTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRpmTitle.Location = new System.Drawing.Point(15, 40);
            this.lblRpmTitle.Name = "lblRpmTitle";
            this.lblRpmTitle.Size = new System.Drawing.Size(265, 23);
            this.lblRpmTitle.TabIndex = 0;
            this.lblRpmTitle.Text = "DEVİR (RPM)";
            this.lblRpmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTimeline
            // 
            this.pnlTimeline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTimeline.Controls.Add(this.formsPlot1);
            this.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTimeline.Location = new System.Drawing.Point(300, 200);
            this.pnlTimeline.Name = "pnlTimeline";
            this.pnlTimeline.Size = new System.Drawing.Size(700, 400);
            this.pnlTimeline.TabIndex = 3;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(698, 398);
            this.formsPlot1.TabIndex = 0;
            // 
            // MakineDetay_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlTimeline);
            this.Controls.Add(this.pnlGauges);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlTop);
            this.Name = "MakineDetay_Control";
            this.Size = new System.Drawing.Size(1000, 600);
            this.pnlTop.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlGauges.ResumeLayout(false);
            this.pnlGauges.PerformLayout();
            this.pnlTimeline.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblSiparisNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBatchNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMusteriNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblReceteAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMakineAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlGauges;
        private System.Windows.Forms.Panel pnlTimeline;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.Label lblRpmTitle;
        private System.Windows.Forms.Label lblRpmValue;
        private System.Windows.Forms.Label lblTempTitle;
        private System.Windows.Forms.Label lblTempValue;
        private System.Windows.Forms.Label lblWaterTitle;
        private System.Windows.Forms.Label lblWaterValue;
    }
}
