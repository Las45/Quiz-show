using Quiz_show.Frames;
using Quiz_show.src.Klassen;
using Quiz_show.src.usercontrols;
using Quiz_show.usercontrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_show.src.Frames
{
    /// <summary>
    /// Interaktionslogik für Quiz.xaml
    /// </summary>
    public partial class Quiz : Page
    {
        public Checker_Menue check;

        private int aktuelleFrage = 0;

        private List<Frage> quizFragen;

        private static bool fünferschüler = false;
        private static bool perfekt = false;
        private Progress progress;

        private int aktuellesFach = 0;
        public Quiz(Checker_Menue checkerMenu, Progress sharedProgress, List<Frage> fragen)
        {
            InitializeComponent();
            check = checkerMenu;
            progress = sharedProgress;
            quizFragen = fragen;
            ZeigeFrage();
        }
        private void ZeigeFrage()
        {
            QuizContainer.Children.Clear();
            QuizContainer.Background = new SolidColorBrush(Shop.GetBackgroundColor());
            Frage f = quizFragen[aktuelleFrage];

            if (f.antworten.Count == 4)
            {
                FrageUserControl frageControl = new FrageUserControl(f);
                frageControl.FrageBeendet += AntwortGegeben;
                frageControl.Width = 800;
                frageControl.Height = 400;
                QuizContainer.Children.Add(frageControl);
            }
            else if (f.antworten.Count == 2)
            {
                True_False frageControl = new True_False(f);
                frageControl.FrageBeendet += AntwortGegeben;
                frageControl.Width = 800;
                frageControl.Height = 400;
                QuizContainer.Children.Add(frageControl);
            }
            else if (f.antworten.Count == 1)
            {
                Textbox_Frage frageControl = new Textbox_Frage(f);
                frageControl.FrageBeendet += AntwortGegeben;
                frageControl.Width = 800;
                frageControl.Height = 400;
                QuizContainer.Children.Add(frageControl);
            }
        }

        private async void AntwortGegeben(bool richtig)
        {
            Logging.logger.Debug($"Answer given");

            if (richtig)
            {
                progress.Subjects[aktuellesFach].AddCorrect();
                QuizContainer.Background = Brushes.LightGreen;
                Logging.logger.Debug($"Answer was right");
            }
            else
            {
                QuizContainer.Background = Brushes.LightCoral;
            }

            aktuelleFrage++;
            await Task.Delay(1000);
            QuizContainer.Background = Brushes.Transparent;


            if (aktuelleFrage >= quizFragen.Count)
            {
                progress.Subjects[aktuellesFach].Calculate(quizFragen.Count);

                progress.Save();

                int anzahlRichtige = progress.Subjects[aktuellesFach].Quizzes_correct;
                Logging.logger.Debug($"Quiz ended");
                if (anzahlRichtige == 1)
                {
                    if (!fünferschüler)
                    {
                        Logging.logger.Debug("Unlocked '5er Schüler' Achievement");
                        Shop.Money += 25;
                        fünferschüler = true;
                    }

                    Achievements.Unlock("5er Schüler");
                }
                if (anzahlRichtige == quizFragen.Count)
                {
                    if (!perfekt)
                    {
                        Logging.logger.Debug("Unlocked '1er Schüler' Achievement");
                        Shop.Money += 25;
                        perfekt = true;
                    }

                    Achievements.Unlock("1er Schüler");
                }


                check.Update();

                Logging.logger.Information(
                    "Quiz beendet!\n" +
                    "Richtig: " +
                    progress.Subjects[aktuellesFach].Quizzes_correct +
                    "/" +
                    quizFragen.Count);
                MainWindow mw = (MainWindow)Application.Current.MainWindow;
                mw.Change_Frame_by_name("Quiz");
                return;
            }

            ZeigeFrage();
        }
    }
}
