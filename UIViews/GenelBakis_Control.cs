using System;
using System.Linq;
using System.Windows.Forms;
using TekstilScada.Repositories;

namespace TekstilScada.UI.Views
{
    public partial class GenelBakis_Control : UserControl
    {
        private DashboardRepository _dashboardRepository;
        private AlarmRepository _alarmRepository;
        private System.Windows.Forms.Timer _refreshTimer;

        public GenelBakis_Control()
        {
            InitializeComponent();
            _dashboardRepository = new DashboardRepository();
            _alarmRepository = new AlarmRepository();

            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 30000; // 30 saniyede bir güncelle
            _refreshTimer.Tick += RefreshTimer_Tick;
        }

        private void GenelBakis_Control_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                UpdateDashboardData();
                _refreshTimer.Start();
            }
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateDashboardData();
        }

        private void UpdateDashboardData()
        {
            DateTime startTime = DateTime.Now.AddDays(-1);
            DateTime endTime = DateTime.Now;

            try
            {
                // --- KPI Kartlarını Güncelle ---
                var oeeData = _dashboardRepository.GetOeeReport(startTime, endTime, null);
                if (oeeData.Any())
                {
                    lblKpiValue1.Text = $"{oeeData.Average(o => o.OEE):F1} %";
                    lblKpiValue2.Text = $"{oeeData.Average(o => o.Performance):F1} %";
                }
                else
                {
                    lblKpiValue1.Text = "0 %";
                    lblKpiValue2.Text = "0 %";
                }

                var alarmData = _alarmRepository.GetAlarmReport(startTime, endTime, null);
                int activeAlarmCount = alarmData.Count(a => a.EndTime == null);
                lblKpiValue3.Text = activeAlarmCount.ToString();


                // --- OEE Grafiğini Güncelle ---
                formsPlotOee.Plot.Clear();
                if (oeeData.Any())
                {
                    var machineOee = oeeData
                        .GroupBy(o => o.MachineName)
                        .Select(g => new { MachineName = g.Key, AvgOEE = g.Average(o => o.OEE) })
                        .ToList();

                    double[] positions = Enumerable.Range(0, machineOee.Count).Select(i => (double)i).ToArray();
                    double[] oeeValues = machineOee.Select(o => o.AvgOEE).ToArray();
                    string[] labels = machineOee.Select(o => o.MachineName).ToArray();

                    var barPlot = formsPlotOee.Plot.Add.Bars(oeeValues);
                    barPlot.Color = ScottPlot.Colors.Green;
                    formsPlotOee.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positions, labels);
                    formsPlotOee.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
                    formsPlotOee.Plot.Title("Makinelere Göre Ortalama OEE Değerleri (Son 24 Saat)");
                    formsPlotOee.Plot.Axes.AutoScale();
                    formsPlotOee.Refresh();
                }

                // --- En Çok Tekrar Eden Alarmlar Tablosunu Güncelle ---
                var topAlarms = _alarmRepository.GetTopAlarmsByFrequency(startTime, endTime);

                dgvTopAlarms.DataSource = topAlarms;
                dgvTopAlarms.Columns["Alarm"].HeaderText = "Alarm Açıklaması";
                dgvTopAlarms.Columns["Alarm"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvTopAlarms.Columns["Count"].HeaderText = "Tekrar";
                dgvTopAlarms.Columns["Count"].Width = 60;
            }
            catch (Exception ex)
            {
                // Timer çalıştığı için hatayı MessageBox yerine konsola yazmak daha iyi olabilir.
                Console.WriteLine($"Dashboard güncellenirken hata oluştu: {ex.Message}");
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            _refreshTimer?.Stop();
            _refreshTimer?.Dispose();
            base.OnHandleDestroyed(e);
        }
    }
}