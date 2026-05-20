using Quiz_show.Klassen;
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
    /// Interaktionslogik für Reset_password.xaml
    /// </summary>
    public partial class Reset_password : Page
    {
        Supabase.Client client;
        MainWindow window;
        public Reset_password(Supabase.Client client, MainWindow window)
        {
            InitializeComponent();
            this.client = client;
            this.window = window;
        }

        private void abb_pass_reset_Click(object sender, RoutedEventArgs e)
        {
            window.Change_Frame_by_name("Login");
        }

        private void reset_reset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (new_password_again.Background == Brushes.LightGreen && criterien.Foreground == Brushes.LightGreen) {
                    // Claude: Wie kann man mit Supabase das Password reseten über OPT
                    client.Auth.Update(new Supabase.Gotrue.UserAttributes
                    {
                        Password = new_password_again.Password
                    });
                    Logging.logger.Debug("The password was successfully reseted");
                    // Claude ende
                    window.Change_Frame_by_name("Login");
                }
            }
            catch (Exception ex) 
            {
                Logging.logger.Error($"Couldn't change the password: {ex.Message}");
                MessageBox.Show("Konnte das Passwort nicht ändern");
            }
        }

        private void new_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (new_password.Password.Length >= 6)
            {
                criterien.Foreground = Brushes.LightGreen;
            }
            else
            {
                criterien.Foreground = Brushes.Red;
            }
        }

        private void new_password_again_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (new_password.Password == new_password_again.Password)
            {
                new_password_again.Background = Brushes.LightGreen;
            }
            else
            {
                new_password_again.Background = Brushes.LightCoral;
            }
        }
    }
}
