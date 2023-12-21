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
    /// Логика взаимодействия для Locations_items.xaml
    /// </summary>
    public partial class Locations_items : UserControl
    {
        Locations locations;
        public Locations_items(Locations _locations)
        {
            InitializeComponent();
            locations = _locations;
            if(_locations.Count_structures != null)
            {
                Country.Content = _locations.Country;
                City.Content = "Город: " + _locations.City;
                Address.Content = "Адрес: " + _locations.Address;
                Square.Content = "Занимаемая площадь в м^2: " + _locations.Square;
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Locations(locations));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.locations);
        }
    }
}
