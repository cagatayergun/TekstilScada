// UI/FtpSync_Form.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TekstilScada.Core;
using TekstilScada.Models;
using TekstilScada.Repositories;
using TekstilScada.Services;

namespace TekstilScada.UI
{
    public partial class FtpSync_Form : Form
    {
        private readonly MachineRepository _machineRepository;
        private readonly RecipeRepository _recipeRepository;
        private FtpService _ftpService;

        public FtpSync_Form(MachineRepository machineRepo, RecipeRepository recipeRepo)
        {
            InitializeComponent();
            _machineRepository = machineRepo;
            _recipeRepository = recipeRepo;

            this.Load += FtpSync_Form_Load;
            cmbMachines.SelectedIndexChanged += CmbMachines_SelectedIndexChanged;
            btnRefreshHmiList.Click += BtnRefreshHmiList_Click;
            btnSendToHmi.Click += BtnSendToHmi_Click;
            btnGetFromHmi.Click += BtnGetFromHmi_Click;
        }

        private void FtpSync_Form_Load(object sender, EventArgs e)
        {
            var machines = _machineRepository.GetAllEnabledMachines()
                .Where(m => m.MachineType == "BYMakinesi").ToList();

            cmbMachines.DataSource = machines;
            cmbMachines.DisplayMember = "DisplayInfo";
            cmbMachines.ValueMember = "Id";

            LoadLocalRecipes();
        }

        private void CmbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshHmiList();
        }

        private void LoadLocalRecipes()
        {
            try
            {
                var recipes = _recipeRepository.GetAllRecipes();
                lstLocalRecipes.DataSource = recipes;
                lstLocalRecipes.DisplayMember = "RecipeName";
                lstLocalRecipes.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yerel reçeteler yüklenemedi: {ex.Message}", "Hata");
            }
        }

        private async void RefreshHmiList()
        {
            var selectedMachine = cmbMachines.SelectedItem as Machine;
            if (selectedMachine == null || string.IsNullOrEmpty(selectedMachine.IpAddress))
            {
                lstHmiRecipes.DataSource = null;
                return;
            }

            _ftpService = new FtpService(selectedMachine.IpAddress, selectedMachine.FtpUsername, selectedMachine.FtpPassword);

            SetBusyState(true, "HMI reçeteleri listeleniyor...");
            lstHmiRecipes.DataSource = null;

            try
            {
                var files = await _ftpService.ListDirectoryAsync("/flash/recipe/");
                var recipeFiles = files
                    .Where(f => f.StartsWith("RECIPE_", StringComparison.OrdinalIgnoreCase) && f.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    .OrderBy(f => f)
                    .ToList();
                lstHmiRecipes.DataSource = recipeFiles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"HMI reçeteleri listelenemedi: {ex.Message}", "FTP Hatası");
            }
            finally
            {
                SetBusyState(false);
            }
        }

        private void BtnRefreshHmiList_Click(object sender, EventArgs e)
        {
            RefreshHmiList();
        }

