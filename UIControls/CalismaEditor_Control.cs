// UI/Controls/RecipeStepEditors/CalismaEditor_Control.cs
using System;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.UI.Controls.RecipeStepEditors
{
    public partial class CalismaEditor_Control : UserControl
    {
        private ScadaRecipeStep _step;
        public event EventHandler ValueChanged;

        public CalismaEditor_Control()
        {
            InitializeComponent();
            // Olayları bağla
            numSagSolSure.ValueChanged += OnValueChanged;
            numBeklemeSuresi.ValueChanged += OnValueChanged;
            numCalismaDevri.ValueChanged += OnValueChanged;
            numCalismaSuresi.ValueChanged += OnValueChanged;
            chkIsiKontrol.CheckedChanged += OnValueChanged;
            chkAlarm.CheckedChanged += OnValueChanged;
        }

        public void LoadStep(ScadaRecipeStep step)
        {
            _step = step;
            numSagSolSure.Value = _step.StepDataWords[14];
            numBeklemeSuresi.Value = _step.StepDataWords[15];
            numCalismaDevri.Value = _step.StepDataWords[16];
            numCalismaSuresi.Value = _step.StepDataWords[18];

            short controlWord = _step.StepDataWords[17];
            chkIsiKontrol.Checked = (controlWord & 1) != 0; // Bit 0
            chkAlarm.Checked = (controlWord & 2) != 0;      // Bit 1
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_step == null) return;
            _step.StepDataWords[14] = (short)numSagSolSure.Value;
            _step.StepDataWords[15] = (short)numBeklemeSuresi.Value;
            _step.StepDataWords[16] = (short)numCalismaDevri.Value;
            _step.StepDataWords[18] = (short)numCalismaSuresi.Value;

            short controlWord = 0;
            if (chkIsiKontrol.Checked) controlWord |= 1;
            if (chkAlarm.Checked) controlWord |= 2;
            _step.StepDataWords[17] = controlWord;

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}