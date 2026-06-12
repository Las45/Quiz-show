using Quiz_show.src.Klassen;
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
    /// Interaktionslogik für Achievementspage.xaml
    /// </summary>
    public partial class Achievementspage : Page
    {
        public Achievementspage()
        {
            InitializeComponent();

            UpdateUI();

            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            PathExit.Fill = new SolidColorBrush(Shop.GetButtonColor());

            if (Achievements.IsUnlocked("Perfektionist"))
            {
                RectAchievement1.Fill = new SolidColorBrush(Colors.LightGreen);
                LabelAchievement1.Content = "";
            }

            if (Achievements.IsUnlocked("5er Schüler"))
            { 
                RectAchievement2.Fill = new SolidColorBrush(Colors.LightGreen);
                LabelAchievement2.Content = "";
            }


            if (Achievements.IsUnlocked("1er Schüler"))
            { 
                RectAchievement3.Fill = new SolidColorBrush(Colors.LightGreen);
                LabelAchievement3.Content = "";
            }
            if (Achievements.IsUnlocked("Mode Designer"))
            { 
                RectAchievement4.Fill = new SolidColorBrush(Colors.LightGreen);
                LabelAchievement4.Content = "";
            }

            if (Achievements.IsUnlocked("Absolute Gleichheit"))
            { 
                RectAchievement5.Fill = new SolidColorBrush(Colors.LightGreen);
                LabelAchievement5.Content = "";
            }

            if (Achievements.IsUnlocked("Discord"))
            {
                RectAchievement6.Fill = new SolidColorBrush(Colors.LightGreen);
                LabelAchievement6.Content = "";
            }
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }
    }
}
