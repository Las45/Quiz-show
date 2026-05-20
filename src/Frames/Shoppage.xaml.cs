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
    /// Interaktionslogik für Shoppage.xaml
    /// </summary>
    public partial class Shoppage : Page
    {
        public Shoppage()
        {
            InitializeComponent();
        }

        private void PathExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;

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
    }
}
