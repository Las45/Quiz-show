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
            Logging.logger.Debug($"Correct answer added: {Quizzes_correct}");
        }

        public void Calculate(int gesamt)
        {
            if (gesamt <= 0)
            {
                Quizzes_prozent = 0;
                Logging.logger.Debug($"Quiz result calculated: 0% (0/{gesamt})");
                return;
            }
            Quizzes_prozent = Quizzes_correct * 100 / gesamt;
            Logging.logger.Debug($"Quiz result calculated: {Quizzes_prozent}% ({Quizzes_correct}/{gesamt})");
        }
    }
}