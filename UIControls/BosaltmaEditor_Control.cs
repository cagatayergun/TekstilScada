// UI/Controls/RecipeStepEditors/BosaltmaEditor_Control.cs
using System;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.UI.Controls.RecipeStepEditors
{
    public partial class BosaltmaEditor_Control : UserControl
    {
        private ScadaRecipeStep _step;
        public event EventHandler ValueChanged;

        public BosaltmaEditor_Control()
        {
            InitializeComponent();
            numSagSolSure.ValueChanged += OnValueChanged;
            numBeklemeZamani.ValueChanged += OnValueChanged;
            numCalismaDevri.ValueChanged += OnValueChanged;
            chkTamburDur.CheckedChanged += OnValueChanged;
            chkAlarm.CheckedChanged += OnValueChanged;
        }

        public void LoadStep(ScadaRecipeStep step)
        {
            _step = step;
            numSagSolSure.Value = _step.StepDataWords[10];
            numBeklemeZamani.Value = _step.StepDataWords[15];
            numCalismaDevri.Value = _step.StepDataWords[12];

            short controlWord = _step.StepDataWords[13];
            chkTamburDur.Checked = (controlWord & 1) != 0; // Bit 0
            chkAlarm.Checked = (controlWord & 2) != 0;      // Bit 1
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_step == null) return;
            _step.StepDataWords[10] = (short)numSagSolSure.Value;
            _step.StepDataWords[15] = (short)numBeklemeZamani.Value;
            _step.StepDataWords[12] = (short)numCalismaDevri.Value;

            short controlWord = 0;
            if (chkTamburDur.Checked) controlWord |= 1;
            if (chkAlarm.Checked) controlWord |= 2;
            _step.StepDataWords[13] = controlWord;

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}