using System.Text.Json.Serialization;

namespace Quiz_show.Klassen
{
    public class Frage
    {
        public string frage { get; set; }
        public List<string> antworten { get; set; }
        public int richtig { get; set; }

        public Frage() { } 

        public Frage(string frage, List<string> antworten, int richtig)
        {
            frage = frage;
            antworten = antworten;
            richtig = richtig;
        }

        public bool Check(int ausgewählt)
        {
            return ausgewählt == richtig;
        }
    }
}