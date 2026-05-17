using Quiz_show.usercontrols;
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
    /// Interaktionslogik für QuizAuswahl.xaml
    /// </summary>
    public partial class QuizAuswahl : Page
    {
        public QuizAuswahl()
        {
            InitializeComponent();
        }

        private void RectQuiz1_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 0.7;
        }

        private void RectQuiz1_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 1;
        }

        private void RectQuiz1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            QuizContainer.Children.Clear();



            QuizContainer.Visibility = Visibility.Visible;
            RectQuizBackground.Visibility = Visibility.Visible;
        }
    }
}
