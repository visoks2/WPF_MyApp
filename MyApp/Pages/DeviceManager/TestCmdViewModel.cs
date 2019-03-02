using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyApp.Domain;

namespace MyApp.Pages.DeviceManager
{
    public class TestCmdViewModel : BaseViewModel
    {
        private bool _isSelected;
        private string _description;
        private string _command;
        private double _frequency;
        private double _repeatTimes;

        public bool IsSelected {
            get { return _isSelected; }
            set {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public string Command {
            get { return _command; }
            set {
                if (_command == value) return;
                _command = value;
                OnPropertyChanged();
            }
        }

        public string Description {
            get { return _description; }
            set {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public double Frequency {
            get { return _frequency; }
            set {
                if (_frequency == value) return;
                _frequency = value;
                OnPropertyChanged();
            }
        }

        public double RepeatTimes {
            get { return _repeatTimes; }
            set {
                if (_repeatTimes == value) return;
                _repeatTimes = value;
                OnPropertyChanged();
            }
        }
    }
}
