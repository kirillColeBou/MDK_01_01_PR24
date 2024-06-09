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
            if (Pages.Login_Regin.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            weapons = _weapons;
            if(_weapons.Name_weapons != null)
            {
                Id_weapons.Content = "Вооружение № " + _weapons.Id_weapons;
                Name_weapons.Content = "Название вооружения: " + _weapons.Name_weapons;
                Companies.Content = "Название роты: " + Connection.companies.Find(x => x.Id_companies == _weapons.Companies).Name_companies;
                Description.Content = "Описание: " + _weapons.Description;
                Date_update_information.Content = "Дата обновления информации: " + _weapons.Date_update_information.ToString("dd.MM.yyyy HH:mm:ss");
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Weapons(weapons));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить информацию о вооружении?", "Удаление информации", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Pages.Login_Regin.Login.connection.LoadData(ClassConnection.Connection.Tables.weapons);
                    string query = $"Delete From Weapons Where Id_weapons = " + weapons.Id_weapons.ToString() + "";
                    var query_apply = Pages.Login_Regin.Login.connection.Query(query);
                    if (query_apply != null)
                    {
                        Pages.Login_Regin.Login.connection.LoadData(ClassConnection.Connection.Tables.weapons);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.weapons);
                    }
                    else MessageBox.Show("Запрос на удаление вида вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
