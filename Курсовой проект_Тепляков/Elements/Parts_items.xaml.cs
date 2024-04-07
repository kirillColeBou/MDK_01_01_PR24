using ClassConnection;
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
using Курсовой_проект_Тепляков.Pages;
using Курсовой_проект_Тепляков.Pages.PagesInTable;

namespace Курсовой_проект_Тепляков.Elements
{
    /// <summary>
    /// Логика взаимодействия для Parts_items.xaml
    /// </summary>
    public partial class Parts_items : UserControl
    {
        ClassModules.Parts parts;
        public Parts_items(ClassModules.Parts _parts)
        {
            InitializeComponent();
            if (Pages.Login_Regin.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            parts = _parts;
            if(_parts.Date_of_foundation != null)
            {
                Id_part.Content = "Часть № " + _parts.Id_part;
                ClassModules.Locations item_location = Connection.locations.Find(x => x.Id_locations == _parts.Locations);
                Locations.Content = "Место дислокации: " + Connection.country.Find(x => x.Id == item_location.Country).Name;
                Type_of_troops.Content = "Вид войск: " + Connection.type_of_troops.Find(x => x.Id_type_of_troops == _parts.Type_of_troops).Name_type_of_troops;
                Weapons.Content = "Вид вооружения: " + Connection.weapons.Find(x => x.Id_weapons == _parts.Weapons).Name_weapons;
                Companies.Content = "Рота №" + _parts.Companies;
                Count_companies.Content = "Количество рот: " + _parts.Count_companies;
                Count_technique.Content = "Количество техники: " + _parts.Count_technique;
                Count_weapons.Content = "Количество вооружений: " + _parts.Count_weapons;
                Date_of_foundation.Content = "Дата основания: " + _parts.Date_of_foundation.ToString("dd.MM.yyyy");
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Parts(parts));

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                string query = $"Delete From Parts Where Id_part = " + parts.Id_part.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.parts);
                }
                else MessageBox.Show("Запрос на удаление части не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
