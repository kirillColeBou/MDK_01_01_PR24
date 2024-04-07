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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Курсовой_проект_Тепляков.Pages.PagesInTable
{
    /// <summary>
    /// Логика взаимодействия для Technique.xaml
    /// </summary>
    public partial class Technique : Page
    {
        ClassModules.Technique technique;
        public Technique(ClassModules.Technique _technique)
        {
            InitializeComponent();
            technique = _technique;
            if (_technique.Characteristics != null)
            {
                Name_technique.Text = _technique.Name_technique;
                Characteristics.Text = _technique.Characteristics;
            }
            Main.connect.LoadData(ClassConnection.Connection.Tables.parts);
            foreach (ClassModules.Parts item in ClassConnection.Connection.parts)
            {
                ComboBoxItem cb_parts = new ComboBoxItem();
                cb_parts.Tag = item.Id_part;
                cb_parts.Content = "Часть №" + item.Id_part;
                if (_technique.Parts == item.Id_part) cb_parts.IsSelected = true;
                Id_part.Items.Add(cb_parts);
            }
        }

        private void Click_Technique_Redact(object sender, RoutedEventArgs e)
        {
            Id_part_border.GotFocus += Id_part_gotFocus;
            if (Id_part.SelectedItem != null)
            {

                ClassModules.Parts id_part_temp;
                id_part_temp = ClassConnection.Connection.parts.Find(x => x.Id_part == Convert.ToInt32(((ComboBoxItem)Id_part.SelectedItem).Tag));
                int id = Main.connect.SetLastId(ClassConnection.Connection.Tables.technique);
                if (technique.Characteristics == null)
                {
                    string query = $"Insert Into technique ([Id_technique], [Name_technique], [Parts], [Characteristics]) Values ({id.ToString()}, N'{Name_technique.Text}', '{id_part_temp.Id_part.ToString()}', N'{Characteristics.Text}')";
                    var query_apply = Main.connect.Query(query);
                    if (query_apply != null)
                    {
                        Main.connect.LoadData(ClassConnection.Connection.Tables.technique);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.technique);
                    }
                    else MessageBox.Show("Запрос на добавление техники не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string query = $"Update technique Set Name_technique = N'{Name_technique.Text}', Parts = '{id_part_temp.Id_part.ToString()}', Characteristics = N'{Characteristics.Text}' Where Id_technique = {technique.Id_technique}";
                    var query_apply = Main.connect.Query(query);
                    if (query_apply != null)
                    {
                        Main.connect.LoadData(ClassConnection.Connection.Tables.technique);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.technique);
                    }
                    else MessageBox.Show("Запрос на изменение техники не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                Id_part_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }

        private void Click_Cancel_Technique_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_Technique_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connect.LoadData(ClassConnection.Connection.Tables.technique);
                string query = "Delete From technique Where [Id_technique] = " + technique.Id_technique.ToString() + "";
                var query_apply = Main.connect.Query(query);
                if (query_apply != null)
                {
                    Main.connect.LoadData(ClassConnection.Connection.Tables.technique);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.technique);
                }
                else MessageBox.Show("Запрос на удаление техники не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Id_part_gotFocus(object sender, RoutedEventArgs e) => Id_part_border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#545454"));

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите значение";
                Name_technique.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
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
                Name_technique.BorderBrush = brush;
            }
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string[] words = textBox.Text.Split(' ');
            if (words.Any(word => word.Length == 0))
            {
                textBox.Text = "Ошибка: введите значение";
                Characteristics.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
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
                Characteristics.BorderBrush = brush;
            }
        }
    }
}
