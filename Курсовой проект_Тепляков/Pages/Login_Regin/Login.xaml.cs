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

namespace Курсовой_проект_Тепляков.Pages.Login_Regin
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            if (login_user.Text != "" && password_user.Password != "")
                if (login_user.Text == "kirill")
                    if (password_user.Password == "1234")
                        MessageBox.Show("Вход выполнен");
                    else
                        MessageBox.Show("Пароль неверный");
                else
                    MessageBox.Show("Имя пользователя неверно");
            else
                MessageBox.Show("Введите логин и пароль");
        }

        private void Regin_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
