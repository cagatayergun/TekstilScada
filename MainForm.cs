// MainForm.cs
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TekstilScada.Core;
using TekstilScada.Localization;
using TekstilScada.Models;
using TekstilScada.Repositories;
using TekstilScada.Services;
using TekstilScada.UI;
using TekstilScada.UI.Controls;
using TekstilScada.UI.Views;

namespace TekstilScada
{
    public partial class MainForm : Form
    {
        // Repository ve Servisler
        private readonly MachineRepository _machineRepository;
        private readonly RecipeRepository _recipeRepository;
        private readonly ProcessLogRepository _processLogRepository;
        private readonly AlarmRepository _alarmRepository;
        private readonly ProductionRepository _productionRepository;
        private readonly PlcPollingService _pollingService;
        private readonly DashboardRepository _dashboardRepository;

        // Arayüz Kontrolleri (Views)
        private readonly ProsesÝzleme_Control _prosesIzlemeView;
        private readonly ProsesKontrol_Control _prosesKontrolView;
        private readonly Ayarlar_Control _ayarlarView;
        private readonly MakineDetay_Control _makineDetayView;
        private readonly Raporlar_Control _raporlarView;
        private readonly LiveEventPopup_Form _liveEventPopup;
        private readonly GenelBakis_Control _genelBakisView;

        private VncViewer_Form _activeVncViewerForm = null;

        public MainForm()
        {
            InitializeComponent();

            // 1. ADIM: Tüm nesneler burada oluþturulur.
            // Bu, NullReferenceException hatasýný önlemek için kritiktir.
            _machineRepository = new MachineRepository();
            _recipeRepository = new RecipeRepository();
            _processLogRepository = new ProcessLogRepository();
            _alarmRepository = new AlarmRepository();
            _productionRepository = new ProductionRepository();
            _pollingService = new PlcPollingService();
            _dashboardRepository = new DashboardRepository();

            _prosesIzlemeView = new ProsesÝzleme_Control();
            _prosesKontrolView = new ProsesKontrol_Control();
            _ayarlarView = new Ayarlar_Control();
            _makineDetayView = new MakineDetay_Control();
            _raporlarView = new Raporlar_Control();
            _liveEventPopup = new LiveEventPopup_Form();
            _genelBakisView = new GenelBakis_Control();

            // Olay abonelikleri (Events)
            LanguageManager.LanguageChanged += LanguageManager_LanguageChanged;
            _ayarlarView.MachineListChanged += OnMachineListChanged;
            _pollingService.OnActiveAlarmStateChanged += OnActiveAlarmStateChanged;
            _prosesIzlemeView.MachineDetailsRequested += OnMachineDetailsRequested;
            _prosesIzlemeView.MachineVncRequested += OnMachineVncRequested;
            _makineDetayView.BackRequested += OnBackRequested;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 2. ADIM: Form tamamen yüklendikten sonra bu metot çalýþýr.
            // Veritabaný ve PLC iþlemlerini baþlatan metotlar burada çaðrýlýr.
            ApplyLocalization();
            UpdateUserInfoAndPermissions();
            ReloadSystem();
        }

        private void ReloadSystem()
        {
            _pollingService.Stop();
            List<Machine> machines = _machineRepository.GetAllEnabledMachines();
            if (machines == null)
            {
                MessageBox.Show("Veritabaný baðlantýsý kurulamadý.", "Kritik Hata");
                return;
            }
            _pollingService.Start(machines);
            var plcManagers = _pollingService.GetPlcManagers();

            // Kontrolleri en güncel verilerle baþlat
            _prosesIzlemeView.InitializeView(machines, _pollingService);
            _prosesKontrolView.InitializeControl(_recipeRepository, _machineRepository, plcManagers);
            _ayarlarView.InitializeControl(_machineRepository, plcManagers);
            _raporlarView.InitializeControl(_machineRepository, _alarmRepository, _productionRepository, _dashboardRepository, _processLogRepository, _recipeRepository);
            _genelBakisView.InitializeControl(_pollingService, _machineRepository, _dashboardRepository);

            ShowView(_genelBakisView); // Baþlangýç ekraný olarak Genel Bakýþ'ý göster
        }

        #region Arayüz ve Dil Yönetimi

        private void LanguageManager_LanguageChanged(object sender, EventArgs e)
        {
            ApplyLocalization();
            UpdateUserInfoAndPermissions();
        }

        private void ApplyLocalization()
        {
            this.Text = Strings.ApplicationTitle;
            btnGenelBakis.Text = Strings.MainMenu_GeneralOverview;
            btnProsesIzleme.Text = Strings.MainMenu_ProcessMonitoring;
            btnProsesKontrol.Text = Strings.MainMenu_ProcessControl;
            btnRaporlar.Text = Strings.MainMenu_Reports;
            btnAyarlar.Text = Strings.MainMenu_Settings;
            dilToolStripMenuItem.Text = "Dil";
            oturumToolStripMenuItem.Text = "Oturum";
            çýkýþYapToolStripMenuItem.Text = "Çýkýþ Yap";
        }

