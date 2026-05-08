using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show.Klassen
{
    internal class Quiz
    {
        public List<string> Fragen = new List<string>();
        public List<string> Antwort1 = new List<string>();
        public List<string> Antwort2 = new List<string>();
        public List<string> Antwort3 = new List<string>();
        public List<string> Antwort4 = new List<string>();
        private List<int> Richtige = new List<int>();

        public Quiz()
        {

        }
    }
}
