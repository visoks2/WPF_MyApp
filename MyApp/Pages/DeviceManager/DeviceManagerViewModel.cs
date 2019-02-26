using MyApp.Domain;
using MyApp.Pages.DeviceManager.ConnectionManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;
using System.Windows.Input;

namespace MyApp.Pages.DeviceManager
{
    public class DeviceManagerViewModel : BaseViewModel
    {
        public ICommand StartComand { get; }

        #region Private variables
        private Timer _timer ;
        #endregion
        #region Constructor
        public DeviceManagerViewModel()
        {
            StartComand = new AnotherCommandImplementation(_ => Start());

            _items3 = CreateData();
            _timer = new Timer(1);
            _timer.Elapsed += _timer_Elapsed;
            SerialPort.DataReceived += SerialPort_DataReceived;
        }
        #endregion
        #region Properties
        private SerialPort SerialPort {
            get { return Devices.SerialPort; }
        }
        #endregion
        #region Public methods
        #endregion
        #region Private methods
        private void Start()
        {
            _timer.Start();
            i = 0;
        }
        #endregion
        #region Callbacks
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            changed = 5;
            if (i-1< Items3.Count)
                 Items3[i-1].Description += SerialPort.ReadExisting();
            //throw new NotImplementedException();
        }

        int i = 0;
        int state = 0;
        int changed = 5;
        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            switch (state)
            {
                case 0:
                    for (; i < Items3.Count; i++)
                    {
                        if (Items3[i].IsSelected)
                        {
                            Items3[i].Description = string.Empty;
                            SerialPort.WriteLine(Items3[i].Command);
                            state = 1;
                            break;
                        }
                    }
                    i++;
                    if (i >= Items3.Count)
                        _timer.Stop();
                    break;
                case 1:
                    changed--;
                    if (changed == 0)
                    {
                        state = 0;
                    }
                    break;
            }

        }
        #endregion



        private  ObservableCollection<TestCmdViewModel> _items3;
        public ObservableCollection<TestCmdViewModel> Items3 => _items3;
        private static ObservableCollection<TestCmdViewModel> CreateData()
        {
            return new ObservableCollection<TestCmdViewModel>
            {
                new TestCmdViewModel
                {
                    Command = "\x01\x02Help\x03\x04",
                    Description = "Hello world",
                    Frequency = 0,
                    RepeatTimes = 1
                },
                new TestCmdViewModel
                {
                    Command = "\x01\x02Hello\x03\x04",
                    Description = "Hello world",
                    Frequency = 0,
                    RepeatTimes = 1
                },
            };
        }

        //public IEnumerable<string> Foods {
        //    get {
        //        yield return "Burger";
        //        yield return "Fries";
        //        yield return "Shake";
        //        yield return "Lettuce";
        //    }
        //}
        private bool? _isAllItems3Selected;

        public bool? IsAllItems3Selected {
            get { return _isAllItems3Selected; }
            set {
                if (_isAllItems3Selected == value) return;

                _isAllItems3Selected = value;

                if (_isAllItems3Selected.HasValue)
                    SelectAll(_isAllItems3Selected.Value, Items3);

                OnPropertyChanged();
            }
        }

        private static void SelectAll(bool select, IEnumerable<TestCmdViewModel> models)
        {
            foreach (var model in models)
            {
                model.IsSelected = select;
            }
        }
    }

}
