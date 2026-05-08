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
        }
        private void Achievements_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Achievements_rect1.Stroke = Brushes.LightBlue;
            Achievements_rect1.StrokeThickness = 2;
        }

        private void Achievements_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Achievements_rect1.StrokeThickness = 0;

        }

        private void Achievements_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
