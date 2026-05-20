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
    /// Interaktionslogik für OTP_PIN_F_Reset.xaml
    /// </summary>
    public partial class OTP_PIN_F_Reset : Page
    {
        Supabase.Client client;
        string e_mail;
        MainWindow window;
        public OTP_PIN_F_Reset(Supabase.Client client, string e_mail, MainWindow window)
        {
            InitializeComponent();
            this.client = client;
            this.e_mail = e_mail;
            this.window = window;
        }

        private async void reset_password_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await client.Auth.VerifyOTP(e_mail, pin_register.Text, Supabase.Gotrue.Constants.EmailOtpType.Email);
                window.Change_Frame(new Reset_password(client, window));
            }
            catch
            {
                Logging.logger.Error("The PIN was wrong at the password reset");
                MessageBox.Show("PIN ist falsch");
            }
        }
    }
}
