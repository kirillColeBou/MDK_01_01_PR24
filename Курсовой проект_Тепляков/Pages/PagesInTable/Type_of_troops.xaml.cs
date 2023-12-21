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
    /// Логика взаимодействия для Type_of_troops.xaml
    /// </summary>
    public partial class Type_of_troops : Page
    {
        ClassModules.Type_of_troops type_of_troops;
        public Type_of_troops(ClassModules.Type_of_troops _type_of_troops)
        {
            InitializeComponent();
            type_of_troops = _type_of_troops;
        }

        private void Click_TypeOfTroops_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.type_of_troops);
        }

        private void Click_Cancel_TypeOfTroops_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
        }

        private void Click_Remove_TypeOfTroops_Redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.type_of_troops);
        }
    }
}
