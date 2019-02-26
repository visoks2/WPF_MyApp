using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Pages.DeviceManager.ConnectionManager
{
    public enum DeviceConnectionState
    {
        NotConfigured,
        Validating,
        CanConnect,
        Connected,
        Connecting,
        Disconnected
    }
}
