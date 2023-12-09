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
        public static Main init;
        public Regin()
        {
            InitializeComponent();
            init = new Main();
        }

        private void Back_Click(object sender, MouseButtonEventArgs e)
        {
            MainWindow.main.OpenPageLogin();
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            if (login_new_user.Text != "" && password_new_user_first.Password != "" && password_new_user_second.Password != "")
                if (password_new_user_first.Password == password_new_user_second.Password)
                {
                    MessageBox.Show("Вход выполнен");
                    OpenPageMain();
                }  
                else
                    MessageBox.Show("Пароли не совпадают");
            else
                MessageBox.Show("Введите данные нового пользователя");
        }

        public void OpenPageMain()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                MainWindow.main.frame.Navigate(init);
                DoubleAnimation opgrisdAnimation = new DoubleAnimation();
                opgrisdAnimation.From = 0;
                opgrisdAnimation.To = 1;
                opgrisdAnimation.Duration = TimeSpan.FromSeconds(1.2);
                MainWindow.main.frame.BeginAnimation(Frame.OpacityProperty, opgrisdAnimation);
            };
            MainWindow.main.frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }
    }
}
