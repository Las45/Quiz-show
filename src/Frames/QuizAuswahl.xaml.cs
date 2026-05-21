using Quiz_show.Klassen;
using Quiz_show.usercontrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quiz_show.Frames
{
    public partial class QuizAuswahl : Page
    {
        private Quizclass quiz = new Quizclass();

        private Checker checker = new Checker();

        private Random random = new Random();

        private int aktuelleFrage = 0;

        private List<Frage> quizFragen;



        public QuizAuswahl()
        {
            InitializeComponent();

            try
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"JSON","POS_Fragen.json");

                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("JSON Datei wurde nicht gefunden:\n" + path);
                    return;
                }

                quiz.Load(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden der Quiz-Datei:\n" + ex.Message);
            }
        }
        private void RectQuiz1_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 0.7;
        }

        private void RectQuiz1_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 1;
        }

        private void RectQuiz1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            checker.Quizzes_correct = 0;

            quizFragen = quiz.Questions
                .OrderBy(x => random.Next())
                .Take(20)
                .ToList();

            aktuelleFrage = 0;

            QuizContainer.Visibility = Visibility.Visible;
            RectQuizBackground.Visibility = Visibility.Visible;

            ZeigeFrage();
        }

        private void ZeigeFrage()
        {
            QuizContainer.Children.Clear();

            Frage f = quizFragen[aktuelleFrage];

            usercontrols.FrageUserControl frageControl =
                new usercontrols.FrageUserControl(f);

            frageControl.FrageBeendet += AntwortGegeben;

            QuizContainer.Children.Add(frageControl);
        }

        private void AntwortGegeben(int antwort)
        {
            bool richtig =
                quizFragen[aktuelleFrage].Check(antwort);

            if (richtig)
            {
                checker.Quizzes_correct++;
            }

            aktuelleFrage++;

            if (aktuelleFrage >= quizFragen.Count)
            {
                checker.Calculate(quizFragen.Count);

                MessageBox.Show(
                    "Quiz beendet!\n\n" +
                    "Richtig: " + checker.Quizzes_correct + "\n" +
                    "Prozent: " + checker.Quizzes_prozent + "%"
                );

                QuizContainer.Visibility = Visibility.Hidden;
                RectQuizBackground.Visibility = Visibility.Hidden;

                return;
            }

            ZeigeFrage();
        }
        private void NächsteFrage(bool richtig)
        {
            if (richtig)
            {
                checker.Quizzes_correct++;
            }

            aktuelleFrage++;

            if (aktuelleFrage >= quizFragen.Count)
            {
                checker.Calculate(quizFragen.Count);

                MessageBox.Show(
                    "Quiz beendet!\n\n" +
                    "Richtig: " + checker.Quizzes_correct + "\n" +
                    "Prozent: " + checker.Quizzes_prozent + "%"
                );

                QuizContainer.Visibility = Visibility.Hidden;
                RectQuizBackground.Visibility = Visibility.Hidden;

                return;
            }

            ZeigeFrage();
        }

        private void PathExit_MouseEnter(object sender, MouseEventArgs e)
        {
            PathExit.Opacity = 0.7;
        }

        private void PathExit_MouseLeave(object sender, MouseEventArgs e)
        {
            PathExit.Opacity = 1;
        }

        private void PathExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;

            main.Change_Frame_by_name("Home");
        }
    }
}