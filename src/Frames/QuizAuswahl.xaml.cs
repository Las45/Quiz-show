using Quiz_show.Klassen;
using Quiz_show.src.Klassen;
using Quiz_show.src.usercontrols;
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
        }

        private void LadeQuiz(string jsonDatei)
        {
            try
            {
                string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"src","JSON",jsonDatei);

                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("JSON Datei wurde nicht gefunden:\n" + path);
                    return;
                }

                quiz = new Quizclass();

                quiz.Load(path);

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
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Laden:\n" + ex.Message);
            }
        }

        private void ZeigeFrage()
        {
            QuizContainer.Children.Clear();

            Frage f = quizFragen[aktuelleFrage];

            if (f.antworten.Count == 4)
            {
                FrageUserControl frageControl = new FrageUserControl(f);
                frageControl.FrageBeendet += AntwortGegeben;
                QuizContainer.Children.Add(frageControl);
            }
            else if (f.antworten.Count == 2)
            {
                True_False frageControl = new True_False(f);
                frageControl.FrageBeendet += AntwortGegeben;
                QuizContainer.Children.Add(frageControl);
            }
        }

        private void AntwortGegeben(bool richtig)
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

        private void RectQuiz1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("test.json");// Muss auf Pos geändert werden
        }

        private void RectQuiz2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("CABS_Fragen.json");
        }

        private void RectQuiz3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("Englisch_Fragen.json");
        }

        private void RectQuiz4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("CABS_Fragen.json");
        }

        private void RectQuiz5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("Geschichte_Fragen.json");
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

        private void RectQuiz2_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz2.Opacity = 0.7;
        }

        private void RectQuiz2_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz2.Opacity = 1;
        }

        private void RectQuiz3_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz3.Opacity = 0.7;
        }

        private void RectQuiz3_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz3.Opacity = 1;
        }

        private void RectQuiz4_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz4.Opacity = 0.7;
        }

        private void RectQuiz4_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz4.Opacity = 1;
        }

        private void RectQuiz5_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz5.Opacity = 0.7;
        }

        private void RectQuiz5_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz5.Opacity = 1;
        }

        private void RectQuiz1_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 1;
        }

        private void RectQuiz1_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 0.7;
        }
    }
}