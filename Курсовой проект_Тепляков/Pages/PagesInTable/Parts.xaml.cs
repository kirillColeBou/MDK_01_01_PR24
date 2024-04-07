using ClassModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовой_проект_Тепляков.Pages.PagesInTable
{
    /// <summary>
    /// Логика взаимодействия для Parts.xaml
    /// </summary>
    public partial class Parts : Page
    {
        ClassModules.Parts parts;
        public Parts(ClassModules.Parts _parts)
        {
            InitializeComponent();
            parts = _parts;
            Main.connect.LoadData(ClassConnection.Connection.Tables.locations);
            foreach (var item in ClassConnection.Connection.locations)
            {
                ComboBoxItem cb_locations = new ComboBoxItem();
                cb_locations.Tag = item.Id_locations;
                cb_locations.Content = item.Country;
                if (_parts.Locations == item.Id_locations) cb_locations.IsSelected = true;
                Locations.Items.Add(cb_locations);
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.companies);
            foreach (var item in ClassConnection.Connection.companies)
            {
                ComboBoxItem cb_companies = new ComboBoxItem();
                cb_companies.Tag = item.Id_companies;
                cb_companies.Content = item.Name_companies;
                if (_parts.Companies == item.Id_companies) cb_companies.IsSelected = true;
                Companies.Items.Add(cb_companies);
            }
        }

        private void Click_Parts_Redact(object sender, RoutedEventArgs e)
        {
            if (Locations.SelectedItem != null)
            {
                if (Companies.SelectedItem != null)
                {
                    ClassModules.Locations id_locations_temp;
                    ClassModules.Companies id_companies_temp;
                    id_locations_temp = ClassConnection.Connection.locations.Find(x => x.Id_locations == Convert.ToInt32(((ComboBoxItem)Locations.SelectedItem).Tag));
                    id_companies_temp = ClassConnection.Connection.companies.Find(x => x.Id_companies == Convert.ToInt32(((ComboBoxItem)Companies.SelectedItem).Tag));
                    int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.parts);
                    if (parts.Companies == 0)
                    {
                        string query = $"Insert Into parts ([Id_part], [Locations], [Companies], [Date_of_foundation])" +
                            $"Values ({id.ToString()}, {id_locations_temp.Id_locations.ToString()}, {id_companies_temp.Id_companies.ToString()}, N'{DateTime.Now.ToString("dd.MM.yyyy")}')";
                        var query_apply = Main.connect.Query(query);
                        if (query_apply != null)
                        {
                            Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.parts);
                        }
                        else MessageBox.Show("Запрос на добавление части не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        string query = $"Update parts Set Locations = '{id_locations_temp.Id_locations.ToString()}', Companies = '{id_companies_temp.Id_companies.ToString()}' Where Id_part = {parts.Id_part}";
                        var query_apply = Main.connect.Query(query);
                        if (query_apply != null)
                        {
                            Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.parts);
                        }
                        else MessageBox.Show("Запрос на изменение части не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void Click_Cancel_Parts_Redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);

        private void Click_Remove_Parts_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                string query = "Delete parts Where [Id_part] = " + parts.Id_part.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                    Main.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.parts);
                }
                else MessageBox.Show("Запрос на удаление части не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
