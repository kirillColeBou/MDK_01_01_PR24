using ClassModules;
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
using System.Windows.Media.Animation;
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
                Name_companies.Text = _companies.Name_companies;
                Commander.Text = _companies.Commander;
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
            foreach (var item in ClassConnection.Connection.type_of_troops)
            {
                ComboBoxItem cb_typeOfTroops = new ComboBoxItem();
                cb_typeOfTroops.Tag = item.Id_type_of_troops;
                cb_typeOfTroops.Content = item.Name_type_of_troops;
                if (_companies.Type_of_troops == item.Id_type_of_troops) cb_typeOfTroops.IsSelected = true;
                Type_of_troops.Items.Add(cb_typeOfTroops);
            }
        }

        private void Click_Companies_Redact(object sender, RoutedEventArgs e)
        {
            string[] FIOCommander = Commander.Text.Split(' ');
            if (FIOCommander.Length <= 3)
            {
                ClassModules.Type_of_troops id_typeOfTroops_temp;
                id_typeOfTroops_temp = ClassConnection.Connection.type_of_troops.Find(x => x.Id_type_of_troops == Convert.ToInt32(((ComboBoxItem)Type_of_troops.SelectedItem).Tag));
                int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.companies);
                if (companies.Commander == null)
                {
                    string query = $"INSERT INTO companies ([Id_companies], [Name_companies], [Commander], [Type_of_troops], [Date_foundation], [Date_update_information]) VALUES ({id.ToString()}, N'{Name_companies.Text}', N'{Commander.Text}', N'{id_typeOfTroops_temp.Id_type_of_troops.ToString()}', N'{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}', N'{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}')";
                    var query_apply = Main.connect.Query(query);
                    if (query_apply != null)
                    {
                        Main.connect.LoadData(ClassConnection.Connection.Tables.companies);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.companies);
                    }
                    else MessageBox.Show("Запрос на добавление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string query = $"UPDATE companies SET Name_companies = N'{Name_companies.Text}', Commander = N'{Commander.Text}', Type_of_troops = N'{id_typeOfTroops_temp.Id_type_of_troops.ToString()}', Date_update_information = N'{DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}' WHERE Id_companies = {companies.Id_companies}";
                    var query_apply = Main.connect.Query(query);
                    if (query_apply != null)
                    {
                        Main.connect.LoadData(ClassConnection.Connection.Tables.companies);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.companies);
                    }
                    else MessageBox.Show("Запрос на изменение роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Click_Cancel_Companies_Redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);

        private void Click_Remove_Companies_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.companies);
                string query = "Delete From companies Where [Id_companies] = " + companies.Id_companies.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if(query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.companies);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.companies);
                }
                else MessageBox.Show("Запрос на удаление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[А-Яа-яA-Za-z\s]*$");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите значение";
                Name_companies.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
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
                Name_companies.BorderBrush = brush;
            }
        }

        private void TextBox_PreviewTextInput_2(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[А-Яа-яA-Za-z\s]*$");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Length != 3 || words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите ровно три слова";
                Commander.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
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
                Commander.BorderBrush = brush;
            }
        }
    }
}
