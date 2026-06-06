using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show.src.Klassen
{
    public class Checker
    {
        public int Quizzes_correct { get; set; }
        public int Quizzes_prozent { get; set; }

        public void AddCorrect()
        {
            Quizzes_correct++;
        }

        public void Calculate(int gesamt)
        {
            if (gesamt <= 0)
            {
                Quizzes_prozent = 0;
                return;
            }

            Quizzes_prozent = Quizzes_correct * 100 / gesamt;
        }
    }
}