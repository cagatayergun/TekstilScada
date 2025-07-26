using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TekstilScada.Models;
using TekstilScada.Repositories;
using TekstilScada.Localization;
// ScottPlot 5 için doğru using ifadeleri
using ScottPlot;
using TekstilScada.Properties;

namespace TekstilScada.UI.Views
{
    public partial class TrendAnaliz_Control : UserControl
    {
        private MachineRepository _machineRepository;
        private ProcessLogRepository _processLogRepository;

        public TrendAnaliz_Control()
        {
            InitializeComponent();
            ApplyLocalization();
        }
        private void ApplyLocalization()
        {


         
            label1.Text = Resources.Baslangic_tarihi;
            label2.Text = Resources.Bitis_tarihi;
            groupBox1.Text = Resources.makineler;
            groupBox2.Text = Resources.görüntülenecek_veriler;
            chkTemperature.Text = Resources.Temperature;
            chkWaterLevel.Text = Resources.suseviyesi;
            chkRpm.Text = Resources.devir;
            btnGenerateChart.Text = Resources.grafigiolustur;
        }
        // HATA GİDERİLDİ: Eksik olan InitializeControl metodu eklendi.
        public void InitializeControl(MachineRepository machineRepo, ProcessLogRepository processLogRepo)
        {
            _machineRepository = machineRepo;
            _processLogRepository = processLogRepo;
        }

        private void TrendAnaliz_Control_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = DateTime.Now.AddHours(-1);
            dtpEndTime.Value = DateTime.Now;

            var machines = _machineRepository.GetAllEnabledMachines();
            clbMachines.DataSource = machines;
            clbMachines.DisplayMember = "DisplayInfo";
            clbMachines.ValueMember = "Id";
        }

        private void btnGenerateChart_Click(object sender, EventArgs e)
        {
            var selectedMachineIds = clbMachines.CheckedItems.OfType<Machine>().Select(m => m.Id).ToList();
            if (!selectedMachineIds.Any())
            {
                MessageBox.Show("Lütfen en az bir makine seçin.", "Uyarı");
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Title("Proses Veri Trendleri");
            formsPlot1.Plot.Axes.DateTimeTicksBottom();

            // HATA GİDERİLDİ: ScottPlot.Color'a dönüştürüldü
            var colors = new ScottPlot.Color[] { ScottPlot.Colors.Red, ScottPlot.Colors.Blue, ScottPlot.Colors.Green, ScottPlot.Colors.Orange, ScottPlot.Colors.Purple };
            int colorIndex = 0;

            foreach (var machineId in selectedMachineIds)
            {
                var machine = clbMachines.Items.OfType<Machine>().FirstOrDefault(m => m.Id == machineId);
                // GetLogsForBatch metoduna null batchId gönderiyoruz
                var dataPoints = _processLogRepository.GetLogsForBatch(machineId, null, dtpStartTime.Value, dtpEndTime.Value);

                if (dataPoints.Any())
                {
                    double[] timeData = dataPoints.Select(p => p.Timestamp.ToOADate()).ToArray();

                    if (chkTemperature.Checked)
                    {
                        double[] tempData = dataPoints.Select(p => (double)p.Temperature).ToArray();
                        var plot = formsPlot1.Plot.Add.Scatter(timeData, tempData);
                        plot.Color = colors[colorIndex % colors.Length]; // HATA GİDERİLDİ
                        plot.LegendText = $"{machine.MachineName} Sıcaklık";
                    }
                    if (chkWaterLevel.Checked)
                    {
                        double[] waterData = dataPoints.Select(p => (double)p.WaterLevel).ToArray();
                        var plot = formsPlot1.Plot.Add.Scatter(timeData, waterData);
                        plot.Color = colors[(colorIndex + 1) % colors.Length]; // HATA GİDERİLDİ
                        plot.LegendText = $"{machine.MachineName} Su Seviyesi";
                        plot.LineStyle.Pattern = ScottPlot.LinePattern.Dashed;
                    }
                    if (chkRpm.Checked)
                    {
                        double[] rpmData = dataPoints.Select(p => (double)p.Rpm).ToArray();
                        var plot = formsPlot1.Plot.Add.Scatter(timeData, rpmData);
                        plot.Color = colors[(colorIndex + 2) % colors.Length]; // HATA GİDERİLDİ
                        plot.LegendText = $"{machine.MachineName} Devir";
                        plot.LineStyle.Pattern = ScottPlot.LinePattern.Dotted;
                    }
                }
                colorIndex++;
            }

            formsPlot1.Plot.ShowLegend(ScottPlot.Alignment.UpperLeft);
            formsPlot1.Plot.Axes.AutoScale();
            formsPlot1.Refresh();
            this.Cursor = Cursors.Default;
        }
    }
}