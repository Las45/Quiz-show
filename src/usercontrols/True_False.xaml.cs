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

            Frage_true_false.Text = frage.frage;
        }

        private void check(int index)
        {
            bool richtig = frage.Check(index);

            if (richtig)
                MessageBox.Show("Richtig!");
            else
                MessageBox.Show("Falsch!");

            FrageBeendet?.Invoke(richtig);
        }
        private void Yes_uc_Click(object sender, RoutedEventArgs e)
        {
            check(0);
        }

        private void No_uc_Click(object sender, RoutedEventArgs e)
        {
            check(1);
        }
    }
}
