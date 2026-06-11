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
using System.Windows.Media;

namespace Quiz_show.Frames
{
    public partial class QuizAuswahl : Page
    {
        private Quizclass quiz = new Quizclass();

        private Checker_Menue check;

        private Random random = new Random();

        private int aktuelleFrage = 0;

        private List<Frage> quizFragen;

        private static bool fünferschüler = false;
        private static bool perfekt = false;
        private Progress progress;

        private int aktuellesFach = 0;

        public QuizAuswahl(Checker_Menue checkerMenu, Progress sharedProgress)
        {
            InitializeComponent();

            check = checkerMenu;

            progress = sharedProgress;

            UpdateUI();

            Shop.ShopUpdated += UpdateUI;
        }

        private void UpdateUI()
        {
            PathExit.Fill = new SolidColorBrush(Shop.GetButtonColor());

            RectQuiz1.Fill = new SolidColorBrush(Shop.GetButtonColor());
            RectQuiz2.Fill = new SolidColorBrush(Shop.GetButtonColor());
            RectQuiz3.Fill = new SolidColorBrush(Shop.GetButtonColor());
            RectQuiz4.Fill = new SolidColorBrush(Shop.GetButtonColor());
            RectQuiz5.Fill = new SolidColorBrush(Shop.GetButtonColor());

            RectQuizBackground.Fill = new SolidColorBrush(Shop.GetBackgroundColor());
        }

        private void LadeQuiz(string jsonDatei, int fachIndex)
        {
            try
            {
                aktuellesFach = fachIndex;

                string path = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "src",
                    "JSON",
                    jsonDatei);

                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("JSON Datei wurde nicht gefunden:\n" + path);
                    return;
                }

                quiz = new Quizclass();

                quiz.Load(path);

                progress.Subjects[fachIndex].Quizzes_correct = 0;
                progress.Subjects[fachIndex].Quizzes_prozent = 0;

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
            else if (f.antworten.Count == 1) 
            {
                Textbox_Frage frageControl = new Textbox_Frage(f);
                frageControl.FrageBeendet += AntwortGegeben;
                QuizContainer.Children.Add(frageControl);
            }
        }

        private void AntwortGegeben(bool richtig)
        {
            if (richtig)
            {
                progress.Subjects[aktuellesFach].AddCorrect();
            }

            aktuelleFrage++;

            if (aktuelleFrage >= quizFragen.Count)
            {
                progress.Subjects[aktuellesFach]
                    .Calculate(quizFragen.Count);

                int anzahlRichtige = progress.Subjects[aktuellesFach].Quizzes_correct;
                if (anzahlRichtige == 1)
                {
                    if (!fünferschüler)
                    {
                        Shop.Money += 25;
                        fünferschüler = true;
                    }

                    Achievements.Unlock("5er Schüler");
                }
                if (anzahlRichtige == quizFragen.Count)
                {
                    if (!perfekt)
                    {
                        Shop.Money += 40;
                        perfekt = true;
                    }

                    Achievements.Unlock("Perfektionist");
                }


                check.Update();

                QuizContainer.Visibility = Visibility.Hidden;
                RectQuizBackground.Visibility = Visibility.Hidden;

                MessageBox.Show(
                    "Quiz beendet!\n" +
                    "Richtig: " +
                    progress.Subjects[aktuellesFach].Quizzes_correct +
                    "/" +
                    quizFragen.Count);

                return;
            }

            ZeigeFrage();
        }

        private void RectQuiz1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("POS_Fragen.json", 0);
        }

        private void RectQuiz2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("CABS_Fragen.json", 1);
        }

        private void RectQuiz3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("Englisch_Fragen.json", 2);
        }

        private void RectQuiz4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("Mathe_Fragen.json", 3);
        }

        private void RectQuiz5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("Geschichte_Fragen.json", 4);
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

        private void RectQuiz1_MouseEnter(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 0.7;
        }

        private void RectQuiz1_MouseLeave(object sender, MouseEventArgs e)
        {
            RectQuiz1.Opacity = 1;
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
    }
}