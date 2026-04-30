using Quiz_show.Frames;
using Quiz_show.usercontrols;
using System.Text;
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
        public MainWindow()
        {
            frames.Add("Home", new Homepage());
            frames.Add("Login", new Login());
            frames.Add("Registrieren", new Register());
            frames.Add("Passwort_forgotten", new forgotten_password());
            Logging.logger.Information("Pages wurden erstellt");
            InitializeComponent();
            Logging.logger.Information("Window wurde geladen");
            Main_frames.Content = frames["Home"];
        }
    }
}