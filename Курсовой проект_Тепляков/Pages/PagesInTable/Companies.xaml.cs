using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Companies.xaml
    /// </summary>
    public partial class Companies : Page
    {
        ClassModules.Companies companies;
        public Companies(ClassModules.Companies _companies)
        {
            InitializeComponent();
            companies = _companies;
            if (_companies.Commander != null)
            {
                Commander.Text = _companies.Commander;
            }
        }

        private void Click_Companies_Redact(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(Commander.Text, @"[А-Яа-я.,'0-9 ]*"))
            {
                MessageBox.Show("ФИО командира введено не правильно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (Commander.Text != null)
            {
                int id = MainWindow.connect.SetLastId(ClassConnection.Connection.Tables.companies);
                if (companies.Commander == null)
                {
                    string query = $"INSERT INTO companies ([Id_companies], [Commander]) VALUES ({id.ToString()}, '{Commander.Text}')";
                    var query_apply = MainWindow.connect.Query(query);
                    if (query_apply != null)
                    {
                        MainWindow.connect.LoadData(ClassConnection.Connection.Tables.companies);
                        MessageBox.Show("Успешное добавление роты!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.companies);
                    }
                    else MessageBox.Show("Запрос на добавление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string query = $"UPDATE companies SET Commander = '{Commander.Text}' WHERE Id_companies = {companies.Id_companies}";
                    var query_apply = MainWindow.connect.Query(query);
                    if (query_apply != null)
                    {
                        MainWindow.connect.LoadData(ClassConnection.Connection.Tables.companies);
                        MessageBox.Show("Успешное изменение роты!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.companies);
                    }
                    else MessageBox.Show("Запрос на изменение роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else MessageBox.Show("Вы не ввели ФИО командира!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Click_Cancel_Companies_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_Companies_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.Tables.companies);
                string query = "Delete From companies Where [Id_companies] = " + companies.Id_companies.ToString() + "";
                var query_apply = MainWindow.connect.Query(query);
                if(query_apply != null)
                {
                    MessageBox.Show("Успешное удаление роты!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(ClassConnection.Connection.Tables.companies);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.companies);
                }
                else MessageBox.Show("Запрос на удаление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
