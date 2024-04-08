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
using System.Windows.Media.Animation;
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
                Description.Text = _weapons.Description;
            }
            foreach (var item in ClassConnection.Connection.companies)
            {
                ComboBoxItem cb_companies = new ComboBoxItem();
                cb_companies.Tag = item.Id_companies;
                cb_companies.Content = item.Name_companies;
                if (_weapons.Companies == item.Id_companies) cb_companies.IsSelected = true;
                Companies.Items.Add(cb_companies);
            }
        }

        private void Click_Weapons_Redact(object sender, RoutedEventArgs e)
        {
            ClassModules.Companies id_companies_temp;
            id_companies_temp = ClassConnection.Connection.companies.Find(x => x.Id_companies == Convert.ToInt32(((ComboBoxItem)Companies.SelectedItem).Tag));
            int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.weapons);
            if (weapons.Name_weapons == null)
            {
                string query = $"Insert Into weapons ([Id_weapons], [Name_weapons], [Companies], [Description], [Date_update_information]) Values ({id.ToString()}, N'{Name_weapons.Text}', N'{id_companies_temp.Id_companies.ToString()}', N'{Description.Text}', N'{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}')";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.weapons);
                }
                else MessageBox.Show("Запрос на добавление вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string query = $"Update weapons Set Name_weapons = N'{Name_weapons.Text}', Companies = N'{id_companies_temp.Id_companies.ToString()}', Description = N'{Description.Text}', Date_update_information = N'{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}' Where Id_weapons = {weapons.Id_weapons}";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.weapons);
                }
                else MessageBox.Show("Запрос на изменение вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Click_Cancel_Weapons_Redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);

        private void Click_Remove_Weapons_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                string query = "Delete From weapons Where [Id_weapons] = " + weapons.Id_weapons.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.weapons);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.weapons);
                }
                else MessageBox.Show("Запрос на удаление вооружения не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите значение";
                Name_weapons.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Ошибка:"))
            {
                textBox.Text = "";
                ColorAnimation animation = new ColorAnimation();
                animation.From = (Color)ColorConverter.ConvertFromString("#FB3F51");
                animation.To = Colors.Transparent;
                animation.Duration = new Duration(TimeSpan.FromSeconds(2));
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                Name_weapons.BorderBrush = brush;
            }
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите значение";
                Description.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }

        private void TextBox_GotFocus_2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.StartsWith("Ошибка:"))
            {
                textBox.Text = "";
                ColorAnimation animation = new ColorAnimation();
                animation.From = (Color)ColorConverter.ConvertFromString("#FB3F51");
                animation.To = Colors.Transparent;
                animation.Duration = new Duration(TimeSpan.FromSeconds(2));
                SolidColorBrush brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                Description.BorderBrush = brush;
            }
        }
    }
}
