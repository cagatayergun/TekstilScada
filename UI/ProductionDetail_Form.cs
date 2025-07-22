// UI/ProductionDetail_Form.cs
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TekstilScada.Core;
using TekstilScada.Models;
using TekstilScada.Repositories;

namespace TekstilScada.UI
{
    public partial class ProductionDetail_Form : Form
    {
        private readonly ProductionReportItem _reportItem;
        private readonly ProductionRepository _productionRepo;
        private readonly ProcessLogRepository _processLogRepo;
        private readonly AlarmRepository _alarmRepo; // Alarmlar için eklendi

        public ProductionDetail_Form(ProductionReportItem reportItem)
        {
            InitializeComponent();
            _reportItem = reportItem;
            _productionRepo = new ProductionRepository();
            _processLogRepo = new ProcessLogRepository();
            _alarmRepo = new AlarmRepository();
        }

        private void ProductionDetail_Form_Load(object sender, EventArgs e)
        {
            this.Text = $"Üretim Raporu Detayı - {_reportItem.BatchId}";

            // 1. Başlık bilgilerini doldur
            txtMachineName.Text = _reportItem.MachineName;
            txtRecipeName.Text = _reportItem.RecipeName;
            txtOperator.Text = _reportItem.OperatorName;
            txtStartTime.Text = _reportItem.StartTime.ToString("dd.MM.yyyy HH:mm:ss");
            txtStopTime.Text = _reportItem.EndTime.ToString("dd.MM.yyyy HH:mm:ss");
            txtTotalDuration.Text = _reportItem.CycleTime;

            // Diğer bilgileri de doldur
            txtCustomerNo.Text = _reportItem.MusteriNo;
            txtOrderNo.Text = _reportItem.SiparisNo;


            // 2. Adım detaylarını DataGridView'e yükle
            dgvStepDetails.DataSource = _productionRepo.GetProductionStepDetails(_reportItem.BatchId, _reportItem.MachineId);

            // 3. Alarm detaylarını yükle
            dgvAlarms.DataSource = _alarmRepo.GetAlarmDetailsForBatch(_reportItem.BatchId, _reportItem.MachineId);

            // 4. Zaman çizgisi grafiğini yükle
            LoadTimelineChart();
        }

        private void LoadTimelineChart()
        {
            var dataPoints = _processLogRepo.GetLogsForBatch(_reportItem.MachineId, _reportItem.BatchId);
            formsPlot1.Plot.Clear();
            if (dataPoints.Any())
            {
                double[] timeData = dataPoints.Select(p => p.Timestamp.ToOADate()).ToArray();
                double[] tempData = dataPoints.Select(p => (double)p.Temperature).ToArray();

                var tempPlot = formsPlot1.Plot.Add.Scatter(timeData, tempData);
                tempPlot.Color = ScottPlot.Colors.Red;
                tempPlot.LegendText = "Sıcaklık";

                formsPlot1.Plot.Axes.DateTimeTicksBottom();
                formsPlot1.Plot.Title("Sıcaklık Grafiği");
                formsPlot1.Plot.ShowLegend();
                formsPlot1.Plot.Axes.AutoScale();
                formsPlot1.Refresh();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExcelExporter.ExportProductionDetailToExcel(_reportItem, dgvStepDetails, dgvAlarms);
            //ExportProductionDetailToExcel(ProductionReportItem headerData, DataGridView dgvSteps, DataGridView dgvAlarms)
        }
    }
}