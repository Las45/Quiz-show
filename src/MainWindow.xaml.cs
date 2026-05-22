using Quiz_show.Frames;
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
using Supabase;
using Quiz_show.src.Klassen;

namespace Quiz_show
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Quizclass steuerung = new Quizclass();
        public Dictionary<string, Page> Frames = new Dictionary<string, Page>();
        Supabase.Client client = new Client("https://qlfhcheflwewcyjhyzfr.supabase.co", "sb_publishable_DeKeXIVOxjyrM5OQSKUtmQ_NBlyc-zp");
        public MainWindow()
        {
            Logging.init();
            Frames.Add("Home", new Homepage());
            Frames.Add("Login", new Login(this, client));
            Frames.Add("Stats", new Checker_Menue());
            Frames.Add("Passwort_forgotten", new forgotten_password(client, this));
            Frames.Add("Shop", new Shoppage());
            Frames.Add("Quiz", new QuizAuswahl());
            Frames.Add("Achievements", new Achievementspage());
            Logging.logger.Information("Pages wurden erstellt");
            InitializeComponent();
            Logging.logger.Information("Window wurde geladen");
            Main_frames.Content = Frames["Login"];
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (Page page in Frames.Values)
            {
                page.Height = window.ActualHeight;
                page.Width = window.ActualWidth;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((Checker_Menue)Frames["Stats"]).Save();
        }
        public void Change_Frame_by_name(string frame)
        {
            Main_frames.Content = Frames[frame];
        }
        public void Change_Frame(Page frame)
        {
            Main_frames.Content = frame;
        }
    }
}