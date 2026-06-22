using Quiz_show.src.Klassen;
using Supabase.Postgrest;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quiz_show.src.usercontrols
{
    /// <summary>
    /// Interaktionslogik für True_False.xaml
    /// </summary>
    public partial class True_False : UserControl
    {
        private Frage frage; 
        public event Action<bool> FrageBeendet;
        public True_False(Frage frage)
        {
            InitializeComponent();
            this.frage = frage;

            Frage_true_false.Content = frage.frage;
        }

        private void check(int index)
        {
            bool richtig = frage.Check(index);



            FrageBeendet?.Invoke(richtig);
        }


        private void a_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            check(0);
        }

        private void b_rect_MouseUp(object sender, MouseButtonEventArgs e)
        {
            check(1);
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


        private void a_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            a_rect.StrokeThickness = 0;
        }

        private void b_rect_MouseLeave(object sender, MouseEventArgs e)
        {
            b_rect.StrokeThickness = 0;
        }
    }
}
