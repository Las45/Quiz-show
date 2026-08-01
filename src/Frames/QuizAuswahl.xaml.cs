using Quiz_show.Klassen;
using Quiz_show.src.Frames;
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

        public Checker_Menue check;

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
            Logging.logger.Debug("QuizAuswahl opened");
            check = checkerMenu;

            progress = sharedProgress;

            UpdateUI();
            Logging.logger.Debug("UI initialized");
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

        }

        private void LadeQuiz(string jsonDatei, int fachIndex)
        {
            try
            {
                Logging.logger.Debug($"Quiz started");
                aktuellesFach = fachIndex;

                string path = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "src",
                    "JSON",
                    jsonDatei);
                Logging.logger.Debug("Quiz loaded");

                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("JSON Datei wurde nicht gefunden:\n" + path);
                    Logging.logger.Error("JSON Datei wurde nicht gefunden:\n" + path);
                    return;
                }

                // FIX 1: Subjects-Liste prüfen bevor Index-Zugriff
                if (progress.Subjects == null || fachIndex >= progress.Subjects.Count)
                {
                    MessageBox.Show("Fach nicht gefunden. Index: " + fachIndex);
                    Logging.logger.Error("Fach nicht gefunden. Index: " + fachIndex);
                    return;
                }

                quiz = new Quizclass();
                quiz.Load(path);

                progress.Subjects[fachIndex].Quizzes_correct = 0;


                // FIX 2: Fragen mischen ohne Lambda
                List<Frage> alleFragen = quiz.Questions;
                List<Frage> gemischt = new List<Frage>();

                while (alleFragen.Count > 0)
                {
                    int index = random.Next(alleFragen.Count);
                    gemischt.Add(alleFragen[index]);
                    alleFragen.RemoveAt(index);
                }

                // FIX 3: Take(20) sicher machen - nimm nur so viele wie vorhanden
                int anzahl = gemischt.Count < 20 ? gemischt.Count : 20;
                quizFragen = new List<Frage>();

                for (int i = 0; i < anzahl; i++)
                {
                    quizFragen.Add(gemischt[i]);
                }
                Logging.logger.Debug("Taking Questions (max 20)");
                aktuelleFrage = 0;

                MainWindow mw = (MainWindow)Application.Current.MainWindow;
                mw.Change_Frame(new Quiz(check, progress, quizFragen));
            }
            catch (Exception ex)
            {
                Logging.logger.Error("Fehler beim Laden:\n" + ex.Message);
            }
        }
        private void RectQuiz1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("POS_Fragen.json", 0);
        }

        private void RectQuiz2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("NSCS_Fragen.json", 1);
        }

        private void RectQuiz3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("Englisch_Fragen.json", 2);
        }

        private void RectQuiz4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LadeQuiz("CABS_Fragen.json", 3);
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