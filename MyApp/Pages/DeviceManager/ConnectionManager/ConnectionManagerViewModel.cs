using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.Pages.DeviceManager.ConnectionManager
{
    public class ConnectionManagerViewModel : BaseViewModel
    {
        #region Commands
        public ICommand ConnectComand { get; }
        public ICommand RefreshAvailableDevicesCommand { get; }
        #endregion
        #region Private variables
        private string[] _availableDevice;
        private string _selectedDevice;
        private readonly int[] _availableBaudRates = new int[] { 9600, 19200, 38400, 57600, 115200 };
        private int _selectedBaudRate = 115200;
        private DeviceConnectionState _connectionState = DeviceConnectionState.NotConfigured;
        private bool _isConnected = false;
        #endregion
        #region Constructor
        public ConnectionManagerViewModel() : base()
        {
            ConnectComand = new AnotherCommandImplementation(_ => OnConnectButtonPressed());
            RefreshAvailableDevicesCommand = new AnotherCommandImplementation(_ => RefreshAvailableDevices());
        }
        #endregion
        #region Properties
        private SerialPort SerialPort {
            get { return Devices.SerialPort; }
        }
        public DeviceConnectionState ConnectionState {
            get { return _connectionState; }
            private set {
                _connectionState = value;
                OnConnetionStateChanged();
                OnPropertyChanged();
            }
        }
        public bool IsConnected {
            get { return _isConnected; }
            private set {
                _isConnected = value;
                OnPropertyChanged();
            }
        }
        public string[] AvailableDevice {
            get { return _availableDevice; }
            set {
                _availableDevice = value;
                OnPropertyChanged();
            }
        }
        public string SelectedDevice {
            get { return _selectedDevice; }
            set {
                _selectedDevice = value;
                OnPropertyChanged();
                if (string.IsNullOrWhiteSpace(_selectedDevice))
                    ConnectionState = DeviceConnectionState.NotConfigured;
                else
                    ConnectionState = DeviceConnectionState.CanConnect;
            }
        }
        public int[] BaudRates {
            get { return _availableBaudRates; }
        }
        public int SelectedBaudRate {
            get { return _selectedBaudRate; }
            set { _selectedBaudRate = value; }
        }
        #endregion
        #region Public methods
        public void RefreshAvailableDevices()
        {
            string[] names = SerialPort.GetPortNames();
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Substring(0, 4);
            }
            AvailableDevice = names;
            if (AvailableDevice.Length > 0)
                SelectedDevice = AvailableDevice[0];
        }
        #endregion
        #region Private methods
        private void OnConnectButtonPressed()
        {
            switch (ConnectionState)
            {
                case DeviceConnectionState.NotConfigured:
                    //validate
                    break;
                case DeviceConnectionState.Validating:
                    break;
                case DeviceConnectionState.CanConnect:
                    SerialPort.PortName = SelectedDevice;
                    SerialPort.BaudRate = SelectedBaudRate;
                    SerialPort.Open();
                    if (SerialPort.IsOpen)
                        ConnectionState = DeviceConnectionState.Connected;
                    break;
                case DeviceConnectionState.Connected:
                    SerialPort.Close();
                    if (!SerialPort.IsOpen)
                        ConnectionState = DeviceConnectionState.CanConnect;
                    break;
                case DeviceConnectionState.Connecting:
                    break;
                case DeviceConnectionState.Disconnected:
                    break;
                default:
                    break;
            }
        }
        private void OnConnetionStateChanged()
        {
            switch (ConnectionState)
            {
                case DeviceConnectionState.NotConfigured:
                    break;
                case DeviceConnectionState.Validating:
                    break;
                case DeviceConnectionState.CanConnect:
                    IsConnected = false;
                    break;
                case DeviceConnectionState.Connected:
                    IsConnected = true;
                    break;
                case DeviceConnectionState.Connecting:
                    break;
                case DeviceConnectionState.Disconnected:
                    IsConnected = false;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }

}
