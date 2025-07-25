using TekstilScada.Repositories;
using System.Windows.Forms;

namespace TekstilScada.UI.Views
{
    public partial class Raporlar_Control : UserControl
    {
        private readonly AlarmReport_Control _alarmReport;
        private readonly ProductionReport_Control _productionReport;
        private readonly OeeReport_Control _oeeReport;
        private readonly TrendAnaliz_Control _trendAnaliz;
        private readonly RecipeOptimization_Control _recipeOptimization;

        public Raporlar_Control()
        {
            InitializeComponent();

            _alarmReport = new AlarmReport_Control();
            _productionReport = new ProductionReport_Control();
            _oeeReport = new OeeReport_Control();
            _trendAnaliz = new TrendAnaliz_Control();
            _recipeOptimization = new RecipeOptimization_Control();

            _alarmReport.Dock = DockStyle.Fill;
            tabPageAlarmReport.Controls.Add(_alarmReport);

            _productionReport.Dock = DockStyle.Fill;
            tabPageProductionReport.Controls.Add(_productionReport);

            _oeeReport.Dock = DockStyle.Fill;
            tabPageOeeReport.Controls.Add(_oeeReport);

            _trendAnaliz.Dock = DockStyle.Fill;
            tabPageTrendAnalysis.Controls.Add(_trendAnaliz);

            _recipeOptimization.Dock = DockStyle.Fill;
            tabPageRecipeOptimization.Controls.Add(_recipeOptimization);
        }

        // HATA GİDERİLDİ: Metot imzası ve içindeki çağrılar düzeltildi.
        public void InitializeControl(
            MachineRepository machineRepo,
            AlarmRepository alarmRepo,
            ProductionRepository productionRepo,
            DashboardRepository dashboardRepo,
            ProcessLogRepository processLogRepo,
            RecipeRepository recipeRepo)
        {
            _alarmReport.InitializeControl(machineRepo, alarmRepo);
            _productionReport.InitializeControl(machineRepo, productionRepo, recipeRepo, processLogRepo, alarmRepo); // GÜNCELLENDİ
            _oeeReport.InitializeControl(machineRepo, dashboardRepo);
            _trendAnaliz.InitializeControl(machineRepo, processLogRepo);
            _recipeOptimization.InitializeControl(recipeRepo);
        }
    }
}