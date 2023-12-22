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
            MainWindow.connect.LoadData(ClassConnection.Connection.Tables.parts);
            foreach (ClassModules.Parts item in MainWindow.connect.parts)
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
            if (Name_technique.Text != "" && Id_part.Text != "" && Characteristics.Text != "")
            {
                ClassModules.Parts id_part_temp;
                id_part_temp = MainWindow.connect.parts.Find(x => x.Id_part == Convert.ToInt32(((ComboBoxItem)Id_part.SelectedItem).Tag));
                int id = MainWindow.connect.SetLastId(ClassConnection.Connection.Tables.weapons);
                if (technique.Characteristics == null)
                {
                    string query = $"Insert Into technique ([Id_technique], [Name_technique], [Parts], [Characteristics]) Values ({id.ToString()}, '{Name_technique.Text}', '{id_part_temp.Id_part.ToString()}', '{Characteristics.Text}')";
                    var query_apply = MainWindow.connect.Query(query);
                    if (query_apply != null)
                    {
                        MainWindow.connect.LoadData(ClassConnection.Connection.Tables.technique);
                        MessageBox.Show("Успешное добавление техники!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.technique);
                    }
                    else MessageBox.Show("Запрос на добавление техники не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    string query = $"Update technique Set Name_technique = '{Name_technique.Text}', Parts = '{id_part_temp.Id_part.ToString()}', Characteristics = '{Characteristics.Text}' Where Id_technique = {technique.Id_technique}";
                    var query_apply = MainWindow.connect.Query(query);
                    if (query_apply != null)
                    {
                        MainWindow.connect.LoadData(ClassConnection.Connection.Tables.technique);
                        MessageBox.Show("Успешное изменение техники!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.technique);
                    }
                    else MessageBox.Show("Запрос на изменение техники не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else MessageBox.Show("Вы не ввели данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void Click_Cancel_Technique_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_Technique_Redact(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.Tables.technique);
                string query = "Delete From technique Where [Id_technique] = " + technique.Id_technique.ToString() + "";
                var query_apply = MainWindow.connect.Query(query);
                if (query_apply != null)
                {
                    MessageBox.Show("Успешное удаление техники!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow.connect.LoadData(ClassConnection.Connection.Tables.technique);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.technique);
                }
                else MessageBox.Show("Запрос на удаление техники не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
