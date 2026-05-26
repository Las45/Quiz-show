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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class Fortschritt : UserControl
    {
        public Fortschritt()
        {
            InitializeComponent();

            UpdateUI();

            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            Vokabel_rect1.Fill = new SolidColorBrush(Shop.GetButtonColor());
        }

        private void Vokabel_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Vokabel_rect1.Opacity = 0.7;
        }

        private void Vokabel_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Vokabel_rect1.Opacity = 1;

        }

        private void Vokabel_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
