using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using MHFU;

namespace MHFU
{
    /// <summary>
    /// Interaction logic for wItem.xaml
    /// </summary>
    public partial class wItem
    {
        private Data _data = new Data();
        public wItem()
        {
            InitializeComponent();
            Loaded += wItem_Loaded;
            Search.Focus();
        }

        void wItem_Loaded(object sender, RoutedEventArgs e)
        {
            dgItems.DataContext = _data.Items;
            dgCombo.MouseDoubleClick += goToCombo;
            dgCombo2.MouseDoubleClick += goToCombo;
            dgItems.SelectedIndex = 0;
        }

        void goToCombo(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Combo c = (((DataGrid) sender).SelectedItem as Combo);
            if (dgItems.SelectedItem == null || dgItems.SelectedIndex == -1 || c == null) return;
            new wCombo(c).Show();
        }

        private void Refine(object sender, TextChangedEventArgs e)
        {
            dgItems.DataContext = _data.Items.Where(i => i.Name.ToLower().Contains(Search.Text.ToLower()));
            gbSearch.Header = String.Format(
                String.IsNullOrWhiteSpace(Search.Text) ? "Search" : "Search ({0} / {1} items)", dgItems.Items.Count,
                _data.Items.Count());


            dgItems.SelectedIndex = 0;
        }

        private void ItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (dgItems.SelectedItem == null || dgItems.SelectedIndex == -1) return;
            Item item = (dgItems.SelectedItem as Item);
            if (item == null) return;
#region USES

            dgDecoration.DataContext =
                _data.Decoration_Ingredients.Where(decoration => decoration.Dec_Ingredient.ID == item.ID);
            UpdateExpander(expDecoration, dgDecoration, "Decorations");

            var q = _data.Combos.Where(c => c.Item1.ID == item.ID || c.Item2.ID == item.ID);
            IList<Combo> qq = new List<Combo>();
            foreach (var combo in q)
            {
                qq.Add(new Combo 
                    {
                        ID = combo.ID,
                        Item = combo.Item,
                        Item2 = combo.Item2.ID == item.ID ? combo.Item1 : combo.Item2,
                        Success = combo.Success,
                        Quantity = combo.Quantity,
                        Alchemy = combo.Alchemy
                    });
            }

            dgCombo.DataContext = qq;
            UpdateExpander(expCombo, dgCombo, "Combos");

            dgVeggie.DataContext = _data.Veggie_Elders.Where(elder => elder.TradeItem.ID == item.ID);
            UpdateExpander(expVeggie, dgVeggie, "Veggie Elder");
#endregion

#region SOURCES
            dgMonster.DataContext = _data.Carves.Where(c => c.Item1.ID == item.ID);
            UpdateExpander(expMonster, dgMonster, "Monsters");

            dgTrenya.DataContext = wTrenya.ItemSearch(item.Name.ToLower());
            UpdateExpander(expTrenya, dgTrenya, "Trenya");
            
            dgCombo2.DataContext = _data.Combos.Where(c => c.Item.Name == item.Name);
            UpdateExpander(expCombo2, dgCombo2, "Combos");

            dgVeggie2.DataContext =
                _data.Veggie_Elders.Where(elder => elder.RareItem.ID == item.ID || elder.CommonItem.ID == item.ID);
            UpdateExpander(expVeggie2, dgVeggie2, "Veggie Elder");

            #endregion
        }

        private void UpdateExpander(Expander expander, DataGrid dataGrid, string header)
        {
            if (expander == null || dataGrid == null) return;
            expander.IsExpanded = dataGrid.Items.Count > 0;
            expander.Header = String.Format("{0} ({1})", header, dataGrid.Items.Count);
        }

        void ExpanderExpandOrCollapse(object sender, RoutedEventArgs e)
        {
            Expander ex = sender as Expander;
            Grid parent = FindAncestor<Grid>(ex);
            int rowIndex = Grid.GetRow(ex);

            if (parent.RowDefinitions.Count > rowIndex && rowIndex >= 0)
                parent.RowDefinitions[rowIndex].Height =
                    (ex.IsExpanded ? new GridLength(1, GridUnitType.Star) : GridLength.Auto);
        }

        public static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            // Need this call to avoid returning current object if it is the 
            // same type as parent we are looking for
            current = VisualTreeHelper.GetParent(current);

            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            };
            return null;
        }
    }
}
