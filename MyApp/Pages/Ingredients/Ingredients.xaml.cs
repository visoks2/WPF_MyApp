using MyApp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyApp.Pages.Ingredients
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Ingredients : UCBase
    {
        public Ingredients()
        {
            InitializeComponent();
        }

        public override void OnActivated()
        {
            IngredientsViewModel.RefreshComand.Execute(null);
            base.OnActivated();
        }

        public override void OnDeactivated()
        {
            IngredientsViewModel.SaveComand.Execute(null);
            base.OnDeactivated();
        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 3);
        }
    }
}
