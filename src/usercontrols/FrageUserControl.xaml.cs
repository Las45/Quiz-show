using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Quiz_show.usercontrols
{
    /// <summary>
    /// Interaktionslogik für Frage.xaml
    /// </summary>
    public partial class FrageUserControl : UserControl
    {
        public event Action<bool> FrageBeendet;

        public string correct_answer;

        public string question
        {
            set
            {
                Question.Content = value;
            }
        }

        public string a_
        {
            set
            {
                a.Content = value;
            }
        }

        public string b_
        {
            set
            {
                b.Content = value;
            }
        }

        public string c_
        {
            set
            {
                c.Content = value;
            }
        }

        public string d_
        {
            set
            {
                d.Content = value;
            }
        }

        public FrageUserControl()
        {
            InitializeComponent();
        }

        private void CheckAnswer(string answer)
        {
            bool richtig = answer == correct_answer;

            if (richtig)
            {
                MessageBox.Show("Richtig!");
            }
            else
            {
                MessageBox.Show("Falsch!");
            }

            FrageBeendet?.Invoke(richtig);
        }

        private void a_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            a_rect.Stroke = Brushes.Blue;
            a_rect.StrokeThickness = 5;
        }

        private void b_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            b_rect.Stroke = Brushes.Blue;
            b_rect.StrokeThickness = 5;
        }

        private void c_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            c_rect.Stroke = Brushes.Blue;
            c_rect.StrokeThickness = 5;
        }

        private void d_rect_MouseEnter(object sender, MouseEventArgs e)
        {
            d_rect.Stroke = Brushes.Blue;
            d_rect.StrokeThickness = 5;
        }

        private void a_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            a_rect.Stroke = Brushes.Black;
            a_rect.StrokeThickness = 0;
        }

        private void b_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            b_rect.Stroke = Brushes.Black;
            b_rect.StrokeThickness = 0;
        }

        private void c_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            c_rect.Stroke = Brushes.Black;
            c_rect.StrokeThickness = 0;
        }

        private void d_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            d_rect.Stroke = Brushes.Black;
            d_rect.StrokeThickness = 0;
        }

        private void a_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer("a");
        }

        private void b_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer("b");
        }

        private void c_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer("c");
        }

        private void d_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer("d");
        }
    }
}