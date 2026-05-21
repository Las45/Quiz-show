using Quiz_show.Klassen;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Quiz_show.usercontrols
{
    public partial class FrageUserControl : UserControl
    {
        private Frage daten;

        public event Action<int> FrageBeendet;

        public FrageUserControl(Frage frage)
        {
            InitializeComponent();

            if (frage == null)
                throw new ArgumentException();


            daten = frage;

            Question.Content = daten.frage;

            a.Content = daten.antworten[0];
            b.Content = daten.antworten[1];
            c.Content = daten.antworten[2];
            d.Content = daten.antworten[3];
        }
        private void CheckAnswer(int index)
        {
            bool richtig = daten.Check(index);

            if (richtig)
                MessageBox.Show("Richtig!");
            else
                MessageBox.Show("Falsch!");

            FrageBeendet?.Invoke(index);
        }

        private void a_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer(0);
        }

        private void b_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer(1);
        }

        private void c_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer(2);
        }

        private void d_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CheckAnswer(3);
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
            a_rect.StrokeThickness = 0;
        }

        private void b_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            b_rect.StrokeThickness = 0;
        }

        private void c_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            c_rect.StrokeThickness = 0;
        }

        private void d_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            d_rect.StrokeThickness = 0;
        }
    }
}