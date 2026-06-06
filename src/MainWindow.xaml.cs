using Quiz_show.Frames;
using Quiz_show.Klassen;
using Quiz_show.src.Klassen;
using Quiz_show.usercontrols;
using Quiz_show.usercontrols.Icons;
using Supabase;
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

        private Progress progress = new Progress();



        public Dictionary<string, Page> Frames = new Dictionary<string, Page>();
        Supabase.Client client = new Client("https://qlfhcheflwewcyjhyzfr.supabase.co", "sb_publishable_DeKeXIVOxjyrM5OQSKUtmQ_NBlyc-zp");
        public MainWindow()
        {
            Logging.init();
            Shop.Load();
            Checker_Menue checkerMenu = new Checker_Menue(progress);
            Frames.Add("Home", new Homepage());
            Frames.Add("Login", new Login(this, client));
            Frames.Add("Checker", checkerMenu);
            Frames.Add("Passwort_forgotten", new forgotten_password(client, this));
            Frames.Add("Shop", new Shoppage());
            Frames.Add("Quiz", new QuizAuswahl(checkerMenu, progress));
            Frames.Add("Achievements", new Achievementspage());
            Logging.logger.Information("Pages wurden erstellt");
            InitializeComponent();
            Shop.ShopUpdated += UpdateUI;
            UpdateUI();
            Logging.logger.Information("Window wurde geladen");
            Main_frames.Content = Frames["Login"];

            src.Klassen.Achievements.AchievementList.Add(new Achievement("Perfektionist"));
            src.Klassen.Achievements.AchievementList.Add(new Achievement("5er Schüler"));
            src.Klassen.Achievements.AchievementList.Add(new Achievement("1er Schüler"));
            src.Klassen.Achievements.AchievementList.Add(new Achievement("Mode Designer"));
            src.Klassen.Achievements.AchievementList.Add(new Achievement("Absolute Gleichheit"));
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
            //((Checker_Menue)Frames["Stats"]).Save();
        }
        public void Change_Frame_by_name(string frame)
        {
            Main_frames.Content = Frames[frame];
        }
        public void Change_Frame(Page frame)
        {
            Main_frames.Content = frame;
        }

        private void UpdateUI()
        {
            Main_frames.Background = new SolidColorBrush(Shop.GetBackgroundColor());
        }
    }
}