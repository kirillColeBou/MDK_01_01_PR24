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

namespace Курсовой_проект_Тепляков.Pages.Login_Regin
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Regin regin;

        public Login()
        {
            InitializeComponent();
            regin = new Regin();
        }

        public void OpenPageRegin()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                MainWindow.init.frame.Navigate(regin);
                DoubleAnimation opgrisdAnimation = new DoubleAnimation();
                opgrisdAnimation.From = 0;
                opgrisdAnimation.To = 1;
                opgrisdAnimation.Duration = TimeSpan.FromSeconds(1.2);
                MainWindow.init.frame.BeginAnimation(Frame.OpacityProperty, opgrisdAnimation);
            };
            MainWindow.init.frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }

        private void login_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_incorrect.Visibility = Visibility.Hidden;
            login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
        }

        private void password_user_TextChanged(object sender, RoutedEventArgs e)
        {
            password_incorrect.Visibility = Visibility.Hidden;
            password_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
        }

        public void Login_to_Main()
        {
            login_incorrect.Content = "Логин не верный";
            login_incorrect.Visibility = Visibility.Hidden;
            password_incorrect.Content = "Пароль не верный";
            password_incorrect.Visibility = Visibility.Hidden;
            if (login_user.Text != "" && password_user.Password != "")
                if (login_user.Text == "kirill")
                    if (password_user.Password == "1234")
                    {
                        Main.main.CreateConnect(true);
                        MainWindow.init.OpenPageMain();
                    }
                    else
                    {
                        password_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                        password_incorrect.Visibility = Visibility.Visible;
                    }
                else
                {
                    login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                    login_incorrect.Visibility = Visibility.Visible;
                }
            else
            {
                login_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                login_incorrect.Content = "Введите логин";
                login_incorrect.Visibility = Visibility.Visible;
                password_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                password_incorrect.Content = "Введите пароль";
                password_incorrect.Visibility = Visibility.Visible;
            }
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            Login_to_Main();
        }

        private void Login_Click(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                Login_to_Main();
            if (e.Key == Key.Escape)
                MainWindow.init.Close();
        }

        private void Regin_Click(object sender, MouseButtonEventArgs e)
        {
            OpenPageRegin();
        }
    }
}
