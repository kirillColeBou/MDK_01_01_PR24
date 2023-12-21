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
    /// Логика взаимодействия для Parts_items.xaml
    /// </summary>
    public partial class Parts_items : UserControl
    {
        Parts parts;
        public Parts_items(Parts _parts)
        {
            InitializeComponent();
            parts = _parts;
            if(_parts.Date_of_foundation != null)
            {
                Id_part.Content = "Часть № " + _parts.Id_part;
                Locations.Content = "Место дислокации: " + _parts.Locations;
                Type_of_troops.Content = "Вид войск: " + _parts.Type_of_troops;
                Weapons.Content = "Вид вооружения: " + _parts.Weapons;
                Companies.Content = "Рота: " + _parts.Companies;
                Count_companies.Content = "Количество рот: " + _parts.Count_companies;
                Count_technique.Content = "Количество техники: " + _parts.Count_technique;
                Count_weapons.Content = "Количество вооружений: " + _parts.Count_weapons;
                Date_of_foundation.Content = "Дата основания: " + _parts.Date_of_foundation.ToString("dd.MM.yyyy");
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Parts(parts));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.parts);
        }
    }
}
