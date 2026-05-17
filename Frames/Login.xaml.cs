using Quiz_show.Klassen;
using System.Windows;
using System.Windows.Controls;

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mw;
        Supabase.Client client;
        public Windows.Register register;
        public Login(MainWindow window, Supabase.Client client)
        {
            InitializeComponent();
            this.mw = window;
            this.client = client;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Height = 400;
            window.Width = 400;
        }

        private async void Weiter_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await this.client.Auth.SignInWithPassword(email_login.Text, password_login.Password);
                this.mw.Change_Frame_by_name("Home");
            }
            catch
            {
                MessageBox.Show("Es gibt diesen User nicht oder das Passwort ist falsch");
            }
        }

        private void Password_fg_login_Click(object sender, RoutedEventArgs e)
        {
            mw.Change_Frame_by_name("Passwort_forgotten");
        }

        private void New_user_loin_Click(object sender, RoutedEventArgs e)
        {
            register = new Windows.Register(this.client);
            register.ShowDialog();
        }
    }
}
