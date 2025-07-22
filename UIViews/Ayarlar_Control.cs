// UI/Views/Ayarlar_Control.cs
using System.Collections.Generic;
using System.Windows.Forms;
using TekstilScada.Repositories;
using TekstilScada.Services;

namespace TekstilScada.UI.Views
{
    public partial class Ayarlar_Control : UserControl
    {
        public event System.EventHandler MachineListChanged;

        private readonly MachineSettings_Control _machineSettings;
        private readonly UserSettings_Control _userSettings;
        private readonly AlarmSettings_Control _alarmSettings;
        private readonly PlcOperatorSettings_Control _plcOperatorSettings;

        public Ayarlar_Control()
        {
            InitializeComponent();

            _machineSettings = new MachineSettings_Control();
            _userSettings = new UserSettings_Control();
            _alarmSettings = new AlarmSettings_Control();
            _plcOperatorSettings = new PlcOperatorSettings_Control();

            _machineSettings.MachineListChanged += (sender, args) => { MachineListChanged?.Invoke(this, args); };

            _machineSettings.Dock = DockStyle.Fill;
            tabPageMachineSettings.Controls.Add(_machineSettings);

            _userSettings.Dock = DockStyle.Fill;
            tabPageUserSettings.Controls.Add(_userSettings);

            _alarmSettings.Dock = DockStyle.Fill;
            tabPageAlarmSettings.Controls.Add(_alarmSettings);

            _plcOperatorSettings.Dock = DockStyle.Fill;
            tabPagePlcOperators.Controls.Add(_plcOperatorSettings);
        }

        // DEĞİŞİKLİK: LsPlcManager -> IPlcManager
        public void InitializeControl(MachineRepository machineRepo, Dictionary<int, IPlcManager> plcManagers)
        {
            _plcOperatorSettings.InitializeControl(machineRepo, plcManagers);
        }
    }
}
