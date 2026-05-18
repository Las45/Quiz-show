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

        private List<Klassen.Frage> quizFragen;

        public QuizAuswahl()
        {
            InitializeComponent();

            // Fragen hinzufügen

            quiz.Add(new Klassen.Frage(
                "Wofür steht POS?",
                new List<string>()
                {
                    "Point of Sale",
                    "Piece of System",
                    "Program of Service",
                    "Part of Software"
                },
                0
            ));

            quiz.Add(new Klassen.Frage(
                "Welcher Datentyp speichert ganze Zahlen?",
                new List<string>()
                {
                    "string",
                    "bool",
                    "int",
                    "double"
                },
                2
            ));

            quiz.Add(new Klassen.Frage(
                "Was macht Console.WriteLine()?",
                new List<string>()
                {
                    "Löscht Text",
                    "Gibt Text aus",
                    "Speichert Daten",
                    "Startet Schleife"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Welche Schleife läuft solange eine Bedingung wahr ist?",
                new List<string>()
                {
                    "for",
                    "switch",
                    "while",
                    "class"
                },
                2
            ));
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

            usercontrols.Frage frageControl = new usercontrols.Frage();

            var f = quizFragen[aktuelleFrage];

            frageControl.question = f.frage;

            frageControl.a_ = f.antworten[0];
            frageControl.b_ = f.antworten[1];
            frageControl.c_ = f.antworten[2];
            frageControl.d_ = f.antworten[3];

            frageControl.correct_answer =
                f.richtig == 0 ? "a" :
                f.richtig == 1 ? "b" :
                f.richtig == 2 ? "c" : "d";

            frageControl.FrageBeendet += NaechsteFrage;

            QuizContainer.Children.Add(frageControl);
        }

        private void NaechsteFrage(bool richtig)
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
    }
}