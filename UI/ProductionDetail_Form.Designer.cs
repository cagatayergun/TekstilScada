namespace TekstilScada.UI
{
    partial class ProductionDetail_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbProductionInfo = new System.Windows.Forms.GroupBox();
            this.txtTotalDuration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStopTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.tabMainDetails = new System.Windows.Forms.TabControl();
            this.tabPageSteps = new System.Windows.Forms.TabPage();
            this.dgvStepDetails = new System.Windows.Forms.DataGridView();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.tabSubDetails = new System.Windows.Forms.TabControl();
            this.tabPageAlarms = new System.Windows.Forms.TabPage();
            this.dgvAlarms = new System.Windows.Forms.DataGridView();
            this.tabPageChemicals = new System.Windows.Forms.TabPage();
            this.dgvChemicals = new System.Windows.Forms.DataGridView();
            this.pnlBottom.SuspendLayout();
            this.gbProductionInfo.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.tabMainDetails.SuspendLayout();
            this.tabPageSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStepDetails)).BeginInit();
            this.tabPageGraph.SuspendLayout();
            this.tabSubDetails.SuspendLayout();
            this.tabPageAlarms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).BeginInit();
            this.tabPageChemicals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChemicals)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnExportToExcel);
            this.pnlBottom.Controls.Add(this.btnClose);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 689);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1244, 50);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExportToExcel.Location = new System.Drawing.Point(990, 10);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(120, 30);
            this.btnExportToExcel.TabIndex = 1;
            this.btnExportToExcel.Text = "Excel\'e Aktar";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(1116, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbProductionInfo
            // 
            this.gbProductionInfo.Controls.Add(this.txtTotalDuration);
            this.gbProductionInfo.Controls.Add(this.label6);
            this.gbProductionInfo.Controls.Add(this.txtStopTime);
            this.gbProductionInfo.Controls.Add(this.label5);
            this.gbProductionInfo.Controls.Add(this.txtStartTime);
            this.gbProductionInfo.Controls.Add(this.label4);
            this.gbProductionInfo.Controls.Add(this.txtCustomerNo);
            this.gbProductionInfo.Controls.Add(this.label8);
            this.gbProductionInfo.Controls.Add(this.txtOrderNo);
            this.gbProductionInfo.Controls.Add(this.label7);
            this.gbProductionInfo.Controls.Add(this.txtOperator);
            this.gbProductionInfo.Controls.Add(this.label3);
            this.gbProductionInfo.Controls.Add(this.txtRecipeName);
            this.gbProductionInfo.Controls.Add(this.label2);
            this.gbProductionInfo.Controls.Add(this.txtMachineName);
            this.gbProductionInfo.Controls.Add(this.label1);
            this.gbProductionInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbProductionInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbProductionInfo.Location = new System.Drawing.Point(10, 10);
            this.gbProductionInfo.Name = "gbProductionInfo";
            this.gbProductionInfo.Padding = new System.Windows.Forms.Padding(10);
            this.gbProductionInfo.Size = new System.Drawing.Size(350, 679);
            this.gbProductionInfo.TabIndex = 1;
            this.gbProductionInfo.TabStop = false;
            this.gbProductionInfo.Text = "Üretim Özeti";
            // 
            // txtTotalDuration
            // 
            this.txtTotalDuration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTotalDuration.Location = new System.Drawing.Point(13, 407);
            this.txtTotalDuration.Name = "txtTotalDuration";
            this.txtTotalDuration.ReadOnly = true;
            this.txtTotalDuration.Size = new System.Drawing.Size(324, 27);
            this.txtTotalDuration.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Toplam Süre:";
            // 
            // txtStopTime
            // 
            this.txtStopTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStopTime.Location = new System.Drawing.Point(13, 345);
            this.txtStopTime.Name = "txtStopTime";
            this.txtStopTime.ReadOnly = true;
            this.txtStopTime.Size = new System.Drawing.Size(324, 27);
            this.txtStopTime.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bitiş Tarihi:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtStartTime.Location = new System.Drawing.Point(13, 283);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.ReadOnly = true;
            this.txtStartTime.Size = new System.Drawing.Size(324, 27);
            this.txtStartTime.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Başlangıç Tarihi:";
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCustomerNo.Location = new System.Drawing.Point(13, 221);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.ReadOnly = true;
            this.txtCustomerNo.Size = new System.Drawing.Size(324, 27);
            this.txtCustomerNo.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(13, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Müşteri No:";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOrderNo.Location = new System.Drawing.Point(13, 159);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(324, 27);
            this.txtOrderNo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(13, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sipariş No:";
            // 
            // txtOperator
            // 
            this.txtOperator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtOperator.Location = new System.Drawing.Point(13, 107);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.ReadOnly = true;
            this.txtOperator.Size = new System.Drawing.Size(324, 27);
            this.txtOperator.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Operatör:";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRecipeName.Location = new System.Drawing.Point(13, 54);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.ReadOnly = true;
            this.txtRecipeName.Size = new System.Drawing.Size(324, 27);
            this.txtRecipeName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Reçete Adı:";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMachineName.Location = new System.Drawing.Point(13, 54);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.ReadOnly = true;
            this.txtMachineName.Size = new System.Drawing.Size(324, 27);
            this.txtMachineName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Makine Adı:";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.splitContainerMain);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(360, 10);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(894, 679);
            this.pnlMainContent.TabIndex = 2;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.tabMainDetails);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabSubDetails);
            this.splitContainerMain.Size = new System.Drawing.Size(894, 679);
            this.splitContainerMain.SplitterDistance = 450;
            this.splitContainerMain.TabIndex = 0;
            // 
            // tabMainDetails
            // 
            this.tabMainDetails.Controls.Add(this.tabPageSteps);
            this.tabMainDetails.Controls.Add(this.tabPageGraph);
            this.tabMainDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainDetails.Location = new System.Drawing.Point(0, 0);
            this.tabMainDetails.Name = "tabMainDetails";
            this.tabMainDetails.SelectedIndex = 0;
            this.tabMainDetails.Size = new System.Drawing.Size(894, 450);
            this.tabMainDetails.TabIndex = 0;
            // 
            // tabPageSteps
            // 
            this.tabPageSteps.Controls.Add(this.dgvStepDetails);
            this.tabPageSteps.Location = new System.Drawing.Point(4, 29);
            this.tabPageSteps.Name = "tabPageSteps";
            this.tabPageSteps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSteps.Size = new System.Drawing.Size(886, 417);
            this.tabPageSteps.TabIndex = 0;
            this.tabPageSteps.Text = "Adım Detayları";
            this.tabPageSteps.UseVisualStyleBackColor = true;
            // 
            // dgvStepDetails
            // 
            this.dgvStepDetails.AllowUserToAddRows = false;
            this.dgvStepDetails.AllowUserToDeleteRows = false;
            this.dgvStepDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStepDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStepDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStepDetails.Location = new System.Drawing.Point(3, 3);
            this.dgvStepDetails.Name = "dgvStepDetails";
            this.dgvStepDetails.ReadOnly = true;
            this.dgvStepDetails.RowHeadersWidth = 51;
            this.dgvStepDetails.RowTemplate.Height = 29;
            this.dgvStepDetails.Size = new System.Drawing.Size(880, 411);
            this.dgvStepDetails.TabIndex = 0;
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.Controls.Add(this.formsPlot1);
            this.tabPageGraph.Location = new System.Drawing.Point(4, 29);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraph.Size = new System.Drawing.Size(886, 417);
            this.tabPageGraph.TabIndex = 1;
            this.tabPageGraph.Text = "Proses Grafiği";
            this.tabPageGraph.UseVisualStyleBackColor = true;
            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(3, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(880, 411);
            this.formsPlot1.TabIndex = 0;
            // 
            // tabSubDetails
            // 
            this.tabSubDetails.Controls.Add(this.tabPageAlarms);
            this.tabSubDetails.Controls.Add(this.tabPageChemicals);
            this.tabSubDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSubDetails.Location = new System.Drawing.Point(0, 0);
            this.tabSubDetails.Name = "tabSubDetails";
            this.tabSubDetails.SelectedIndex = 0;
            this.tabSubDetails.Size = new System.Drawing.Size(894, 225);
            this.tabSubDetails.TabIndex = 0;
            // 
            // tabPageAlarms
            // 
            this.tabPageAlarms.Controls.Add(this.dgvAlarms);
            this.tabPageAlarms.Location = new System.Drawing.Point(4, 29);
            this.tabPageAlarms.Name = "tabPageAlarms";
            this.tabPageAlarms.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAlarms.Size = new System.Drawing.Size(886, 192);
            this.tabPageAlarms.TabIndex = 0;
            this.tabPageAlarms.Text = "Proses Alarmları";
            this.tabPageAlarms.UseVisualStyleBackColor = true;
            // 
            // dgvAlarms
            // 
            this.dgvAlarms.AllowUserToAddRows = false;
            this.dgvAlarms.AllowUserToDeleteRows = false;
            this.dgvAlarms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlarms.Location = new System.Drawing.Point(3, 3);
            this.dgvAlarms.Name = "dgvAlarms";
            this.dgvAlarms.ReadOnly = true;
            this.dgvAlarms.RowHeadersWidth = 51;
            this.dgvAlarms.RowTemplate.Height = 29;
            this.dgvAlarms.Size = new System.Drawing.Size(880, 186);
            this.dgvAlarms.TabIndex = 0;
            // 
            // tabPageChemicals
            // 
            this.tabPageChemicals.Controls.Add(this.dgvChemicals);
            this.tabPageChemicals.Location = new System.Drawing.Point(4, 29);
            this.tabPageChemicals.Name = "tabPageChemicals";
            this.tabPageChemicals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChemicals.Size = new System.Drawing.Size(886, 192);
            this.tabPageChemicals.TabIndex = 1;
            this.tabPageChemicals.Text = "Kimyasal Tüketimi";
            this.tabPageChemicals.UseVisualStyleBackColor = true;
            // 
            // dgvChemicals
            // 
            this.dgvChemicals.AllowUserToAddRows = false;
            this.dgvChemicals.AllowUserToDeleteRows = false;
            this.dgvChemicals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChemicals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChemicals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChemicals.Location = new System.Drawing.Point(3, 3);
            this.dgvChemicals.Name = "dgvChemicals";
            this.dgvChemicals.ReadOnly = true;
            this.dgvChemicals.RowHeadersWidth = 51;
            this.dgvChemicals.RowTemplate.Height = 29;
            this.dgvChemicals.Size = new System.Drawing.Size(880, 186);
            this.dgvChemicals.TabIndex = 0;
            // 
            // ProductionDetail_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 749);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.gbProductionInfo);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "ProductionDetail_Form";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üretim Raporu Detayı";
            this.Load += new System.EventHandler(this.ProductionDetail_Form_Load);
            this.pnlBottom.ResumeLayout(false);
            this.gbProductionInfo.ResumeLayout(false);
            this.gbProductionInfo.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.tabMainDetails.ResumeLayout(false);
            this.tabPageSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStepDetails)).EndInit();
            this.tabPageGraph.ResumeLayout(false);
            this.tabSubDetails.ResumeLayout(false);
            this.tabPageAlarms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarms)).EndInit();
            this.tabPageChemicals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChemicals)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbProductionInfo;
        private System.Windows.Forms.TextBox txtTotalDuration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStopTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TabControl tabMainDetails;
        private System.Windows.Forms.TabPage tabPageSteps;
        private System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.TabControl tabSubDetails;
        private System.Windows.Forms.TabPage tabPageAlarms;
        private System.Windows.Forms.TabPage tabPageChemicals;
        private System.Windows.Forms.DataGridView dgvStepDetails;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.DataGridView dgvAlarms;
        private System.Windows.Forms.DataGridView dgvChemicals;
    }
}


//Bu kod, formunuzu daha modern ve kullanışlı bir hale getirecektir. Veri yoğunluğunu sekmelerle yöneterek her bir bilginin daha rahat incelenmesini sağl