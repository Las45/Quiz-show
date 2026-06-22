using Quiz_show.src.Klassen;
using Quiz_show.Windows;
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

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Register_1.xaml
    /// </summary>
    public partial class Register_1 : Page
    {
        public bool ok = false;
        Register register;
        private Supabase.Client client;
        public Register_1(Supabase.Client client, Register register)
        {
            InitializeComponent();
            this.client = client;
            this.register = register;
            Logging.logger.Debug("Register_1 opened");
        }



        private async void erstellen_register_Click(object sender, RoutedEventArgs e)
        {
            Logging.logger.Debug("Register clicked");

            if (password_again_register.Background == Brushes.LightGreen)
            {
                await client.Auth.SignUp(email_register.Text, password_again_register.Password);
                Logging.logger.Debug("Account created");
            }

            register.Change_frame(new Register_2(client, email_register.Text));
        }

        private void abb_register_Click(object sender, RoutedEventArgs e)
        {
            Logging.logger.Debug("Register cancelled");
        }

        private void password_again_register_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if ((password_again_register.Password != password_register.Password) ||
                (password_again_register.Password.Length < 6))
            {
                Logging.logger.Debug("Password invalid");
            }
        }
    }
}