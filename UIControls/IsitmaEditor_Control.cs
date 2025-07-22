// IsitmaEditor_Control.cs
using System;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.UI.Controls.RecipeStepEditors
{
    public partial class IsitmaEditor_Control : UserControl
    {
        private ScadaRecipeStep _step;
        public event EventHandler ValueChanged;

        public IsitmaEditor_Control()
        {
            InitializeComponent();
            numIsi.ValueChanged += OnValueChanged;
            numSure.ValueChanged += OnValueChanged;
            chkDirekBuhar.CheckedChanged += OnValueChanged;
            chkDolayliBuhar.CheckedChanged += OnValueChanged;
            chkTamburDur.CheckedChanged += OnValueChanged;
            chkAlarm.CheckedChanged += OnValueChanged;
        }

        public void LoadStep(ScadaRecipeStep step)
        {
            _step = step;
            numIsi.Value = _step.StepDataWords[3];
            numSure.Value = _step.StepDataWords[4];

            short controlWord = _step.StepDataWords[2];
            chkDirekBuhar.Checked = (controlWord & 1) != 0;
            chkDolayliBuhar.Checked = (controlWord & 2) != 0;
            chkTamburDur.Checked = (controlWord & 4) != 0;
            chkAlarm.Checked = (controlWord & 8) != 0;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_step == null) return;
            _step.StepDataWords[3] = (short)numIsi.Value;
            _step.StepDataWords[4] = (short)numSure.Value;

            short controlWord = 0;
            if (chkDirekBuhar.Checked) controlWord |= 1;
            if (chkDolayliBuhar.Checked) controlWord |= 2;
            if (chkTamburDur.Checked) controlWord |= 4;
            if (chkAlarm.Checked) controlWord |= 8;
            _step.StepDataWords[2] = controlWord;

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

// IsitmaEditor_Control.Designer.cs
// Bu kod bloğunu IsitmaEditor_Control.Designer.cs dosyasına yapıştırın.
// ... (Tasarımcı kodu buraya gelecek) ...
