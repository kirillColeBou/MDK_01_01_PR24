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
using Курсовой_проект_Тепляков.Pages.PagesInTable;

namespace Курсовой_проект_Тепляков.Elements
{
    /// <summary>
    /// Логика взаимодействия для Companies_items.xaml
    /// </summary>
    public partial class Companies_items : UserControl
    {
        ClassModules.Companies companies;
        public Companies_items(ClassModules.Companies _companies)
        {
            InitializeComponent();
            companies = _companies;
            if(_companies.Commander != null)
            {
                Id_parts.Content = "Рота №" + _companies.Id_companies.ToString();
                Commander.Content = "Главнокомандующий: " + _companies.Commander;
            }
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Companies(companies));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow.connect.LoadData(ClassConnection.Connection.Tables.companies);
                string query = $"Delete From Companies Where Id_companies = " + companies.Id_companies.ToString() + "";
                var query_apply = MainWindow.connect.Query(query);
                if (query_apply != null)
                {
                    MainWindow.connect.LoadData(ClassConnection.Connection.Tables.companies);
                    MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.companies);
                }
                else MessageBox.Show("Запрос на удаление роты не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
