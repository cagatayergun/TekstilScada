using System.Windows.Forms;

namespace TekstilScada.UI.Views
{
    public partial class GenelBakis_Control : UserControl
    {
        public GenelBakis_Control()
        {
            InitializeComponent();
            // TODO: Bu kontrol yüklendiğinde, bir Timer ile periyodik olarak
            // DashboardRepository'den verileri çekip grafikleri ve KPI'ları güncelle.
        }
    }
}
