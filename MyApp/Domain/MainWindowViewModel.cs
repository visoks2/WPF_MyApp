using MaterialDesignThemes.Wpf;
using MyApp.Pages.DeviceManager;
using MyApp.Pages.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null) throw new ArgumentNullException(nameof(snackbarMessageQueue));

            MenuItems = new[]
            {
                new MenuItem("Home", new Home()),
                new MenuItem("Device Manager", new DeviceManager())
            };
        }

        public MenuItem[] MenuItems { get; }
    }
}
