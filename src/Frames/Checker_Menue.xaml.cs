using Quiz_show.src.Klassen;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Quiz_show.Frames
{
    public partial class Checker_Menue : Page
    {
        private Progress progress;

        public Checker_Menue(Progress p)
        {
            InitializeComponent();

            progress = p;

            Update();
            InitializeComponent();

            UpdateUI();

            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            PathExit.Fill = new SolidColorBrush(Shop.GetButtonColor());
        }
        private void PathExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            UpdateUI();
            main.Change_Frame_by_name("Home");

        }

        private void PathExit_MouseLeave(object sender, MouseEventArgs e)
        {
            PathExit.Opacity = 1;
        }

        private void PathExit_MouseEnter(object sender, MouseEventArgs e)
        {
            PathExit.Opacity = 0.7;
        }

        public void Update()
        {
            Pos_progressbar.Value = progress.Subjects[0].Quizzes_prozent;
            NSCS_progressbar.Value = progress.Subjects[1].Quizzes_prozent;
            CABS_progressbar.Value = progress.Subjects[2].Quizzes_prozent;
            English_progressbar.Value = progress.Subjects[3].Quizzes_prozent;
            Geschichte_progressbar.Value = progress.Subjects[4].Quizzes_prozent;
        }
    }
}