        private void UpdateUserInfoAndPermissions()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblStatusCurrentUser.Text = $"Giriþ Yapan: {CurrentUser.User.FullName}";
            }
            else
            {
                lblStatusCurrentUser.Text = "Giriþ Yapan: -";
            }
            // Ayarlar butonunu sadece "Admin" rolüne sahip kullanýcýlar için etkinleþtir.
            btnAyarlar.Enabled = CurrentUser.HasRole("Admin");
        }

        private void ShowView(UserControl view)
        {
            if (view is Ayarlar_Control && !CurrentUser.HasRole("Admin"))
            {
                MessageBox.Show("Bu alana eriþim yetkiniz bulunmamaktadýr.", "Yetki Reddedildi");
                return;
            }
            pnlContent.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
        }

        #endregion

        #region Olay Yöneticileri (Event Handlers)

        private void OnMachineListChanged(object sender, EventArgs e) => ReloadSystem();
        private void OnBackRequested(object sender, EventArgs e) => ShowView(_prosesIzlemeView);
        private void btnGenelBakis_Click(object sender, EventArgs e) => ShowView(_genelBakisView);
        private void btnProsesIzleme_Click(object sender, EventArgs e) => ShowView(_prosesIzlemeView);
        private void btnProsesKontrol_Click(object sender, EventArgs e) => ShowView(_prosesKontrolView);
        private void btnRaporlar_Click(object sender, EventArgs e) => ShowView(_raporlarView);
        private void btnAyarlar_Click(object sender, EventArgs e) => ShowView(_ayarlarView);
        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e) => LanguageManager.SetLanguage("tr-TR");
        private void englishToolStripMenuItem_Click(object sender, EventArgs e) => LanguageManager.SetLanguage("en-US");

        private void çýkýþYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Çýkýþ yapmak istediðinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                _pollingService.Stop();

                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        UpdateUserInfoAndPermissions();
                        ReloadSystem();
                        this.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        private void OnMachineDetailsRequested(object sender, int machineId)
        {
            var machine = _machineRepository.GetAllMachines().FirstOrDefault(m => m.Id == machineId);
            if (machine != null)
            {
                _makineDetayView.InitializeControl(machine, _pollingService, _processLogRepository);
                ShowView(_makineDetayView);
            }
        }

        private void OnMachineVncRequested(object sender, int machineId)
        {
            if (_activeVncViewerForm != null && !_activeVncViewerForm.IsDisposed)
            {
                _activeVncViewerForm.Activate();
                MessageBox.Show("Zaten bir VNC baðlantýsý aktif. Lütfen mevcut pencereyi kapatýn.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var machine = _machineRepository.GetAllMachines().FirstOrDefault(m => m.Id == machineId);
            if (machine != null && !string.IsNullOrEmpty(machine.VncAddress))
            {
                try
                {
                    var vncForm = new VncViewer_Form(machine.VncAddress, machine.VncPassword);
                    vncForm.Text = $"{machine.MachineName} - VNC Baðlantýsý";
                    vncForm.FormClosed += (s, args) => { _activeVncViewerForm = null; };
                    _activeVncViewerForm = vncForm;
                    vncForm.Show();
                }
                catch (Exception ex)
                {
                    _activeVncViewerForm = null;
                    MessageBox.Show($"VNC penceresi açýlýrken bir hata oluþtu: {ex.Message}", "Hata");
                }
            }
            else
            {
                MessageBox.Show("Bu makine için bir VNC adresi tanýmlanmamýþ.", "Bilgi");
            }
        }

        private void OnActiveAlarmStateChanged(int machineId, FullMachineStatus status)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            this.Invoke(new Action(() =>
            {
                if (this.IsDisposed) return;

                var activeAlarms = _pollingService.MachineDataCache.Values.Where(s => s.HasActiveAlarm).ToList();

                if (activeAlarms.Any())
                {
                    var alarmToShow = activeAlarms
                        .Select(s => new { Status = s, Definition = _alarmRepository.GetAlarmDefinitionByNumber(s.ActiveAlarmNumber) })
                        .Where(ad => ad.Definition != null)
                        .OrderByDescending(ad => ad.Definition.Severity)
                        .FirstOrDefault();

                    if (alarmToShow != null)
                    {
                        lblStatusLiveEvents.Text = $"[{alarmToShow.Status.MachineName}] - ALARM: {alarmToShow.Definition.AlarmText}";
                        lblStatusLiveEvents.BackColor = Color.FromArgb(231, 76, 60); // Kýrmýzý
                        lblStatusLiveEvents.ForeColor = Color.White;
                    }
                }
                else
                {
                    lblStatusLiveEvents.Text = "Canlý Olay Akýþý Göster";
                    lblStatusLiveEvents.BackColor = System.Drawing.SystemColors.Control;
                    lblStatusLiveEvents.ForeColor = System.Drawing.SystemColors.ControlText;
                }
            }));
        }

        private void lblStatusLiveEvents_Click(object sender, EventArgs e)
        {
            if (_liveEventPopup.Visible)
            {
                _liveEventPopup.Hide();
            }
            else
            {
                _liveEventPopup.Show(this);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LanguageManager.LanguageChanged -= LanguageManager_LanguageChanged;
            _pollingService.Stop();
            if (_activeVncViewerForm != null && !_activeVncViewerForm.IsDisposed)
            {
                try
                {
                    _activeVncViewerForm.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"MainForm kapanýrken VNCViewer formunu kapatma hatasý: {ex.Message}");
                }
            }
        }

        #endregion
    }
}
