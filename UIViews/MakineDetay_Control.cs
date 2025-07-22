// UI/Views/MakineDetay_Control.cs
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TekstilScada.Models;
using TekstilScada.Repositories;
using TekstilScada.Services;

namespace TekstilScada.UI.Views
{
    public partial class MakineDetay_Control : UserControl
    {
        public event EventHandler BackRequested;

        private PlcPollingService _pollingService;
        private ProcessLogRepository _logRepository;
        private Machine _machine;
        // DÜZELTME: Timer belirsizliğini gidermek için tam ad alanı kullanılıyor.
        private System.Windows.Forms.Timer _uiUpdateTimer;

        public MakineDetay_Control()
        {
            InitializeComponent();
            btnGeri.Click += (sender, args) => BackRequested?.Invoke(this, EventArgs.Empty);

            _uiUpdateTimer = new System.Windows.Forms.Timer { Interval = 2000 };
            _uiUpdateTimer.Tick += (sender, args) => UpdateLiveGauges();
        }

        public void InitializeControl(Machine machine, PlcPollingService service, ProcessLogRepository logRepo)
        {
            _machine = machine;
            _pollingService = service;
            _logRepository = logRepo;

            // Olaylara abone ol
            _pollingService.OnMachineDataRefreshed += OnDataRefreshed;

            LoadInitialData();
            _uiUpdateTimer.Start();
        }

        private void LoadInitialData()
        {
            if (_pollingService.MachineDataCache.TryGetValue(_machine.Id, out var status))
            {
                UpdateUI(status);
                LoadTimelineChart(status.BatchNumarasi);
            }
        }

        // DÜZELTME: Eksik olan ve hata veren olay metodu eklendi.
        private void OnDataRefreshed(int machineId, FullMachineStatus status)
        {
            // Sadece bu kontrolün sorumlu olduğu makineden veri geldiyse güncelle
            if (machineId == _machine.Id)
            {
                SafeInvoke(() => UpdateUI(status));
            }
        }

        private void UpdateLiveGauges()
        {
            if (_machine != null && _pollingService.MachineDataCache.TryGetValue(_machine.Id, out var status))
            {
                SafeInvoke(() => {
                    lblRpmValue.Text = status.AnlikDevirRpm.ToString();
                    lblTempValue.Text = status.AnlikSicaklik.ToString();
                    lblWaterValue.Text = status.AnlikSuSeviyesi.ToString();
                });
            }
        }

        private void UpdateUI(FullMachineStatus status)
        {
            lblMakineAdi.Text = status.MachineName;
            lblReceteAdi.Text = status.RecipeName;
            lblOperator.Text = status.OperatorIsmi;
            lblMusteriNo.Text = status.MusteriNumarasi;
            lblBatchNo.Text = status.BatchNumarasi;
            lblSiparisNo.Text = status.SiparisNumarasi;
        }

        private void LoadTimelineChart(string batchId)
        {
            SafeInvoke(() =>
            {
                if (string.IsNullOrEmpty(batchId))
                {
                    // DÜZELTME: ScottPlot 5'e uygun başlık atama
                    formsPlot1.Plot.Title("Aktif bir Batch bulunamadı.");
                    formsPlot1.Refresh();
                    return;
                }

                try
                {
                    var dataPoints = _logRepository.GetLogsForBatch(_machine.Id, batchId);
                    formsPlot1.Plot.Clear();

                    if (dataPoints.Any())
                    {
                        // DÜZELTME: ScottPlot 5 API'sine göre güncellendi
                        double[] timeData = dataPoints.Select(p => p.Timestamp.ToOADate()).ToArray();
                        double[] tempData = dataPoints.Select(p => (double)p.Temperature).ToArray();
                        double[] waterData = dataPoints.Select(p => (double)p.WaterLevel).ToArray();

                        var tempPlot = formsPlot1.Plot.Add.Scatter(timeData, tempData);
                        tempPlot.Color = ScottPlot.Colors.Red;
                        tempPlot.LegendText = "Sıcaklık";
                        tempPlot.LineWidth = 2;

                        var waterPlot = formsPlot1.Plot.Add.Scatter(timeData, waterData);
                        waterPlot.Color = ScottPlot.Colors.Blue;
                        waterPlot.LegendText = "Su Seviyesi";
                        waterPlot.LineWidth = 2;

                        formsPlot1.Plot.Axes.DateTimeTicksBottom();
                        formsPlot1.Plot.Title($"{_machine.MachineName} - {batchId} Proses Grafiği");
                        formsPlot1.Plot.ShowLegend(ScottPlot.Alignment.UpperLeft);
                        formsPlot1.Plot.Axes.AutoScale();
                    }
                    else
                    {
                        formsPlot1.Plot.Title("Bu Batch için henüz veri kaydedilmemiş.");
                    }

                    formsPlot1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Grafik verileri yüklenirken hata oluştu: {ex.Message}", "Grafik Hatası");
                }
            });
        }

        private void SafeInvoke(Action action)
        {
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                try
                {
                    this.BeginInvoke(action);
                }
                catch (Exception) { /* Form kapatılırken oluşabilecek nadir hataları yoksay. */ }
            }
        }

        // Kontrol ekrandan kaldırıldığında timer'ı ve olayları temizle
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_pollingService != null)
            {
                _pollingService.OnMachineDataRefreshed -= OnDataRefreshed;
            }
            _uiUpdateTimer?.Stop();
            base.OnHandleDestroyed(e);
        }
    }
}