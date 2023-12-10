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
    /// Логика взаимодействия для Regin.xaml
    /// </summary>
    public partial class Regin : Page
    {
        public Regin()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow.main.OpenPageLogin();
        }

        private void login_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            login_incorrect.Visibility = Visibility.Hidden;
            login_new_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
        }

        private void password_user_PasswordChanged(object sender, RoutedEventArgs e)
        {
            password_incorrect_first.Visibility = Visibility.Hidden;
            password_new_user_first.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
            password_incorrect_second.Visibility = Visibility.Hidden;
            password_new_user_second.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3D3D3D"));
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            login_incorrect.Visibility = Visibility.Hidden;
            password_incorrect_first.Content = "Пароли не совпадают";
            password_incorrect_first.Visibility = Visibility.Hidden;
            password_incorrect_second.Content = "Пароли не совпадают";
            password_incorrect_second.Visibility = Visibility.Hidden;
            if (login_new_user.Text != "")
                if (password_new_user_first.Password != "" && password_new_user_second.Password != "")

                    if (password_new_user_first.Password == password_new_user_second.Password)
                    {
                        MainWindow.init.OpenPageMain();
                    }
                    else
                    {
                        password_new_user_first.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                        password_incorrect_first.Visibility = Visibility.Visible;
                        password_new_user_second.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                        password_incorrect_second.Visibility = Visibility.Visible;
                    }
                else
                {
                    password_new_user_first.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                    password_incorrect_first.Content = "Введите пароль";
                    password_incorrect_first.Visibility = Visibility.Visible;
                    password_new_user_second.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                    password_incorrect_second.Content = "Введите пароль";
                    password_incorrect_second.Visibility = Visibility.Visible;
                }
            else
            {
                login_new_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                login_incorrect.Content = "Введите логин";
                login_incorrect.Visibility = Visibility.Visible;
            }
            if(login_new_user.Text == "" && password_new_user_first.Password == "" && password_new_user_second.Password == "")
            {
                login_new_user.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                login_incorrect.Content = "Введите логин";
                login_incorrect.Visibility = Visibility.Visible;
                password_new_user_first.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                password_incorrect_first.Content = "Введите пароль";
                password_incorrect_first.Visibility = Visibility.Visible;
                password_new_user_second.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                password_incorrect_second.Content = "Введите пароль";
                password_incorrect_second.Visibility = Visibility.Visible;
            }
        }
    }
}
