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

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            if (login_user.Text != "" && password_user.Password != "")
                if (login_user.Text == "kirill")
                    if (password_user.Password == "1234")
                    {
                        MessageBox.Show("Вход выполнен");
                        MainWindow.init.OpenPageMain();
                    }
                    else
                        MessageBox.Show("Пароль неверный");
                else
                    MessageBox.Show("Имя пользователя неверно");
            else
                MessageBox.Show("Введите логин и пароль");
        }

        private void Regin_Click(object sender, MouseButtonEventArgs e)
        {
            OpenPageRegin();
        }
    }
}
