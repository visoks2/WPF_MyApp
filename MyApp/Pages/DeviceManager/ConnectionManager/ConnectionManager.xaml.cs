using MyApp.Domain;
using System.ComponentModel;
using System.Windows;

namespace MyApp.Pages.DeviceManager.ConnectionManager
{
    /// <summary>
    /// Interaction logic for DeviceManager.xaml
    /// </summary>
    public partial class ConnectionManager : UCBase
    {
        public ConnectionManager()
        {
            InitializeComponent();
        }

        public override void OnActivated()
        {
            base.OnActivated();
            ViewModel.RefreshAvailableDevices();
        }

        public override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
