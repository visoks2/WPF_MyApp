using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.Pages.DeviceManager
{
    public class DeviceManagerViewModel : INotifyPropertyChanged
    {
        public ICommand ConnectComand { get; }
        public ICommand SendCmdCommand { get; }
        
        private string[] _availableDevice;
        private string _selectedDevice;
        private readonly int[] _availableBaudRates = new int[] { 9600, 19200, 38400, 57600, 115200 };
        private int _selectedBaudRate = 115200;
        private SerialPort _serialPort = null;
        private DeviceConnectionState _connectionState = DeviceConnectionState.NotConfigured;
        private bool _isConnected = false;

        public DeviceManagerViewModel()
        {
            ConnectComand = new AnotherCommandImplementation(_ => OnConnectButtonPressed());
            SendCmdCommand = new AnotherCommandImplementation(_ => SendCommand());
        }

        public DeviceConnectionState ConnectionState {
            get { return _connectionState; }
            private set {
                _connectionState = value;
                OnConnetionStateChanged();
                OnPropertyChanged("ConnectionState");
            }
        }
        public bool IsConnected {
            get { return _isConnected; }
            private set {
                _isConnected = value;
                OnPropertyChanged("IsConnected");
            }
        }
        public string[] AvailableDevice {
            get { return _availableDevice; }
            set {
                _availableDevice = value;
                OnPropertyChanged("AvailableDevice");
            }
        }
        public string SelectedDevice {
            get { return _selectedDevice; }
            set {
                _selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
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
                    _serialPort = new SerialPort(SelectedDevice);
                    _serialPort.BaudRate = SelectedBaudRate;
                    _serialPort.Open();
                    if (_serialPort.IsOpen)
                        ConnectionState = DeviceConnectionState.Connected;
                    break;
                case DeviceConnectionState.Connected:
                    _serialPort.Close();
                    if (!_serialPort.IsOpen)
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

        private void SendCommand()
        {
            _serialPort.WriteLine("Begin hi");
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
