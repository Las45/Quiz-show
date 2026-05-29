using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Quiz_show.src.Klassen
{
    public class Progress
    {
        public List<Checker> Subjects { get; set; }

        public Progress()
        {
            Subjects = new List<Checker>();


            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
        }

        public void Save()
        {

        }

        public void Load()
        {

        }
    }
}