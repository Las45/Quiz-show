using Quiz_show.Klassen;
using Quiz_show.src.Klassen;
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
        private Frage daten;

        public event Action<bool> FrageBeendet;

        public FrageUserControl(Frage frage)
        {
            InitializeComponent();

            if (frage == null)
                throw new ArgumentException();

            daten = frage;
            Logging.logger.Debug($"Frage loaded");

            Question.Content = daten.frage;

            a.Content = daten.antworten[0];
            b.Content = daten.antworten[1];



            if (daten.antworten.Count >= 4)
            {
                d.Content = daten.antworten[3];
                c.Content = daten.antworten[2];
                c_rect.Visibility = Visibility.Visible;
                d_rect.Visibility = Visibility.Visible;
            }
            else
            {
                d_rect.Visibility = Visibility.Collapsed;
                c_rect.Visibility = Visibility.Collapsed;
                d_label.Visibility = Visibility.Collapsed;
                c_label.Visibility = Visibility.Collapsed;
            }
        }
        
        private void CheckAnswer(int index)
        {
            bool richtig = daten.Check(index);


            FrageBeendet?.Invoke(richtig);
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