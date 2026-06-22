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

namespace Quiz_show.src.usercontrols
{
    /// <summary>
    /// Interaktionslogik für Loading_Animation.xaml
    /// </summary>
    public partial class Loading_Animation : UserControl
    {
        public Loading_Animation()
        {
            InitializeComponent();
            animate();
        }

        private void animate()
        {
            DateTime start_time = DateTime.Now;
            DateTime current_time = DateTime.Now;
            int count = 0;
            while ((start_time - current_time).TotalSeconds > 10) // Wird nach 10 sek abgebrochen weil in dieser Zeit wahrscheinlich etwas falschgelaufen ist wie bei den großen apps und games
            {
                rect1.Height = 10+(40*Math.Sin(count));
                rect2.Height = 10 + (40*Math.Cos(count));
                rect3.Height = 10 + (40 * Math.Sin(count));
                count++;
                current_time = DateTime.Now;
            }
        }
    }
}
