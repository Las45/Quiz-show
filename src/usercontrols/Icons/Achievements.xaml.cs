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

namespace Quiz_show.usercontrols.Icons
{
    /// <summary>
    /// Interaktionslogik für Achievements.xaml
    /// </summary>
    public partial class Achievements : UserControl
    {
        public Achievements()
        {
            InitializeComponent();

            UpdateUI();

            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            Achievements_rect1.Fill = new SolidColorBrush(Shop.GetButtonColor());
        }
        private void Achievements_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Achievements_rect1.Opacity = 0.7;

        }

        private void Achievements_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Achievements_rect1.Opacity = 1;

        }

        private void Achievements_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

            MainWindow main = Window.GetWindow(this) as MainWindow;

            if (main != null)
            {
                main.Change_Frame_by_name("Achievements");
            }
        }
    }
}
