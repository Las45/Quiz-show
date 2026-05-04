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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Users_list users_;
        bool 
        public Login(Users_list users_)
        {
            InitializeComponent();
            this.users_ = users_;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            Window window = Window.GetWindow(this);
            window.Height = 400;
            window.Width = 400;
        }

        private void Weiter_login_Click(object sender, RoutedEventArgs e)
        {
            foreach(User us in users_.Users)
            {
                if (us.EMail == email_login.Text && us.Password == us.Password)
                {
                    
                }
            }
        }

        private void Password_fg_login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void New_user_loin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
