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
    /// Логика взаимодействия для TypeOfTroops_items.xaml
    /// </summary>
    public partial class TypeOfTroops_items : UserControl
    {
        ClassModules.Type_of_troops type_of_troops;
        public TypeOfTroops_items(ClassModules.Type_of_troops _type_of_troops)
        {
            InitializeComponent();
            if (Pages.Login_Regin.Login.UserInfo[1] != "admin") Buttons.Visibility = Visibility.Hidden;
            type_of_troops = _type_of_troops;
            if(_type_of_troops.Name_type_of_troops != null)
            {
                Name_type_of_troops.Content = "Название вида войск: " + _type_of_troops.Name_type_of_troops;
                Description.Content = "Описание: " + _type_of_troops.Description;
                Companies.Content = "Название роты: " + Connection.companies.Find(x => x.Id_companies == _type_of_troops.Companies).Name_companies;
                Count_serviceman.Content = "Количество военнослужащих: " + _type_of_troops.Count_serviceman;
                Date_foundation.Content = "Дата создания: " + _type_of_troops.Date_foundation.ToString("dd.MM.yyyy");
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Type_of_troops(type_of_troops));

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить информацию о виде войск?", "Удаление информации", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Pages.Login_Regin.Login.connection.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                    string query = $"Delete From Type_of_troops Where Id_type_of_troops = " + type_of_troops.Id_type_of_troops.ToString() + "";
                    var query_apply = Pages.Login_Regin.Login.connection.Query(query);
                    if (query_apply != null)
                    {
                        Pages.Login_Regin.Login.connection.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.type_of_troops);
                    }
                    else MessageBox.Show("Запрос на удаление вида войск не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
