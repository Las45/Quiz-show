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
    /// Interaktionslogik für forgotten_password.xaml
    /// </summary>
    public partial class forgotten_password : Page
    {
        Supabase.Client client;
        MainWindow window;
        public forgotten_password(Supabase.Client client, MainWindow window)
        {
            InitializeComponent();
            this.client = client;
            this.window = window;
        }

        private async void reset_reset_Click(object sender, RoutedEventArgs e)
        {
            try{
                await client.Auth.SignInWithOtp(new Supabase.Gotrue.SignInWithPasswordlessEmailOptions(e_mail_reset.Text)); 
            }
            catch (Exception ex) 
            {
                Logging.logger.Error($"A Error has occured: {ex.Message}");
                MessageBox.Show("Ein fehler ist aufgetreten");
            }
            window.Change_Frame(new OTP_PIN_F_Reset(client, e_mail_reset.Text, window));
        }

        private void abb_reset_Click(object sender, RoutedEventArgs e)
        {
            window.Change_Frame_by_name("Login");
        }
    }
}
