using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace MHFU
{
    public partial class App
    {
        // http://stackoverflow.com/questions/7334208/expanders-in-grid
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

    /// <summary> Gets various image paths depending on the object </summary>
    public class ImageConvertor : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            if (value is Carve)
            {
                if ((string) parameter == "MonsterIcon")
                    return String.Format("images/monsters/{0} Icon.png", (value as Carve).Monster1.Name);
                return String.Format("images/items/{0}.png", (value as Carve).Item1.Icon);
            }
            if (value is Monster)
            {
                if ((string) parameter == "Icon") return String.Format("/images/monsters/{0} Icon.png", (value as Monster).Name);
                return String.Format("images/monsters/{0} Icon.png", (value as Monster).Name);
            }
            if (value is Item) return String.Format("images/items/{0}.png", (value as Item).Icon);
            if (value is Trenya) return String.Format("images/areas/{0}.png", (value as Trenya).Loc.Loc);
            if (value is Veggie_Elder)
            {
                var v = value as Veggie_Elder;
                if ((string) parameter == "Location") return String.Format("images/areas/{0}.png", v.Location.Loc);
                string source;
                if ((string) parameter == "Trade") source = v.TradeItem.Icon;
                else if ((string)parameter == "Rare") source = v.RareItem.Icon;
                else source = v.CommonItem.Icon;
                return String.Format("images/items/{0}.png", source);
            }
            if (value is Decoration) return String.Format("images/items/{0}.png", (value as Decoration).Item1.Icon);
            if (value is Decoration_Ingredient)
                return String.Format("images/items/{0}.png", (value as Decoration_Ingredient).Dec_Ingredient.Icon);
            switch (parameter as string)
            {
                //case "Area":
                  //  return String.Format("images/areas/{0}.png", (value as Trenya).Location);
                case "Combo 1":
                    return String.Format("images/items/{0}.png", (value as Combo).Item1.Icon);
                case "Combo 2":
                    return String.Format("images/items/{0}.png", (value as Combo).Item2.Icon);
                case "Combo Result":
                    return String.Format("images/items/{0}.png", value is Combo ? (value as Combo).Item.Icon : value);
                case "Location":
                    {
                        var x = value.ToString().Split(new [] {',', '='});
                        return String.Format("images/areas/{0}.png", x[3]);
                    }
                case "Trade":
                    {
                        var x = value.ToString().Split(new char[] {',', '='});
                        return String.Format("images/areas/{0}.png", x[3]);
                    }
                case null: return "";
                default: return String.Format("images/items/{0}.png", (value as Item).Icon);
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> If there isn't a buy (very common) / sell price, show "--", otherwise show [PRICE]z </summary>
    public class PriceConvertor : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var v = value as Item;
            if (v == null) return "";

            if ((string) parameter == "Buy")
            {
                if (v.Buy == null) return "‒‒";
                return v.Buy + "z";
            }
            if ((string) parameter == "Sell")
            {
                if (v.Sell == null) return "‒‒";
                return v.Sell + "z";
            }
            return "";
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
    /// <summary> Determines whether the item is a Common or a Rare trade. </summary>
    public class TradeConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
        {
            var item = values[0] as Item;
            var veggieElder = values[1] as Veggie_Elder;
            if (veggieElder == null || item == null) return "";
            return veggieElder.CommonItem == item ? "Common" : "Rare";
        }

        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary> Determines the correct points value for the correct skill </summary>
    public class PointConvertor : IMultiValueConverter
    {
        public object Convert(object[] value, System.Type targetType, object parameter, CultureInfo culture)
        {
            var skill = value[0] as Skill;
            var decoration = value[1] as Decoration;
            if (skill == null || decoration == null) return "999999999";
            if (decoration.SkillA.ID == skill.Skill_Tree.ID) return decoration.Skill_A_Points.ToString("+0;0");
            if (decoration.SkillB != null) { if (decoration.SkillB.ID == skill.Skill_Tree.ID) return decoration.Skill_B_Points.ToString(); }
            return "+00";
        }

        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
