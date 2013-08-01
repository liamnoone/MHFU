using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MHFU
{
    public partial class wMonster
    {
        Data _data = new Data();
        public wMonster()
        {
            InitializeComponent();

            Loaded += wMonster_Loaded;
        }

        void wMonster_Loaded(object sender, RoutedEventArgs e)
        {
            dgMonsters.DataContext = _data.Monsters;
            dgMonsters.SelectedIndex = 0;


            txtRefine.TextChanged += (o, args) =>
                {
                    dgMonsters.DataContext =
                        _data.Monsters.Where(c => c.Name.ToLower().Contains(txtRefine.Text.ToLower()));
                    dgMonsters.SelectedIndex = 0;
                };
        }

        private void DgMonsters_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMonsters.SelectedIndex == -1 || dgMonsters.SelectedItem == null) return;
            Monster monster = dgMonsters.SelectedItem as Monster;
            if (monster == null) return;
            imgIcon.DataContext = _data.Monsters.First(m => m.ID == monster.ID);
            
            dgLowRank.DataContext = _data.Carves.Where(carve => ((carve.Monster1.ID == monster.ID) && (carve.Rank == 1 || carve.Rank == 0)));
            dgHighRank.DataContext = _data.Carves.Where(carve => ((carve.Monster1.ID == monster.ID) && (carve.Rank == 2 || carve.Rank == 0)));
            dgGRank.DataContext = _data.Carves.Where(carve => ((carve.Monster1.ID == monster.ID) && (carve.Rank == 3 || carve.Rank == 0)));

            gbKing.Header = monster.Max_Length == null
                                ? "King Crown"
                                : String.Format("King Crown (Max size: {0:#,###.#})", monster.Max_Length);
            gbMini.Header = monster.Min_Length == null
                                ? "Mini Crown"
                                : String.Format("Mini Crown (Min size: {0:#,###.#})", monster.Min_Length);
            bImage.Visibility = imgIcon.Source != null ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
