﻿// UI/Views/ProsesKontrol_Control.Designer.cs
namespace TekstilScada.UI.Views
{
    partial class ProsesKontrol_Control
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
            splitContainer1 = new SplitContainer();
            lstRecipes = new ListBox();
            panel1 = new Panel();
            btnDeleteRecipe = new Button();
            btnNewRecipe = new Button();
            label1 = new Label();
            pnlEditorArea = new Panel();
            panel2 = new Panel();
            btnFtpSync = new Button();
            cmbTargetMachine = new ComboBox();
            label4 = new Label();
            btnReadFromPlc = new Button();
            btnSendToPlc = new Button();
            btnSaveRecipe = new Button();
            txtRecipeName = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lstRecipes);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnlEditorArea);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1003, 448);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // lstRecipes
            // 
            lstRecipes.Dock = DockStyle.Fill;
            lstRecipes.FormattingEnabled = true;
            lstRecipes.ItemHeight = 15;
            lstRecipes.Location = new Point(0, 22);
            lstRecipes.Margin = new Padding(3, 2, 3, 2);
            lstRecipes.Name = "lstRecipes";
            lstRecipes.Size = new Size(250, 388);
            lstRecipes.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnDeleteRecipe);
            panel1.Controls.Add(btnNewRecipe);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 410);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 38);
            panel1.TabIndex = 2;
            // 
            // btnDeleteRecipe
            // 
            btnDeleteRecipe.Location = new Point(114, 8);
            btnDeleteRecipe.Margin = new Padding(3, 2, 3, 2);
            btnDeleteRecipe.Name = "btnDeleteRecipe";
            btnDeleteRecipe.Size = new Size(82, 22);
            btnDeleteRecipe.TabIndex = 1;
            btnDeleteRecipe.Text = "Sil";
            btnDeleteRecipe.UseVisualStyleBackColor = true;
            // 
            // btnNewRecipe
            // 
            btnNewRecipe.Location = new Point(18, 8);
            btnNewRecipe.Margin = new Padding(3, 2, 3, 2);
            btnNewRecipe.Name = "btnNewRecipe";
            btnNewRecipe.Size = new Size(82, 22);
            btnNewRecipe.TabIndex = 0;
            btnNewRecipe.Text = "Yeni";
            btnNewRecipe.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(250, 22);
            label1.TabIndex = 0;
            label1.Text = "Kayıtlı Reçeteler";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEditorArea
            // 
            pnlEditorArea.Dock = DockStyle.Fill;
            pnlEditorArea.Location = new Point(0, 60);
            pnlEditorArea.Margin = new Padding(3, 2, 3, 2);
            pnlEditorArea.Name = "pnlEditorArea";
            pnlEditorArea.Size = new Size(749, 388);
            pnlEditorArea.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnFtpSync);
            panel2.Controls.Add(cmbTargetMachine);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnReadFromPlc);
            panel2.Controls.Add(btnSendToPlc);
            panel2.Controls.Add(btnSaveRecipe);
            panel2.Controls.Add(txtRecipeName);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(749, 60);
            panel2.TabIndex = 0;
            // 
            // btnFtpSync
            // 
            btnFtpSync.BackColor = Color.CornflowerBlue;
            btnFtpSync.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFtpSync.ForeColor = Color.White;
            btnFtpSync.Location = new Point(455, 6);
            btnFtpSync.Margin = new Padding(3, 2, 3, 2);
            btnFtpSync.Name = "btnFtpSync";
            btnFtpSync.Size = new Size(184, 22);
            btnFtpSync.TabIndex = 7;
            btnFtpSync.Text = "FTP Senkronizasyon";
            btnFtpSync.UseVisualStyleBackColor = false;
            // 
            // cmbTargetMachine
            // 
            cmbTargetMachine.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTargetMachine.FormattingEnabled = true;
            cmbTargetMachine.Location = new Point(105, 8);
            cmbTargetMachine.Margin = new Padding(3, 2, 3, 2);
            cmbTargetMachine.Name = "cmbTargetMachine";
            cmbTargetMachine.Size = new Size(246, 23);
            cmbTargetMachine.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(18, 10);
            label4.Name = "label4";
            label4.Size = new Size(89, 15);
            label4.TabIndex = 5;
            label4.Text = "Hedef Makine:";
            // 
            // btnReadFromPlc
            // 
            btnReadFromPlc.Location = new Point(359, 33);
            btnReadFromPlc.Margin = new Padding(3, 2, 3, 2);
            btnReadFromPlc.Name = "btnReadFromPlc";
            btnReadFromPlc.Size = new Size(88, 22);
            btnReadFromPlc.TabIndex = 4;
            btnReadFromPlc.Text = "PLC'den Oku";
            btnReadFromPlc.UseVisualStyleBackColor = true;
            // 
            // btnSendToPlc
            // 
            btnSendToPlc.Location = new Point(551, 33);
            btnSendToPlc.Margin = new Padding(3, 2, 3, 2);
            btnSendToPlc.Name = "btnSendToPlc";
            btnSendToPlc.Size = new Size(88, 22);
            btnSendToPlc.TabIndex = 3;
            btnSendToPlc.Text = "PLC'ye Gönder";
            btnSendToPlc.UseVisualStyleBackColor = true;
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.Location = new Point(455, 33);
            btnSaveRecipe.Margin = new Padding(3, 2, 3, 2);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(82, 22);
            btnSaveRecipe.TabIndex = 2;
            btnSaveRecipe.Text = "Kaydet";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Location = new Point(105, 34);
            txtRecipeName.Margin = new Padding(3, 2, 3, 2);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(246, 23);
            txtRecipeName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(18, 36);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 0;
            label3.Text = "Reçete Adı:";
            // 
            // ProsesKontrol_Control
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ProsesKontrol_Control";
            Size = new Size(1003, 448);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstRecipes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteRecipe;
        private System.Windows.Forms.Button btnNewRecipe;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSendToPlc;
        private System.Windows.Forms.Button btnSaveRecipe;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReadFromPlc;
        private System.Windows.Forms.Panel pnlEditorArea;
        private System.Windows.Forms.ComboBox cmbTargetMachine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFtpSync;
    }
}
