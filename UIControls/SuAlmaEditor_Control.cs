// UI/Controls/RecipeStepEditors/SuAlmaEditor_Control.cs
using System;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.UI.Controls.RecipeStepEditors
{
    public partial class SuAlmaEditor_Control : UserControl
    {
        private ScadaRecipeStep _step;

        // YENİ: Dışarıdan dinlenebilmesi için olay tanımı eklendi.
        public event EventHandler ValueChanged;

        public SuAlmaEditor_Control()
        {
            InitializeComponent();
            // Değişiklik olduğunda ana reçete nesnesini güncellemek için olayları bağla
            numLitre.ValueChanged += OnValueChanged;
            chkSicakSu.CheckedChanged += OnValueChanged;
            chkSogukSu.CheckedChanged += OnValueChanged;
            chkYumusakSu.CheckedChanged += OnValueChanged;
            chkTamburDur.CheckedChanged += OnValueChanged;
            chkAlarm.CheckedChanged += OnValueChanged;
        }

        public void LoadStep(ScadaRecipeStep step)
        {
            _step = step;

            // PLC'den gelen veriye göre kontrolleri doldur
            numLitre.Value = _step.StepDataWords[1]; // Su Litre: Word 1

            short controlWord = _step.StepDataWords[0]; // Kontrol Word'ü: Word 0
            chkSicakSu.Checked = (controlWord & 1) != 0;   // Bit 0
            chkSogukSu.Checked = (controlWord & 2) != 0;   // Bit 1
            chkYumusakSu.Checked = (controlWord & 4) != 0;   // Bit 2
            chkTamburDur.Checked = (controlWord & 8) != 0;   // Bit 3
            chkAlarm.Checked = (controlWord & 16) != 0;  // Bit 4
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_step == null) return;

            // Arayüzdeki değişiklikleri anında _step nesnesine kaydet
            _step.StepDataWords[1] = (short)numLitre.Value;

            short controlWord = 0;
            if (chkSicakSu.Checked) controlWord |= 1;
            if (chkSogukSu.Checked) controlWord |= 2;
            if (chkYumusakSu.Checked) controlWord |= 4;
            if (chkTamburDur.Checked) controlWord |= 8;
            if (chkAlarm.Checked) controlWord |= 16;
            _step.StepDataWords[0] = controlWord;

            // YENİ: Değişiklik olduğunu dışarıya bildir.
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
