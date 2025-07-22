// UI/Controls/RecipeStepEditors/SikmaEditor_Control.cs
using System;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.UI.Controls.RecipeStepEditors
{
    public partial class SikmaEditor_Control : UserControl
    {
        private ScadaRecipeStep _step;
        public event EventHandler ValueChanged;

        public SikmaEditor_Control()
        {
            InitializeComponent();
            numSikmaDevri.ValueChanged += OnValueChanged;
            numSikmaSure.ValueChanged += OnValueChanged;
        }

        public void LoadStep(ScadaRecipeStep step)
        {
            _step = step;
            numSikmaDevri.Value = _step.StepDataWords[8];
            numSikmaSure.Value = _step.StepDataWords[9];
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_step == null) return;
            _step.StepDataWords[8] = (short)numSikmaDevri.Value;
            _step.StepDataWords[9] = (short)numSikmaSure.Value;
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
// --------------------------------------------------------------------
// UI/Controls/RecipeStepEditors/SikmaEditor_Control.Designer.cs
// ... (Tasarımcı kodu buraya gelecek. İki NumericUpDown ve iki Label içerir.) ...
