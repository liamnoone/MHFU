using System.Windows;

namespace MHFU
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class wMain : Window
    {
        public wMain()
        {
            InitializeComponent();

            Trenya.Click += (sender, args) => new wTrenya().Show();
            Combo.Click += (sender, args) => new wCombo().Show();
            Items.Click += (sender, args) => new wItem().Show();

            Monsters.Click += (sender, args) => new wMonster().Show();
            VeggieElder.Click += (sender, args) => new wVeggieElder().Show();

            Exit.Click += (sender, args) => Close();
        }
    }
}
