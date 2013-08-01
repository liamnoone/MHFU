using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MHFU
{
    /// <summary>
    /// Interaction logic for wCombo.xaml
    /// </summary>
    public partial class wCombo
    {
        Data _data = new Data();
        public wCombo()
        {
            InitializeComponent();
            Loaded += wCombo_Loaded;
        }

        // Open Window and scroll to the passed combo
        public wCombo(Combo c)
        {
            InitializeComponent();
            Loaded += wCombo_Loaded;
            
            dgTable.DataContext = _data.Combos;
            dgTable.SelectedIndex = c.ID - 1;
            dgTable.ScrollIntoView(c);
            dgTable.UpdateLayout();
        }

        void wCombo_Loaded(object sender, RoutedEventArgs e)
        {
            dgTable.DataContext = _data.Combos;
            

        }

        private void Refine(object sender, TextChangedEventArgs e)
        {
            string search = TxtRefine.Text.ToLower();
            dgTable.DataContext =
                _data.Combos.Where(
                    c =>
                    c.Item.Name.ToLower().Contains(search) || 
                    c.Item1.Name.ToLower().Contains(search) ||
                    c.Item2.Name.ToLower().Contains(search));

        }
    }
}
