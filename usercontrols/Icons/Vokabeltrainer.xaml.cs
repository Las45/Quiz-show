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
    /// Interaktionslogik für Vokabeltrainer.xaml
    /// </summary>
    public partial class Vokabeltrainer : UserControl
    {
        public Vokabeltrainer()
        {
            InitializeComponent();
        }

        private void Vokabel_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Vokabel_rect.Stroke = Brushes.LightBlue;
            Vokabel_rect.StrokeThickness = 2;
        }

        private void Vokabel_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Vokabel_rect.StrokeThickness = 0;

        }

        private void Vokabel_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
