using ClassModules;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовой_проект_Тепляков.Elements
{
    /// <summary>
    /// Логика взаимодействия для Weapons_items.xaml
    /// </summary>
    public partial class Weapons_items : UserControl
    {
        Weapons weapons;
        public Weapons_items(Weapons _weapons)
        {
            InitializeComponent();
            weapons = _weapons;
            if(_weapons.Name_weapons != null)
            {
                Id_weapons.Content = "Вооружение № " + _weapons.Id_weapons;
                Name_weapons.Content = _weapons.Name_weapons;
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Weapons(weapons));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.weapons);
        }
    }
}
