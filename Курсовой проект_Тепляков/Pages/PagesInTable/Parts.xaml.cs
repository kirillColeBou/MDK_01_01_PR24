using ClassModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            if (Count_companies.Text != null)
            {
                Count_companies.Text = _parts.Count_companies;
                Count_technique.Text = _parts.Count_technique;
                Count_weapons.Text = _parts.Count_weapons;
                Date_of_foundation.Text = _parts.Date_of_foundation.ToString("dd.MM.yyyy");
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.locations);
            foreach (ClassModules.Locations item in ClassConnection.Connection.locations)
            {
                ComboBoxItem cb_locations = new ComboBoxItem();
                cb_locations.Tag = item.Id_locations;
                cb_locations.Content = item.Country;
                if (_parts.Locations == item.Id_locations) cb_locations.IsSelected = true;
                Locations.Items.Add(cb_locations);
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
            foreach (ClassModules.Type_of_troops item in ClassConnection.Connection.type_of_troops)
            {
                ComboBoxItem cb_typeOfTroops = new ComboBoxItem();
                cb_typeOfTroops.Tag = item.Id_type_of_troops;
                cb_typeOfTroops.Content = item.Name_type_of_troops;
                if (_parts.Type_of_troops == item.Id_type_of_troops) cb_typeOfTroops.IsSelected = true;
                Type_of_troops.Items.Add(cb_typeOfTroops);
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.weapons);
            foreach (ClassModules.Weapons item in ClassConnection.Connection.weapons)
            {
                ComboBoxItem cb_weapons = new ComboBoxItem();
                cb_weapons.Tag = item.Id_weapons;
                cb_weapons.Content = item.Name_weapons;
                if (_parts.Weapons == item.Id_weapons) cb_weapons.IsSelected = true;
                Weapons.Items.Add(cb_weapons);
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.companies);
            foreach (ClassModules.Companies item in Main.connect.companies)
            {
                ComboBoxItem cb_companies = new ComboBoxItem();
                cb_companies.Tag = item.Id_companies;
                cb_companies.Content = "Рота №" + item.Id_companies + "; " + "Главнокомандующий: " + item.Commander;
                if (_parts.Companies == item.Id_companies) cb_companies.IsSelected = true;
                Companies.Items.Add(cb_companies);
            }
        }

        private void Click_Parts_Redact(object sender, RoutedEventArgs e)
        {
            Id_locations_border.GotFocus += Id_locations_gotFocus;
            Id_typeOfTroops_border.GotFocus += Id_typeOfTroops_gotFocus;
            Id_weapons_border.GotFocus += Id_companies_gotFocus;
            Id_companies_border.GotFocus += Id_companies_gotFocus;
            Id_dateOfFoundation_border.GotFocus += Id_dateOfFoundation_gotFocus;
            if (Locations.SelectedItem != null)
            {
                if (Type_of_troops.SelectedItem != null)
                {
                    if (Weapons.SelectedItem != null)
                    {
                        if (Companies.SelectedItem != null)
                        {
                            if (Count_companies.Text != "")
                            {
                                if (Count_technique.Text != "")
                                {
                                    if (Count_weapons.Text != "")
                                    {
                                        if (Date_of_foundation.Text != "01.01.0001" && Date_of_foundation.Text != "")
                                        {
                                            ClassModules.Locations id_locations_temp;
                                            ClassModules.Type_of_troops id_typeOfTroops_temp;
                                            ClassModules.Weapons id_weapons_temp;
                                            ClassModules.Companies id_companies_temp;
                                            id_locations_temp = ClassConnection.Connection.locations.Find(x => x.Id_locations == Convert.ToInt32(((ComboBoxItem)Locations.SelectedItem).Tag));
                                            id_typeOfTroops_temp = ClassConnection.Connection.type_of_troops.Find(x => x.Id_type_of_troops == Convert.ToInt32(((ComboBoxItem)Type_of_troops.SelectedItem).Tag));
                                            id_weapons_temp = ClassConnection.Connection.weapons.Find(x => x.Id_weapons == Convert.ToInt32(((ComboBoxItem)Weapons.SelectedItem).Tag));
                                            id_companies_temp = Main.connect.companies.Find(x => x.Id_companies == Convert.ToInt32(((ComboBoxItem)Companies.SelectedItem).Tag));
                                            int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.parts);
                                            if (parts.Count_weapons == null)
                                            {
                                                string query = $"Insert Into parts ([Id_part], [Locations], [Type_of_troops], [Weapons], [Companies], [Count_companies], [Count_technique], [Count_weapons], [Date_of_foundation])" +
                                                    $"Values ({id.ToString()}, '{id_locations_temp.Id_locations.ToString()}', '{id_typeOfTroops_temp.Id_type_of_troops.ToString()}', '{id_weapons_temp.Id_weapons.ToString()}'," + 
                                                    $" '{id_companies_temp.Id_companies.ToString()}', '{Count_companies.Text}', '{Count_technique.Text}', '{Count_weapons.Text}', '{Date_of_foundation.Text}')";
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
                                                string query = $"Update parts Set Locations = '{id_locations_temp.Id_locations.ToString()}', Type_of_troops = '{id_typeOfTroops_temp.Id_type_of_troops.ToString()}'," + 
                                                    $" Weapons = '{id_weapons_temp.Id_weapons.ToString()}', Companies = '{id_companies_temp.Id_companies.ToString()}', Count_companies = '{Count_companies.Text}'," + "" +
                                                    $" Count_technique = '{Count_technique.Text}', Count_weapons = '{Count_weapons.Text}', Date_of_foundation = '{Date_of_foundation.Text}' Where Id_part = {parts.Id_part}";
                                                var query_apply = Main.connect.Query(query);
                                                if (query_apply != null)
                                                {
                                                    Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
                                                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.parts);
                                                }
                                                else MessageBox.Show("Запрос на изменение части не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                                            }
                                        }
                                        else
                                        {
                                            Id_dateOfFoundation_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                                        }
                                    }
                                    else 
                                    {
                                        Count_weapons.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                                    }
                                }
                                else
                                {
                                    Count_technique.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                                }
                            }
                            else
                            {
                                Count_companies.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                            }
                        }
                        else
                        {
                            Id_companies_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                        }
                    }
                    else
                    {
                        Id_weapons_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                    }
                }
                else
                {
                    Id_typeOfTroops_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                }
            }
            else
            {
                Id_locations_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }

        private void Click_Cancel_Parts_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

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

        private void Id_locations_gotFocus(object sender, RoutedEventArgs e)
        {
            Id_locations_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545454"));
        }

        private void Id_typeOfTroops_gotFocus(object sender, RoutedEventArgs e)
        {
            Id_typeOfTroops_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545454"));
        }

        private void Id_weapons_gotFocus(object sender, RoutedEventArgs e)
        {
            Id_weapons_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545454"));
        }

        private void Id_companies_gotFocus(object sender, RoutedEventArgs e)
        {
            Id_companies_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545454"));
        }

        private void Id_dateOfFoundation_gotFocus(object sender, RoutedEventArgs e)
        {
            Id_dateOfFoundation_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545454"));
        }
    }
}
