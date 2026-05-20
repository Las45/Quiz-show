using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Quiz_show.src.Klassen
{
    public class Quizclass
    {

        public List<Frage> Questions = new List<Frage>();



        public void Add(Frage frage)
        {

            Questions.Add(frage);

        }
    }
}