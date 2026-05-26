using Quiz_show.src.Klassen;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Quiz_show.usercontrols.Icons
{
    public partial class Quiz : UserControl
    {
        public Quiz()
        {
            InitializeComponent();

            UpdateUI();

            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            Quiz_rect.Fill =
                new SolidColorBrush(Shop.GetButtonColor());
        }

        private void Quiz_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            Quiz_rect.Opacity = 0.7;
        }

        private void Quiz_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            Quiz_rect.Opacity = 1;
        }

        private void Quiz_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = Window.GetWindow(this) as MainWindow;

            if (main != null)
            {
                main.Change_Frame_by_name("Quiz");
            }
        }
    }
}