using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MHFU
{
    /// <summary>
    /// Interaction logic for wDecoration.xaml
    /// </summary>
    public partial class wDecoration : Window
    {
        Data _data = new Data();
        public wDecoration()
        {
            InitializeComponent();
            Loaded += wDecoration_Loaded;
            TxtSearch.TextChanged += TxtSearch_TextChanged;
            dgDecorations.SelectionChanged += dgDecorations_SelectionChanged;
        }

        void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                dgDecorations.DataContext = _data.Decorations;
                dgDecorations.SelectedIndex = 0;
                gbDecorations.Header = "Decorations (" + _data.Decorations.Count() + ")";
            }

            else
            {
                var search = TxtSearch.Text.ToLower();
                dgDecorations.DataContext =
                    _data.Decorations.Where(
                        decoration =>
                        decoration.Item1.Name.Contains(search) || decoration.SkillA.Tree.Contains(search) ||
                        decoration.SkillB.Tree.Contains(search));

                gbDecorations.Header = "Decorations (" + dgDecorations.Items.Count + "/" + _data.Decorations.Count() + ")";
                dgDecorations.SelectedIndex = 0;
            }
        }

        void dgDecorations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Decoration decoration = dgDecorations.SelectedItem as Decoration;
            if (decoration == null) return;

            dgProduce.DataContext   = _data.Decoration_Ingredients.Where(d => d.Dec.ID == decoration.ID && !d.Alt);
            dgAlt.DataContext       = _data.Decoration_Ingredients.Where(d => d.Dec.ID == decoration.ID && d.Alt);
            gbAlt.Visibility        = dgAlt.Items.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        void wDecoration_Loaded(object sender, RoutedEventArgs e)
        {
            dgDecorations.DataContext = _data.Decorations;
            dgDecorations.SelectedIndex = 0;
            gbDecorations.Header = "Decorations (" + _data.Decorations.Count() + ")";
        }
    }
}
