﻿using System;
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
    /// Логика взаимодействия для Companies.xaml
    /// </summary>
    public partial class Companies : Page
    {
        public Companies()
        {
            InitializeComponent();
        }

        private void Click_Companies_Redact(object sender, RoutedEventArgs e)
        {
            Main.init.Animation_move(Main.init.frame_main, Main.init.scroll_main, null, null, Main.page_main.companies);
        }

        private void Click_Cancel_Companies_Redact(object sender, RoutedEventArgs e)
        {
            Main.init.Animation_move(Main.init.frame_main, Main.init.scroll_main);
        }

        private void Click_Remove_Companies_Redact(object sender, RoutedEventArgs e)
        {
            Main.init.Animation_move(Main.init.frame_main, Main.init.scroll_main, null, null, Main.page_main.companies);
        }
    }
}
