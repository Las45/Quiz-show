using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show.src.Klassen
{
    public class Checker
    {
        public int Quizzes_correct = 0;
        public int Quizzes_prozent = 0;


        public void AddCorrect()
        {
            Quizzes_correct++;
        }


        public void Calculate(int gesamt)
        {
            Quizzes_prozent = Quizzes_correct * 100 / gesamt;
        }
    }
}