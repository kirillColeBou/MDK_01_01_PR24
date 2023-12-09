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

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            if (login_new_user.Text != "" && password_new_user_first.Password != "" && password_new_user_second.Password != "")
                if (password_new_user_first.Password == password_new_user_second.Password)
                {
                    MessageBox.Show("Вход выполнен");
                    MainWindow.init.OpenPageMain();
                }  
                else
                    MessageBox.Show("Пароли не совпадают");
            else
                MessageBox.Show("Введите данные нового пользователя");
        }
    }
}
