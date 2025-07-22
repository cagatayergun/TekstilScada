// ===== YENİ DOSYA: UI/Views/RecipeOptimization_Control.Designer.cs =====
namespace TekstilScada.UI.Views
{
    partial class RecipeOptimization_Control
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Text = "Reçete Optimizasyon Raporu (Geliştirilecek)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(this.label1);
            this.Name = "RecipeOptimization_Control";
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label label1;
    }
}