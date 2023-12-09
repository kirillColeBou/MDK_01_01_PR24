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
        public Main()
        {
            InitializeComponent();
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

        private void Click_Parts(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Locations(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Companies(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Technique(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Type_of_troops(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Weapons(object sender, MouseButtonEventArgs e)
        {

        }

        private void Click_Back(object sender, MouseButtonEventArgs e)
        {
            OpenPageLogin();
        }
    }
}
