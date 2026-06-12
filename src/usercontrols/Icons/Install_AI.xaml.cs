using OllamaSharp;
using Quiz_show.src.Windows;
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

namespace Quiz_show.src.usercontrols.Icons
{
    /// <summary>
    /// Interaktionslogik für Install_AI.xaml
    /// </summary>
    public partial class Install_AI : UserControl
    {
        public Install_AI()
        {
            InitializeComponent();

            UpdateUI();
            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            UC_AI_rect.Fill = new SolidColorBrush(Shop.GetButtonColor());
        }

        private void UC_AI_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            InstallModell window = new InstallModell(mainWindow.OllamaClient);
            window.ShowDialog();
        }

        private void UC_AI_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            UC_AI_rect.Opacity = 0.7;
        }

        private void UC_AI_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            UC_AI_rect.Opacity = 1;
        }
    }
}
