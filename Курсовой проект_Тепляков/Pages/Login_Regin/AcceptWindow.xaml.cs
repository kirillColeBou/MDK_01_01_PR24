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
using System.Windows.Shapes;

namespace Курсовой_проект_Тепляков.Pages.Login_Regin
{
    /// <summary>
    /// Логика взаимодействия для AcceptWindow.xaml
    /// </summary>
    public partial class AcceptWindow : Window
    {
        public string Login_admin { get; private set; }
        public string Password_admin { get; private set; }
        public bool IsApply = false;
        public static AcceptWindow acceptWindow;
        public ClassConnection.Connection connection;

        public AcceptWindow()
        {
            InitializeComponent();
            acceptWindow = this;
            connection = new ClassConnection.Connection();
        }

        private void Accept_Click(object sender, MouseButtonEventArgs e)
        {
            if (login_admin.Text != null)
            {
                if (password_admin.Password != null)
                {
                    if (connection.RoleUser(login_admin.Text, password_admin.Password) == "admin")
                    {
                        Login_admin = login_admin.Text;
                        Password_admin = password_admin.Password;
                        IsApply = true;
                        this.Close();
                    }
                    else
                    {
                        login_admin.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                        return;
                    }
                }
                else
                {
                    password_admin.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
                }
            }
            else
            {
                login_admin.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FB3F51"));
            }
        }
    }
}
