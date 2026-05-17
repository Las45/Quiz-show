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

namespace Quiz_show.usercontrols
{
    /// <summary>
    /// Interaktionslogik für Frage.xaml
    /// </summary>
    public partial class Frage : UserControl
    {
        string question_;

        public string correct_answer;
        public string question 
        { 
            set
            {
                Question.Content = value;
            }       
        }
        string a__;
        public string a_
        {
            set
            {
                a.Content = value;
            }
        }
        string b__;
        public string b_
        {
            set
            {
                b.Content = value;
            }
        }
        string c__;
        public string c_
        {
            set
            {
                c.Content = value;
            }
        }
        string d__;
        public string d_
        {
            set
            {
                d.Content = value;
            }
        }

        public Frage()
        {
            InitializeComponent();
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

        private void a_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void b_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            b_rect.Stroke = Brushes.Black;
            b_rect.StrokeThickness = 0;
        }

        private void b_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void c_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            c_rect.Stroke = Brushes.Black;
            c_rect.StrokeThickness = 0;
        }

        private void c_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void d_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            d_rect.Stroke = Brushes.Black;
            d_rect.StrokeThickness = 0;
        }

        private void d_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
