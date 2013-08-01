using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;

namespace MHFU
{
    public partial class wTrenya
    {
        static Data _data = new Data();
        public wTrenya()
        {
            InitializeComponent();
        }

        void OnLoad(object sender, RoutedEventArgs e)
        {
            // Can't do it at design time or there's a crash!
            CboLocation.DataContext = _data.Locations.Where(location => location.Trenyas.Count(trenya => trenya.Location == location.ID) > 0);
            CboLocation.SelectedIndex = 0;

            TxtSearch.Focus();
        }

        void Search(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtSearch.Text)) return;
            string search = TxtSearch.Text.ToLower();

            List<Trenya> result = ItemSearch(search);

            StringBuilder output = new StringBuilder();
            foreach (Trenya trenya in result)
            {
                // Seperate different areas, but don't add seperator if there's no data yet
                if (!output.ToString().Contains(trenya.Loc.Loc) && output.Length != 0) output.AppendLine();
                output.AppendLine(String.Format("{0} for {1:#,###} points.", trenya.Loc.Loc, trenya.Points));
            }

            MessageBox.Show(result.Count == 0 ? "Nothing found" : output.ToString(), TxtSearch.Text);
        }


        /// <summary> Remove border whitespace </summary>
        static IEnumerable<string> rbws(IEnumerable<string> sArray)
        {
            var newList = new List<string>();
     
            foreach (string s in sArray)
            {
                List<char> array = s.ToCharArray().ToList();

                if (Char.IsWhiteSpace(array[0])) array.RemoveAt(0);
                if (Char.IsWhiteSpace(array[array.Count - 1])) array.RemoveAt(array.Count - 1);
                
                StringBuilder sb = new StringBuilder();
                array.ToList().ForEach(c => sb.Append(c));
                newList.Add(sb.ToString());
            }

            return newList;
        }
        // TODO: Move icon stuff to XAML
        void Update(object sender, SelectionChangedEventArgs e)
        {
            if (CboLocation == null || CboPoints.SelectedValue == null) return;

            Trenya result =
                _data.Trenyas.First(
                    x =>
                    // Splitting & arrays because you can't (?) get the displayed value without bindings (and i don't want to deal with relationships)!
                    x.Location == (int)CboLocation.SelectedValue &&
                    x.Points == Convert.ToInt32(ComboBoxHelper(CboPoints)));

            Fill(result, LstResults);
        }

        void Fill(Trenya trenya, ListBox list)
        {
            const int padding = 10;
            list.Items.Clear();

            list.Items.Add(String.Format("{0} {1}", "General".PadRight(padding), trenya.General));
            list.Items.Add(String.Format("{0} {1}", "Mineral".PadRight(padding), trenya.Mineral));
            list.Items.Add(String.Format("{0} {1}", "Fish".PadRight(padding + 3), trenya.Fish));
            list.Items.Add(String.Format("{0} {1}", "Insect".PadRight(padding + 2), trenya.Insect));
            list.Items.Add(String.Format("{0} {1}", "Unique".PadRight(padding + 0), trenya.Unique));
            list.Items.Add(String.Format("{0} {1}", "Monster".PadRight(padding - 1), trenya.Monster));
            list.Items.Add(String.Format("{0} {1}", "Jewel".PadRight(padding + 2), trenya.Jewel));
        }

        string ComboBoxHelper(ComboBox cbx)
        {
            if (cbx == null || cbx.SelectedValue == null) return null;
            string[] split = cbx.SelectedValue.ToString().Split(' ');
            if (split.Length == 4) return split[1] + ' ' + split[2] + ' ' + split[3];
            if (split.Length == 3) return split[1] + ' ' + split[2];
            return split[1];
        }

        static public List<Trenya> ItemSearch(string item)
        {
            item = item.ToLower();
            var data = _data.Trenyas.Select(x => x);

            List<Trenya> result = new List<Trenya>();
            foreach (Trenya trenya in data)
            {
                IEnumerable<string> general = rbws(trenya.General.ToLower().Split(','));
                IEnumerable<string> mineral = rbws(trenya.Mineral.ToLower().Split(','));
                IEnumerable<string> fish = rbws(trenya.Fish.ToLower().Split(','));
                IEnumerable<string> insect = rbws(trenya.Insect.ToLower().Split(','));
                IEnumerable<string> unique = rbws(trenya.Unique.ToLower().Split(','));
                IEnumerable<string> monster = rbws(trenya.Monster.ToLower().Split(','));
                IEnumerable<string> jewel = rbws(trenya.Jewel.ToLower().Split(','));

                if (general.Contains(item) || mineral.Contains(item) || fish.Contains(item) ||
                    insect.Contains(item) || unique.Contains(item) || monster.Contains(item) ||
                    jewel.Contains(item))
                {
                    result.Add(trenya);
                }
 
            }
            return result;
        }
    }
}
