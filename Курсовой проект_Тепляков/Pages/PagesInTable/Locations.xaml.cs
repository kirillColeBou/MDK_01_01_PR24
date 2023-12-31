﻿using ClassModules;
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

namespace Курсовой_проект_Тепляков.Pages.PagesInTable
{
    /// <summary>
    /// Логика взаимодействия для Locations.xaml
    /// </summary>
    public partial class Locations : Page
    {
        ClassModules.Locations locations;
        public Locations(ClassModules.Locations _locations)
        {
            InitializeComponent();
            locations = _locations;
            if (_locations.Address != null)
            {
                Country.Text = _locations.Country;
                City.Text = _locations.City;
                Address.Text = _locations.Address;
                Square.Text = _locations.Square.ToString();
                Count_structures.Text = _locations.Count_structures.ToString();
            }
        }

        private void Click_Locations_Redact(object sender, RoutedEventArgs e)
        {
            if (Country.Text != "")
            {
                if (City.Text != "")
                {
                    if (Address.Text != "")
                    {
                        if (Square.Text != "")
                        {
                            if (Count_structures.Text != "")
                            {
                                int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.locations);
                                if (locations.Country == null)
                                {
                                    string query = $"Insert Into locations ([Id_locations], [Country], [City], [Address], [Square], [Count_structures]) Values ({id.ToString()}, '{Country.Text}', '{City.Text}', '{Address.Text}', '{Square.Text}', '{Count_structures.Text}')";
                                    var query_apply = Main.connect.Query(query);
                                    if (query_apply != null)
                                    {
                                        Main.connect.LoadData(ClassConnection.Connection.Tables.locations);
                                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.locations);
                                    }
                                    else MessageBox.Show("Запрос на добавление места дислокации не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                                else
                                {
                                    string query = $"Update locations Set [Country] = '{Country.Text}', [City] = '{City.Text}', [Address] = '{Address.Text}', [Square] = '{Square.Text}', [Count_structures] = '{Count_structures.Text}' Where [Id_locations] = {locations.Id_locations}";
                                    var query_apply = Main.connect.Query(query);
                                    if (query_apply != null)
                                    {
                                        Main.connect.LoadData(ClassConnection.Connection.Tables.locations);
                                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.locations);
                                    }
                                    else MessageBox.Show("Запрос на изменение места дислокации не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }
                            else
                            {
                                Count_structures.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                            }
                        }
                        else
                        {
                            Square.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                        }
                    }
                    else
                    {
                        Address.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                    }
                }
                else
                {
                    City.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                }
            }
            else
            {
                Country.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }

        private void Click_Cancel_Locations_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_Locations_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.locations);
                string query = "Delete From locations Where [Id_locations] = " + locations.Id_locations.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.locations);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.locations);
                }
                else MessageBox.Show("Запрос на удаление места дислокации не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
