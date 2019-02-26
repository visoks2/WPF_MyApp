using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Pages.DeviceManager
{
    public static class Devices
    {
        private static SerialPort _serialPort = new SerialPort();

        public static SerialPort SerialPort {
            get { return _serialPort; }
            //set { _serialPort = value; }
        }

    }
}
