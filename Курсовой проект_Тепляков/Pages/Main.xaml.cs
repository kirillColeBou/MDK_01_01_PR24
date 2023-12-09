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
using Курсовой_проект_Тепляков.Pages.Login_Regin;

namespace Курсовой_проект_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public static page_main page_select;
        public static Main init;
        public Main()
        {
            InitializeComponent();
            init = this;
            page_select = page_main.none;
        }

        public enum page_main
        {
            companies, locations, parts, technique, type_of_troops, weapons, none
        }

        public void OpenPageLogin()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                MainWindow.main.frame.Navigate(new Login());
                DoubleAnimation opgrisdAnimation = new DoubleAnimation();
                opgrisdAnimation.From = 0;
                opgrisdAnimation.To = 1;
                opgrisdAnimation.Duration = TimeSpan.FromSeconds(1.2);
                MainWindow.main.frame.BeginAnimation(Frame.OpacityProperty, opgrisdAnimation);
            };
            MainWindow.main.frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }

        private void Click_Parts(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Locations(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Companies(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Technique(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Type_of_troops(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Weapons(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Back(object sender, RoutedEventArgs e)
        {
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
