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
    /// Interaction logic for wSkills.xaml
    /// </summary>
    public partial class wSkills : Window
    {
        Data _data = new Data();
        public wSkills()
        {
            InitializeComponent();
            Loaded += wSkills_Loaded;
            dgSkills.SelectionChanged += dgSkills_SelectionChanged;
        }

        void dgSkills_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Skill skill = dgSkills.SelectedItem as Skill;
            if (skill == null) return;

            dgDecorations.DataContext =
                _data.Decorations.Where(
                    decoration =>
                    decoration.SkillA.ID == skill.Skill_Tree.ID || decoration.SkillB.ID == skill.Skill_Tree.ID);
        }

        void wSkills_Loaded(object sender, RoutedEventArgs e)
        {

            dgSkills.DataContext = _data.Skills;
            dgSkills.SelectedIndex = 0;

        }
    }
}
