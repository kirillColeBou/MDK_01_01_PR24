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
                Companies.Content = "Название роты: " + Connection.companies.Find(x => x.Id_companies == _parts.Companies).Name_companies;
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
