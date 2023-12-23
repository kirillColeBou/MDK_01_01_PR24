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
        ClassConnection.Connection connection;
        ClassModules.Type_of_troops type_of_troops;
        public TypeOfTroops_items(ClassModules.Type_of_troops _type_of_troops)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (connection.RoleUser() != "admin")
            {
                Buttons.Visibility = Visibility.Hidden;
            }
            type_of_troops = _type_of_troops;
            if(_type_of_troops.Name_type_of_troops != null)
            {
                Name_type_of_troops.Content = _type_of_troops.Name_type_of_troops;
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Type_of_troops(type_of_troops));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                string query = $"Delete From Type_of_troops Where Id_type_of_troops = " + type_of_troops.Id_type_of_troops.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.type_of_troops);
                }
                else MessageBox.Show("Запрос на удаление вида войск не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
