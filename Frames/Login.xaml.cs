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
        Users_list users_;
        MainWindow mw;
        public Login(Users_list users_, MainWindow window)
        {
            InitializeComponent();
            this.users_ = users_;
            mw = window;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Height = 400;
            window.Width = 400;
        }

        private void Weiter_login_Click(object sender, RoutedEventArgs e)
        {
            int count = 0;
            try
            {
                foreach (User us in users_.Users)
                {
                    if ((us.EMail == email_login.Text) && (us.Password == password_login.Password))
                    {
                        mw.Change_Frame("Home");
                        break;
                    }
                    count++;
                }
                if (count >= users_.Users.Count())
                {
                    MessageBox.Show("Dieser User Existiert nicht oder das Password ist falsch");
                }
            }
            catch
            {
                MessageBox.Show("Es gibt keine Users");
            }
        }

        private void Password_fg_login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void New_user_loin_Click(object sender, RoutedEventArgs e)
        {
            Windows.Register register = new Windows.Register(users_);
            register.ShowDialog();
        }
    }
}
