using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show.Klassen
{
    public class Frage
    {


        public string frage;
        public List<string> antworten;
        public int richtig;



        public Frage(string frage, List<string> antworten, int richtig)
        {
            this.frage = frage;
            this.antworten = antworten;
            this.richtig = richtig;

        }




        public bool Check(int ausgewählt)
        {

            return  ausgewählt == richtig;
        }
    }
}