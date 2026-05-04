using Quiz_show.Frames;
using Quiz_show.Klassen;
using Quiz_show.usercontrols;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_show
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Quizclass steuerung = new Quizclass();
        Dictionary<string, Page> frames = new Dictionary<string, Page>();
        Users_list users;
        public MainWindow()
        {
            Logging.init();
            frames.Add("Home", new Homepage());
            frames.Add("Login", new Login(users));
            frames.Add("Registrieren", new Register());
            frames.Add("Passwort_forgotten", new forgotten_password());
            Logging.logger.Information("Pages wurden erstellt");
            InitializeComponent();
            users = new Users_list();
            Logging.logger.Information("Window wurde geladen");
            Main_frames.Content = frames["Login"];
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (Page page in frames.Values)
            {
                page.Height = window.ActualHeight;
                page.Width = window.ActualWidth;
            }
        }

        private void OpenTranslator(object sender, RoutedEventArgs e)
        {
            TranslatorWindow window = new TranslatorWindow();
            window.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            users.Save_users(); 
        }
    }
}