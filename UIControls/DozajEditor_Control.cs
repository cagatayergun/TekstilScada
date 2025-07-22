// UI/Controls/RecipeStepEditors/DozajEditor_Control.cs
using System;
using System.Text;
using System.Windows.Forms;
using TekstilScada.Models;

namespace TekstilScada.UI.Controls.RecipeStepEditors
{
    public partial class DozajEditor_Control : UserControl
    {
        private ScadaRecipeStep _step;
        public event EventHandler ValueChanged;

        public DozajEditor_Control()
        {
            InitializeComponent();
            // Tüm kontrollerin ValueChanged olaylarını tek bir metoda bağla
            txtKimyasal.TextChanged += OnValueChanged;
            numTankSu.ValueChanged += OnValueChanged;
            numCozmeSure.ValueChanged += OnValueChanged;
            numDozajSure.ValueChanged += OnValueChanged;
            numDozajLitre.ValueChanged += OnValueChanged;
            chkAnaTankMakSu.CheckedChanged += OnValueChanged;
            chkAnaTankTemizSu.CheckedChanged += OnValueChanged;
            chkTank1Su.CheckedChanged += OnValueChanged;
            chkTank1Dozaj.CheckedChanged += OnValueChanged;
            chkTamburDur.CheckedChanged += OnValueChanged;
            chkAlarm.CheckedChanged += OnValueChanged;
        }

        public void LoadStep(ScadaRecipeStep step)
        {
            _step = step;

            // Değerleri PLC hafıza haritasına göre kontrollerden oku
            numTankSu.Value = _step.StepDataWords[20];
            numCozmeSure.Value = _step.StepDataWords[6];
            numDozajSure.Value = _step.StepDataWords[7];
            numDozajLitre.Value = _step.StepDataWords[11];

            // Kimyasal ismini oku (3 word = 6 byte)
            byte[] kimyasalBytes = new byte[6];
            Buffer.BlockCopy(_step.StepDataWords, 21 * 2, kimyasalBytes, 0, 6);
            txtKimyasal.Text = Encoding.ASCII.GetString(kimyasalBytes).Trim('\0');

            // Kontrol bitlerini oku
            short controlWord = _step.StepDataWords[5];
            chkAnaTankMakSu.Checked = (controlWord & (1 << 1)) != 0;
            chkAnaTankTemizSu.Checked = (controlWord & (1 << 2)) != 0;
            chkTamburDur.Checked = (controlWord & (1 << 3)) != 0;
            chkAlarm.Checked = (controlWord & (1 << 4)) != 0;
            chkTank1Su.Checked = (controlWord & (1 << 5)) != 0;
            chkTank1Dozaj.Checked = (controlWord & (1 << 9)) != 0;
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (_step == null) return;

            // Değişiklikleri anında _step nesnesine kaydet
            _step.StepDataWords[20] = (short)numTankSu.Value;
            _step.StepDataWords[6] = (short)numCozmeSure.Value;
            _step.StepDataWords[7] = (short)numDozajSure.Value;
            _step.StepDataWords[11] = (short)numDozajLitre.Value;

            // Kimyasal ismini yaz (6 byte)
            byte[] kimyasalBytes = Encoding.ASCII.GetBytes(txtKimyasal.Text.PadRight(6).Substring(0, 6));
            Buffer.BlockCopy(kimyasalBytes, 0, _step.StepDataWords, 21 * 2, 6);

            // Kontrol bitlerini yaz
            short controlWord = 0;
            if (chkAnaTankMakSu.Checked) controlWord |= (1 << 1);
            if (chkAnaTankTemizSu.Checked) controlWord |= (1 << 2);
            if (chkTamburDur.Checked) controlWord |= (1 << 3);
            if (chkAlarm.Checked) controlWord |= (1 << 4);
            if (chkTank1Su.Checked) controlWord |= (1 << 5);
            if (chkTank1Dozaj.Checked) controlWord |= (1 << 9);
            _step.StepDataWords[5] = controlWord;

            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}