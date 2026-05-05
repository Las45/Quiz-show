using Quiz_show.Klassen;
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

namespace Quiz_show.Windows
{
    /// <summary>
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public bool ok = false;
        Users_list users_;
        public Register(Users_list list)
        {
            InitializeComponent();
            users_ = list;
        }

        private void erstellen_register_Click(object sender, RoutedEventArgs e)
        {
            if(password_again_register.Background == Brushes.LightGreen)
                users_.Users.Add(new User(users_.Users.Count(), "Name", email_register.Text, password_register.Password));
            ok = true;
            Close();
        }

        private void abb_register_Click(object sender, RoutedEventArgs e)
        {
            ok = false;
            Close();
        }

        private void password_again_register_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (password_again_register.Password != password_register.Password)
            {
                password_again_register.Background = Brushes.LightCoral;
            }
            else
            {
                password_again_register.Background = Brushes.LightGreen;

            }
        }
    }
}
