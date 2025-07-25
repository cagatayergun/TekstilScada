// MainForm.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
        private readonly MachineRepository _machineRepository;
        private readonly RecipeRepository _recipeRepository;
        private readonly DashboardRepository _dashboardRepository; // YEN�
        private readonly ProcessLogRepository _processLogRepository;
        private readonly AlarmRepository _alarmRepository;
        private readonly ProductionRepository _productionRepository;
        private readonly PlcPollingService _pollingService;

        private readonly Proses�zleme_Control _prosesIzlemeView;
        private readonly ProsesKontrol_Control _prosesKontrolView;
        private readonly Ayarlar_Control _ayarlarView;
        private readonly MakineDetay_Control _makineDetayView;
        private readonly Raporlar_Control _raporlarView;
        private readonly LiveEventPopup_Form _liveEventPopup;
        private readonly AlarmBanner_Control _alarmBanner;

        private VncViewer_Form _activeVncViewerForm = null;
        private readonly GenelBakis_Control _genelBakisView;
        public MainForm()
        {
            InitializeComponent();

            _machineRepository = new MachineRepository();
            _recipeRepository = new RecipeRepository();
            _processLogRepository = new ProcessLogRepository();
            _alarmRepository = new AlarmRepository();
            _productionRepository = new ProductionRepository();
            _pollingService = new PlcPollingService();

            _prosesIzlemeView = new Proses�zleme_Control();
            _prosesKontrolView = new ProsesKontrol_Control();
            _ayarlarView = new Ayarlar_Control();
            _makineDetayView = new MakineDetay_Control();
            _raporlarView = new Raporlar_Control();
            _liveEventPopup = new LiveEventPopup_Form();
            _alarmBanner = new AlarmBanner_Control();
            // YEN�: Genel Bak�� ekran� olu�turuldu
            _genelBakisView = new GenelBakis_Control();
            _dashboardRepository = new DashboardRepository(); // YEN�
            _ayarlarView.MachineListChanged += OnMachineListChanged;
            _pollingService.OnActiveAlarmStateChanged += OnActiveAlarmStateChanged;
            _prosesIzlemeView.MachineDetailsRequested += OnMachineDetailsRequested;
            _prosesIzlemeView.MachineVncRequested += OnMachineVncRequested;
            _makineDetayView.BackRequested += OnBackRequested;
            _alarmBanner.Click += AlarmBanner_Click;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Controls.Add(_alarmBanner);
            _alarmBanner.Dock = DockStyle.Bottom;
            _alarmBanner.BringToFront();
            UpdateUserInfo();
            ApplyRolePermissions();

            ReloadSystem();
        }
        private void UpdateUserInfo()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblCurrentUser.Text = $"Giri� Yapan: {CurrentUser.User.FullName} ({CurrentUser.User.Username})";
            }
        }
        private void ApplyRolePermissions()
        {
            // Ayarlar butonunu sadece Admin g�rebilir.
            btnAyarlar.Enabled = CurrentUser.HasRole("Admin");
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("��k�� yapmak istedi�inizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Mevcut formu gizle
                this.Hide();

                // Polling servisini durdur
                _pollingService.Stop();

                // Login formunu tekrar g�ster
                using (var loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Ba�ar�l� giri� yap�l�rsa, sistemi yeniden y�kle ve formu g�ster
                        UpdateUserInfo();
                        ApplyRolePermissions();
                        ReloadSystem();
                        this.Show();
                    }
                    else
                    {
                        // Giri� yap�lmazsa veya iptal edilirse uygulamay� kapat
                        Application.Exit();
                    }
                }
            }
        }
        private void ReloadSystem()
        {
            _pollingService.Stop();

            List<Machine> machines = _machineRepository.GetAllEnabledMachines();
            if (machines == null)
            {
                MessageBox.Show("Veritaban� ba�lant�s� kurulamad�.", "Kritik Hata");
                return;
            }

            _pollingService.Start(machines);

            // DE����KL�K: GetPlcManagers art�k Dictionary<int, IPlcManager> d�nd�r�yor
            var plcManagers = _pollingService.GetPlcManagers();

            _prosesIzlemeView.InitializeView(machines, _pollingService);
            _prosesKontrolView.InitializeControl(_recipeRepository, _machineRepository, plcManagers);
            _ayarlarView.InitializeControl(_machineRepository, plcManagers);
            _raporlarView.InitializeControl(_machineRepository, _alarmRepository, _productionRepository, _dashboardRepository, _processLogRepository, _recipeRepository);

            ShowView(_prosesIzlemeView);
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
                MessageBox.Show("Zaten bir VNC ba�lant�s� aktif. L�tfen mevcut pencereyi kapat�n.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var machine = _machineRepository.GetAllMachines().FirstOrDefault(m => m.Id == machineId);
            if (machine != null && !string.IsNullOrEmpty(machine.VncAddress))
            {
                try
                {
                    var vncForm = new VncViewer_Form(machine.VncAddress, machine.VncPassword);
                    vncForm.Text = $"{machine.MachineName} - VNC Ba�lant�s�";
                    vncForm.FormClosed += (s, args) => { _activeVncViewerForm = null; };
                    _activeVncViewerForm = vncForm;
                    vncForm.Show();
                }
                catch (Exception ex)
                {
                    _activeVncViewerForm = null;
                    MessageBox.Show($"VNC penceresi a��l�rken bir hata olu�tu: {ex.Message}", "Hata");
                }
            }
            else
            {
                MessageBox.Show("Bu makine i�in bir VNC adresi tan�mlanmam��.", "Bilgi");
            }
        }

        private void OnBackRequested(object sender, EventArgs e)
        {
            ShowView(_prosesIzlemeView);
        }

        private void OnMachineListChanged(object sender, EventArgs e)
        {
            ReloadSystem();
        }

        private void ShowView(UserControl view)
        {
            if (view is Ayarlar_Control && !CurrentUser.HasRole("Admin"))
            {
                MessageBox.Show("Bu alana eri�im yetkiniz bulunmamaktad�r.", "Yetki Reddedildi");
                return;
            }

            pnlContent.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
        }

        private void AlarmBanner_Click(object sender, EventArgs e)
        {
            ToggleLiveEventsWindow();
           
        }
        // YEN�: Status bar'daki butona t�kland���nda �al��acak metot
        private void btnShowEvents_Click(object sender, EventArgs e)
        {
            ToggleLiveEventsWindow();
        }
        private void ToggleLiveEventsWindow()
        {
            if (_liveEventPopup.Visible)
            {
                _liveEventPopup.Hide();
            }
            else
            {
                // Formun ilk a��l��ta ekran�n sa� alt k��esinde belirmesini sa�layal�m
                if (_liveEventPopup.StartPosition == FormStartPosition.Manual)
                {
                    // Bu kod blo�u sadece ilk a��l��ta �al���r
                }
                _liveEventPopup.StartPosition = FormStartPosition.Manual;
                Screen screen = Screen.FromPoint(this.Location);
                _liveEventPopup.Left = screen.WorkingArea.Right - _liveEventPopup.Width;
                _liveEventPopup.Top = screen.WorkingArea.Bottom - _liveEventPopup.Height;
                _liveEventPopup.Show(this);
            }
        }
        private void OnActiveAlarmStateChanged(int machineId, FullMachineStatus status)
        {
            //if (!this.IsHandleCreated || this.IsDisposed) return;
            //this.Invoke(new Action(() =>
            //{
            //    if (this.IsDisposed || _alarmBanner == null) return;
            //    var activeAlarms = _pollingService.MachineDataCache.Values.Where(s => s.HasActiveAlarm).ToList();
            //    if (activeAlarms.Any())
            //    {
            //        var alarmToShow = activeAlarms
            //            .Select(s => new { Status = s, Definition = _alarmRepository.GetAlarmDefinitionByNumber(s.ActiveAlarmNumber) })
            //            .Where(ad => ad.Definition != null)
            //            .OrderByDescending(ad => ad.Definition.Severity)
            //            .FirstOrDefault();
            //        if (alarmToShow != null)
            //        {
            //            _alarmBanner.ShowAlarm(alarmToShow.Status.MachineName, alarmToShow.Definition);
            //        }
            //        else
            //        {
            //            _alarmBanner.HideBanner();
            //        }
            //    }
            //    else
            //    {
            //        _alarmBanner.HideBanner();
            //    }
            //}));
        }

        private void btnProsesIzleme_Click(object sender, EventArgs e)
        {
            ShowView(_prosesIzlemeView);
        }

        private void btnProsesKontrol_Click(object sender, EventArgs e)
        {
            ShowView(_prosesKontrolView);
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            ShowView(_raporlarView);
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            ShowView(_ayarlarView);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pollingService.Stop();
            if (_activeVncViewerForm != null && !_activeVncViewerForm.IsDisposed)
            {
                try
                {
                    _activeVncViewerForm.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"MainForm kapan�rken VNCViewer formunu kapatma hatas�: {ex.Message}");
                }
            }
        }
        // YEN�: Genel Bak�� butonu i�in click olay�
        private void btnGenelBakis_Click(object sender, EventArgs e)
        {
            ShowView(_genelBakisView);
        }
    }
}
