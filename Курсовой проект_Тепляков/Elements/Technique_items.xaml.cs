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

namespace Курсовой_проект_Тепляков.Elements
{
    /// <summary>
    /// Логика взаимодействия для Technique_items.xaml
    /// </summary>
    public partial class Technique_items : UserControl
    {
        ClassModules.Technique technique;
        public Technique_items(ClassModules.Technique _technique)
        {
            InitializeComponent();
            technique = _technique;
            if(_technique.Characteristics != null)
            {
                Name_technique.Content = technique.Name_technique;
                Parts.Content = "Номер части: " + technique.Parts;
                Characteristics.Content = "Характеристики: " + technique.Characteristics;
            }
        }

        private void Click_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesInTable.Technique(technique));
        }

        private void Click_remove(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Animation_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Pages.Main.page_main.technique);
        }
    }
}
