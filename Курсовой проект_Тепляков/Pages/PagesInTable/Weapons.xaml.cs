using ClassModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Курсовой_проект_Тепляков.Pages.PagesInTable
{
    /// <summary>
    /// Логика взаимодействия для Weapons.xaml
    /// </summary>
    public partial class Weapons : Page
    {
        ClassModules.Weapons weapons;
        public Weapons(ClassModules.Weapons _weapons)
        {
            InitializeComponent();
            weapons = _weapons;
            if (_weapons.Name_weapons != null)
            {
                Name_weapons.Text = _weapons.Name_weapons;
            }
        }

        private void Click_Weapons_Redact(object sender, RoutedEventArgs e)
        {
            if (Name_weapons.Text != "")
            {
                int id = MainWindow.connect.SetLastId(ClassConnection.Connection.Tables.weapons);
                if (weapons.Name_weapons == null)
                {
                    string query = $"Insert Into weapons ([Id_weapons], [Name_weapons]) Values ({id.ToString()}, '{Name_weapons.Text}')";
                    var query_apply = MainWindow.connect.Query(query);
                    if (query_apply != null)
                    {
                        MainWindow.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                        MessageBox.Show("Успешное добавление вооружения!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.weapons);
                    }
                    else MessageBox.Show("Запрос на добавление вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string query = $"Update weapons Set Name_weapons = '{Name_weapons.Text}' Where Id_weapons = {weapons.Id_weapons}";
                    var query_apply = MainWindow.connect.Query(query);
                    if (query_apply != null)
                    {
                        MainWindow.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                        MessageBox.Show("Успешное изменение вооружения!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.weapons);
                    }
                    else MessageBox.Show("Запрос на изменение вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else MessageBox.Show("Вы не ввели вооружение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Click_Cancel_Weapons_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_Weapons_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                string query = "Delete From weapons Where [Id_weapons] = " + weapons.Id_weapons.ToString() + "";
                var query_apply = MainWindow.connect.Query(query);
                if (query_apply != null)
                {
                    MessageBox.Show("Успешное удаление вооружения!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.weapons);
                }
                else MessageBox.Show("Запрос на удаление вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
