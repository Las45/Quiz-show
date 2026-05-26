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
    /// Interaktionslogik für Register_2.xaml
    /// </summary>
    public partial class Register_2 : Page
    {
        Supabase.Client client;
        string e_mail;
        public Register_2(Supabase.Client client, string e_mail)
        {
            InitializeComponent();
            this.client = client;
            this.e_mail = e_mail;
        }

        private async void login_register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await client.Auth.VerifyOTP(e_mail, pin_register.Text, Supabase.Gotrue.Constants.EmailOtpType.Email);
                Window.GetWindow(this).Close();
            }
            catch 
            {
                MessageBox.Show("PIN ist falsch");
            }
        }
    }
}
