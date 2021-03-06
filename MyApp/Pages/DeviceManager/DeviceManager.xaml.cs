﻿using MyApp.Domain;
using System.ComponentModel;
using System.Windows;

namespace MyApp.Pages.DeviceManager
{
    /// <summary>
    /// Interaction logic for DeviceManager.xaml
    /// </summary>
    public partial class DeviceManager : UCBase
    {
        public DeviceManager()
        {
            InitializeComponent();
        }
        public override void OnActivated()
        {
            base.OnActivated();
            connectionManager.ViewModel.RefreshAvailableDevicesCommand.Execute(null);
        }

        public override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