        private async void BtnSendToHmi_Click(object sender, EventArgs e)
        {
            if (lstLocalRecipes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen HMI'a göndermek için en az bir SCADA reçetesi seçin.", "Uyarı");
                return;
            }
            if (_ftpService == null)
            {
                MessageBox.Show("Lütfen geçerli bir makine seçin.", "Uyarı");
                return;
            }

            string input = ShowInputDialog($"Seçilen {lstLocalRecipes.SelectedItems.Count} adet reçete için başlangıç HMI numarasını girin (1-100):");
            if (!int.TryParse(input, out int startSlot) || startSlot < 1 || startSlot > 100)
            {
                if (!string.IsNullOrEmpty(input)) MessageBox.Show("Geçersiz başlangıç numarası.", "Hata");
                return;
            }

            SetBusyState(true, "Reçeteler HMI'a gönderiliyor...");
            progressBar.Maximum = lstLocalRecipes.SelectedItems.Count;
            progressBar.Value = 0;

            try
            {
                int currentSlot = startSlot;
                foreach (ScadaRecipe selectedRecipeInfo in lstLocalRecipes.SelectedItems)
                {
                    if (currentSlot > 100)
                    {
                        MessageBox.Show("Başlangıç numarası nedeniyle bazı reçeteler 100. yuvayı aşıyor. Sadece sığanlar gönderilecek.", "Uyarı");
                        break;
                    }

                    lblStatus.Text = $"'{selectedRecipeInfo.RecipeName}' gönderiliyor (RECIPE_{currentSlot}.csv)...";

                    // Tam reçete verisini veritabanından çek
                    var fullRecipe = _recipeRepository.GetRecipeById(selectedRecipeInfo.Id);
                    string csvContent = RecipeCsvConverter.ToCsv(fullRecipe);
                    string remoteFileName = $"/flash/recipe/RECIPE_{currentSlot}.csv";

                    await _ftpService.UploadFileAsync(remoteFileName, csvContent);

                    progressBar.Value++;
                    currentSlot++;
                }

                MessageBox.Show("Seçilen reçeteler başarıyla HMI'a gönderildi.", "İşlem Tamamlandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Reçete gönderimi sırasında bir hata oluştu: {ex.Message}", "FTP Hatası");
            }
            finally
            {
                SetBusyState(false);
                RefreshHmiList(); // HMI listesini güncelle
            }
        }

        private async void BtnGetFromHmi_Click(object sender, EventArgs e)
        {
            if (lstHmiRecipes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen SCADA'ya almak için en az bir HMI reçetesi seçin.", "Uyarı");
                return;
            }
            if (_ftpService == null)
            {
                MessageBox.Show("Lütfen geçerli bir makine seçin.", "Uyarı");
                return;
            }

            var result = MessageBox.Show($"{lstHmiRecipes.SelectedItems.Count} adet reçete SCADA veritabanına yeni olarak kaydedilecek. Onaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            SetBusyState(true, "Reçeteler HMI'dan alınıyor...");
            progressBar.Maximum = lstHmiRecipes.SelectedItems.Count;
            progressBar.Value = 0;
            var newRecipeNames = new StringBuilder();

            try
            {
                foreach (string selectedFile in lstHmiRecipes.SelectedItems)
                {
                    lblStatus.Text = $"'{selectedFile}' alınıyor...";
                    string remoteFilePath = $"/flash/recipe/{selectedFile}";
                    string csvContent = await _ftpService.DownloadFileAsync(remoteFilePath);

                    string newRecipeName = $"HMI_{Path.GetFileNameWithoutExtension(selectedFile)}_{DateTime.Now:yyMMddHHmm}";
                    ScadaRecipe newRecipe = RecipeCsvConverter.ToRecipe(csvContent, newRecipeName);

                    _recipeRepository.SaveRecipe(newRecipe);
                    newRecipeNames.AppendLine(newRecipeName);
                    progressBar.Value++;
                }

                MessageBox.Show($"İşlem tamamlandı. Aşağıdaki yeni reçeteler veritabanına kaydedildi:\n\n{newRecipeNames}", "Başarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Reçete alımı sırasında bir hata oluştu: {ex.Message}", "FTP Hatası");
            }
            finally
            {
                SetBusyState(false);
                LoadLocalRecipes(); // Yerel listeyi güncelle
            }
        }

        private void SetBusyState(bool isBusy, string statusText = "Hazır.")
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetBusyState(isBusy, statusText)));
                return;
            }

            lblStatus.Text = statusText;
            progressBar.Visible = isBusy;
            if (!isBusy) progressBar.Value = 0;

            // Panelleri ve butonları kilitle/aç
            pnlTop.Enabled = !isBusy;
            splitContainer1.Enabled = !isBusy;
        }

        public static string ShowInputDialog(string text)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Giriş Gerekli",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 450 };
            NumericUpDown inputBox = new NumericUpDown() { Left = 20, Top = 50, Width = 440, Minimum = 1, Maximum = 100 };
            Button confirmation = new Button() { Text = "Tamam", Left = 360, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Value.ToString() : "";
        }
    }
}
