﻿using ClassConnection;
using ClassModules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
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
using System.Xml.Linq;
using Курсовой_проект_Тепляков.Pages.Login_Regin;
using Курсовой_проект_Тепляков.Pages.PagesInTable;

namespace Курсовой_проект_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public enum page_main
        {
            companies, locations, parts, technique, type_of_troops, weapons, none
        }

        public static page_main page_select;
        public static Main main;

        public Main()
        {
            InitializeComponent();
            main = this;
            page_select = page_main.none;
        }

        public void CreateConnect(bool connectApply)
        {
            if (connectApply == true)
            {
                Login.connection.LoadData(Connection.Tables.companies);
                Login.connection.LoadData(Connection.Tables.locations);
                Login.connection.LoadData(Connection.Tables.parts);
                Login.connection.LoadData(Connection.Tables.technique);
                Login.connection.LoadData(Connection.Tables.type_of_troops);
                Login.connection.LoadData(Connection.Tables.weapons);
                Login.connection.LoadData(Connection.Tables.country);
            } 
        }

        public void RoleUser()
        {
            if (Login.UserInfo[1] == "admin") WhoAmI.Content = $"Здравствуйте, {Login.UserInfo[0]}! Роль - {Login.UserInfo[1]}";
            else WhoAmI.Content = $"Здравствуйте, {Login.UserInfo[0]}! Роль - {Login.UserInfo[1]}";
        }

        public void OpenPageLogin()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                MainWindow.init.frame.Navigate(new Login());
                DoubleAnimation opgrisdAnimation = new DoubleAnimation();
                opgrisdAnimation.From = 0;
                opgrisdAnimation.To = 1;
                opgrisdAnimation.Duration = TimeSpan.FromSeconds(1.2);
                MainWindow.init.frame.BeginAnimation(Frame.OpacityProperty, opgrisdAnimation);
            };
            MainWindow.init.frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }

        private void LoadParts()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Parts parts_items in ClassConnection.Connection.parts)
                {
                    if (page_select == page_main.parts)
                    {
                        parrent.Children.Add(new Elements.Parts_items(parts_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.parts)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Parts(new ClassModules.Parts());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Parts(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.parts)
            {
                page_select = page_main.parts;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadParts();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadLocations()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Locations locations_items in ClassConnection.Connection.locations)
                {
                    if (page_select == page_main.locations)
                    {
                        parrent.Children.Add(new Elements.Locations_items(locations_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.locations)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Locations(new ClassModules.Locations());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }

        private void Click_Locations(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.locations)
            {
                page_select = page_main.locations;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadLocations();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadCompanies()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Companies companies_items in ClassConnection.Connection.companies)
                {
                    if (page_select == page_main.companies)
                    {
                        parrent.Children.Add(new Elements.Companies_items(companies_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.companies)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Companies(new ClassModules.Companies());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }
        
        private void Click_Companies(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.companies)
            {
                page_select = page_main.companies;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadCompanies();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadTechnique()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Technique technique_items in ClassConnection.Connection.technique)
                {
                    if (page_select == page_main.technique)
                    {
                        parrent.Children.Add(new Elements.Technique_items(technique_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.technique)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Technique(new ClassModules.Technique());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }
        
        private void Click_Technique(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.technique)
            {
                page_select = page_main.technique;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadTechnique();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadTypeOfTroops()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Type_of_troops type_of_troops_items in ClassConnection.Connection.type_of_troops)
                {
                    if (page_select == page_main.type_of_troops)
                    {
                        parrent.Children.Add(new Elements.TypeOfTroops_items(type_of_troops_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.type_of_troops)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Type_of_troops(new ClassModules.Type_of_troops());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }
        
        private void Click_Type_of_troops(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.type_of_troops)
            {
                page_select = page_main.type_of_troops;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadTypeOfTroops();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void LoadWeapons()
        {
            Dispatcher.InvokeAsync(async () =>
            {
                foreach (ClassModules.Weapons weapons_items in ClassConnection.Connection.weapons)
                {
                    if (page_select == page_main.weapons)
                    {
                        parrent.Children.Add(new Elements.Weapons_items(weapons_items));
                        await Task.Delay(90);
                    }
                }
                if (page_select == page_main.weapons)
                {
                    if (Login.UserInfo[1] == "admin")
                    {
                        var add = new Pages.PagesInTable.Weapons(new ClassModules.Weapons());
                        parrent.Children.Add(new Elements.Add(add));
                    }
                }
            });
        }
        
        private void Click_Weapons(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = true;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF"));
            if (frame_main.Visibility == Visibility.Visible) MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            if (page_select != page_main.weapons)
            {
                page_select = page_main.weapons;
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parrent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        LoadWeapons();
                    };
                    parrent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parrent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_Export(object sender, MouseButtonEventArgs e)
        {
            Search.IsEnabled = false;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            parrent.Children.Clear();
            page_select = page_main.none;
            var export = new ExportWindow();
            export.ShowDialog();
        }

        private bool isDataLoaded = false;

        private async void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Search.Text) && Search.Text != "Поиск")
            {
                await Task.Delay(100);
                if (page_select == page_main.parts)
                {
                    parrent.Children.Clear();
                    var parts = Connection.parts.FindAll(x => x.Id_part.ToString() == Search.Text);
                    foreach (var itemSearch in parts) parrent.Children.Add(new Elements.Parts_items(itemSearch));
                }
                else if (page_select == page_main.locations)
                {
                    parrent.Children.Clear();
                    var country = Connection.country.FindAll(x => x.Name.Contains(Search.Text));
                    var countryIds = country.Select(c => c.Id).ToList();
                    var locationsByCountry = Connection.locations.Where(l => countryIds.Contains(l.Country)).ToList();
                    foreach (var itemSearch in locationsByCountry) parrent.Children.Add(new Elements.Locations_items(itemSearch));
                }
                else if (page_select == page_main.companies)
                {
                    parrent.Children.Clear();
                    var companiesById = Connection.companies.FindAll(x => x.Id_companies.ToString().Contains(Search.Text));
                    foreach (var itemSearch in companiesById) parrent.Children.Add(new Elements.Companies_items(itemSearch));
                }
                else if (page_select == page_main.technique)
                {
                    parrent.Children.Clear();
                    var techniqueByName = Connection.technique.FindAll(x => x.Name_technique.Contains(Search.Text));
                    foreach (var itemSearch in techniqueByName) parrent.Children.Add(new Elements.Technique_items(itemSearch));
                }
                else if (page_select == page_main.type_of_troops)
                {
                    parrent.Children.Clear();
                    var typeOfTroopByName = Connection.type_of_troops.FindAll(x => x.Name_type_of_troops.Contains(Search.Text));
                    foreach (var itemSearch in typeOfTroopByName) parrent.Children.Add(new Elements.TypeOfTroops_items(itemSearch));
                }
                else if (page_select == page_main.weapons)
                {
                    parrent.Children.Clear();
                    var weaponById = Connection.weapons.FindAll(x => x.Id_weapons.ToString().Contains(Search.Text));
                    foreach (var itemSearch in weaponById) parrent.Children.Add(new Elements.Weapons_items(itemSearch));
                }
            }
            else
            {
                await Task.Delay(100);
                if (string.IsNullOrWhiteSpace(Search.Text))
                {
                    parrent.Children.Clear(); 
                    return;
                }
                if (!isDataLoaded || Search.Text == "Поиск")
                {
                    if (page_select == page_main.parts)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadParts();
                    }
                    else if (page_select == page_main.locations)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadLocations();
                    }
                    else if (page_select == page_main.companies)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadCompanies();
                    }
                    else if (page_select == page_main.technique)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadTechnique();
                    }
                    else if (page_select == page_main.type_of_troops)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadTypeOfTroops();
                    }
                    else if (page_select == page_main.weapons)
                    {
                        if (parrent != null) parrent.Children.Clear();
                        LoadWeapons();
                    }
                    isDataLoaded = true;
                }
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e) => Search.Text = "Поиск";

        private void TextBox_GotFocus(object sender, RoutedEventArgs e) => Search.Text = "";

        private void Click_Back(object sender, RoutedEventArgs e)
        {
            Search.IsEnabled = false;
            parts_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            locations_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            companies_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            technique_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            typeOfTroops_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            weapons_itms.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2C2C2C"));
            parrent.Children.Clear();
            page_select = page_main.none;
            Login.UserInfo[0] = ""; Login.UserInfo[1] = "";
            OpenPageLogin();
        }

        public void Animation_move(Control control1, Control control2, Frame frame_main = null, Page pages = null, page_main page_restart = page_main.none)
        {
            if (page_restart != page_main.none)
            {
                if (page_restart == page_main.parts)
                {
                    page_select = page_main.none;
                    Click_Parts(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.locations)
                {
                    page_select = page_main.none;
                    Click_Locations(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.companies)
                {
                    page_select = page_main.none;
                    Click_Companies(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.technique)
                {
                    page_select = page_main.none;
                    Click_Technique(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.type_of_troops)
                {
                    page_select = page_main.none;
                    Click_Type_of_troops(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.weapons)
                {
                    page_select = page_main.none;
                    Click_Weapons(new object(), new RoutedEventArgs());
                }
            }
            else
            {
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.3);
                opgridAnimation.Completed += delegate
                {
                    if (pages != null)
                    {
                        frame_main.Navigate(pages);
                    }
                    control1.Visibility = Visibility.Hidden;
                    control2.Visibility = Visibility.Visible;
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    control2.BeginAnimation(ScrollViewer.OpacityProperty, opgriAnimation);
                };
                control1.BeginAnimation(ScrollViewer.OpacityProperty, opgridAnimation);
            }
        }
    }
}
