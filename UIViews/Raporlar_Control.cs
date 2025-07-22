// UI/Views/Raporlar_Control.cs
using TekstilScada.Repositories;
using System.Windows.Forms;
//using TekstilScada.Repositories
namespace TekstilScada.UI.Views
{
    public partial class Raporlar_Control : UserControl
    {
        private readonly AlarmReport_Control _alarmReport;
        // YENİ: Üretim raporu kontrolü eklendi.
        private readonly ProductionReport_Control _productionReport;
        private readonly OeeReport_Control _oeeReport;
        private readonly TrendAnaliz_Control _trendAnaliz;
        private readonly RecipeOptimization_Control _recipeOptimization;
        public Raporlar_Control()
        {
            InitializeComponent();

            // Alt kontrolleri oluştur
            _alarmReport = new AlarmReport_Control();
            _productionReport = new ProductionReport_Control();
            // YENİ: Yeni rapor kontrolleri oluşturuldu
            _oeeReport = new OeeReport_Control();
            _trendAnaliz = new TrendAnaliz_Control();
            _recipeOptimization = new RecipeOptimization_Control();
            // Kontrolleri TabPage'lere ekle
            _alarmReport.Dock = DockStyle.Fill;
            tabPageAlarmReport.Controls.Add(_alarmReport);
            // YENİ: Yeni rapor kontrolleri sekmelere eklendi
            _oeeReport.Dock = DockStyle.Fill;
            tabPageOeeReport.Controls.Add(_oeeReport);
            // YENİ: Üretim raporu kontrolü sekmeye eklendi.
            _productionReport.Dock = DockStyle.Fill;
            tabPageProductionReport.Controls.Add(_productionReport);
        }

        // YENİ: Metot, ProductionRepository'yi de alacak şekilde güncellendi.
        public void InitializeControl(MachineRepository machineRepo, AlarmRepository alarmRepo, ProductionRepository productionRepo)
        {
            _alarmReport.InitializeControl(machineRepo, alarmRepo);
            _productionReport.InitializeControl(machineRepo, productionRepo);
        }
    }
}