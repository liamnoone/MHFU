using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MHFU
{
    /// <summary>
    /// Interaction logic for wVeggieElder.xaml
    /// </summary>
    public partial class wVeggieElder
    {
        Data _data = new Data();
        public wVeggieElder()
        {
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            // Set the list of locations to all locations that have a trade in them
            cbLocation.DataContext =
                _data.Locations.Where(
                    location => location.Veggie_Elders.Count(elders => elders.Location.ID == location.ID) > 0);
            cbLocation.SelectedIndex = 0;
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgItems.DataContext = _data.Veggie_Elders.Where(elder => elder.Location == cbLocation.SelectedItem);
        }
    }
}
