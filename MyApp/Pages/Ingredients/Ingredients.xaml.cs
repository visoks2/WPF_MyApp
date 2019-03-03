using MyApp.Domain;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            viewModel.RefreshComand.Execute(null);
            base.OnActivated();
        }

        public override void OnDeactivated()
        {
            viewModel.SaveComand.Execute(null);
            base.OnDeactivated();
        }

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 3);
        }
    }
}
