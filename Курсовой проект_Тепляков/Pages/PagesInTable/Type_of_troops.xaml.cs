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
    /// Логика взаимодействия для Type_of_troops.xaml
    /// </summary>
    public partial class Type_of_troops : Page
    {
        ClassModules.Type_of_troops type_of_troops;
        public Type_of_troops(ClassModules.Type_of_troops _type_of_troops)
        {
            InitializeComponent();
            type_of_troops = _type_of_troops;
            if (_type_of_troops.Name_type_of_troops != null) 
            {
                Name_type_of_troops.Text = _type_of_troops.Name_type_of_troops;
            }
        }

        private void Click_TypeOfTroops_Redact(object sender, RoutedEventArgs e)
        {
            int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.type_of_troops);
            if (type_of_troops.Name_type_of_troops == null)
            {
                string query = $"Insert Into type_of_troops ([Id_type_of_troops], [Name_type_of_troops]) Values ({id.ToString()}, '{Name_type_of_troops.Text}')";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.type_of_troops);
                }
                else MessageBox.Show("Запрос на добавление вида войск не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string query = $"Update type_of_troops Set Name_type_of_troops = '{Name_type_of_troops.Text}' Where Id_type_of_troops = {type_of_troops.Id_type_of_troops}";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.type_of_troops);
                }
                else MessageBox.Show("Запрос на изменение вида войск не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Click_Cancel_TypeOfTroops_Redact(object sender, RoutedEventArgs e) => MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);

        private void Click_Remove_TypeOfTroops_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                string query = "Delete From type_of_troops Where [Id_type_of_troops] = " + type_of_troops.Id_type_of_troops.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.type_of_troops);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.type_of_troops);
                }
                else MessageBox.Show("Запрос на удаление вида войск не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"^[А-Яа-яA-Za-z\s]*$");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите значение";
                Name_type_of_troops.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
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
                Name_type_of_troops.BorderBrush = brush;
            }
        }
    }
}
