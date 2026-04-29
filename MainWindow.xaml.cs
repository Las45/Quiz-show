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
        public MainWindow()
        {
            InitializeComponent();
            Homepage homepage = new Homepage();
            homepage.ShowsNavigationUI = true;
        }

        private void Allgemein_Click(object sender, RoutedEventArgs e)
        {
            Allgemein window = new Allgemein();
            window.Show();
        }
    }
}