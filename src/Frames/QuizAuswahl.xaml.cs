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

            // Prompt: Erstelle mir 20 Frage zum the Programmieren von C#
            // KI: Chat GPT
            // Anfang KI:
            quiz.Add(new Klassen.Frage(
                "Wofür steht POS?",
                new List<string>()
                {
                    "Programmierung und Software",
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
                "Welches Zeichen beendet eine Anweisung in C#?",
                new List<string>()
                {
                    ".",
                    ";",
                    ":",
                    ","
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

            quiz.Add(new Klassen.Frage(
                "Wie erstellt man ein Objekt?",
                new List<string>()
                {
                    "new",
                    "create",
                    "make",
                    "class"
                },
                0
            ));

            quiz.Add(new Klassen.Frage(
                "Was bedeutet == ?",
                new List<string>()
                {
                    "zuweisen",
                    "gleich vergleichen",
                    "ungleich",
                    "plus"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Wie nennt man eine Methode ohne Rückgabe?",
                new List<string>()
                {
                    "void",
                    "int",
                    "string",
                    "bool"
                },
                0
            ));

            quiz.Add(new Klassen.Frage(
                "Was macht if?",
                new List<string>()
                {
                    "Schleife",
                    "Bedingung",
                    "Array",
                    "Objekt"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Was speichert string?",
                new List<string>()
                {
                    "Text",
                    "Zahlen",
                    "Farben",
                    "Buttons"
                },
                0
            ));

            quiz.Add(new Klassen.Frage(
                "Welche Klasse ist ein Fenster?",
                new List<string>()
                {
                    "Page",
                    "Window",
                    "Label",
                    "Canvas"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Wie kommentiert man einzeilig?",
                new List<string>()
                {
                    "//",
                    "/*",
                    "#",
                    "--"
                },
                0
            ));

            quiz.Add(new Klassen.Frage(
                "Was ist ein Array?",
                new List<string>()
                {
                    "eine Schleife",
                    "eine Liste",
                    "ein Fenster",
                    "eine Farbe"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Welche Zahl beginnt ein Arrayindex?",
                new List<string>()
                {
                    "1",
                    "-1",
                    "0",
                    "2"
                },
                2
            ));

            quiz.Add(new Klassen.Frage(
                "Was bedeutet else?",
                new List<string>()
                {
                    "wiederholen",
                    "ansonsten",
                    "stoppen",
                    "starten"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Was macht Random?",
                new List<string>()
                {
                    "Farben",
                    "Zufallszahlen",
                    "Fenster",
                    "Buttons"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Wie heißt die Hauptklasse in WPF?",
                new List<string>()
                {
                    "Page",
                    "Window",
                    "MainWindow",
                    "Grid"
                },
                2
            ));

            quiz.Add(new Klassen.Frage(
                "Was ist XAML?",
                new List<string>()
                {
                    "Datenbank",
                    "Designsprache",
                    "Spiel",
                    "Compiler"
                },
                1
            ));

            quiz.Add(new Klassen.Frage(
                "Welche Klasse enthält Kinder?",
                new List<string>()
                {
                    "Grid",
                    "Brush",
                    "Color",
                    "Mouse"
                },
                0
            ));

            quiz.Add(new Klassen.Frage(
                "Wie speichert man Wahr/Falsch?",
                new List<string>()
                {
                    "bool",
                    "string",
                    "int",
                    "char"
                },
                0
            ));
        }

        // Ende KI

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

            string correctAnswer = "";

            if (f.richtig == 0)
            {
                correctAnswer = "a";
            }
            else if (f.richtig == 1)
            {
                correctAnswer = "b";
            }
            else if (f.richtig == 2)
            {
                correctAnswer = "c";
            }
            else
            {
                correctAnswer = "d";
            }

            frageControl.correct_answer = correctAnswer;

            frageControl.FrageBeendet += NächsteFrage;


            QuizContainer.Children.Add(frageControl);
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