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

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für QuizAuswahl.xaml
    /// </summary>
    public partial class QuizAuswahl : Page
    {
        public QuizAuswahl()
        {
            InitializeComponent();
        }


        private List<(string frage, string a, string b, string c, string d, string richtig)> fragen = new List<(string, string, string, string, string, string)>()
        {
            // Prompt: Erstelle mit 50 fragen über das Thema C# Programmieren und gib mir jewals 4 Antwortmöglichkeiten wobei nur eine richtig ist.
            // KI: ChatGPT
            // Anfang KI:
            ("Wofür steht POS?", "Point of Sale", "Piece of System", "Program of Service", "Part of Software", "a"),
            ("Welcher Datentyp speichert ganze Zahlen?", "string", "bool", "int", "double", "c"),
            ("Was macht Console.WriteLine()?", "Löscht Text", "Gibt Text aus", "Speichert Daten", "Startet Schleife", "b"),
            ("Welches Zeichen beendet eine Anweisung in C#?", ".", ";", ":", ",", "b"),
            ("Welche Schleife läuft solange eine Bedingung wahr ist?", "for", "switch", "while", "class", "c"),
            ("Wie erstellt man ein Objekt?", "new", "create", "make", "class", "a"),
            ("Welche Farbe hat ein bool true?", "rot", "gelb", "grün", "keine", "d"),
            ("Was bedeutet == ?", "zuweisen", "gleich vergleichen", "ungleich", "plus", "b"),
            ("Welche Klasse zeigt Nachrichten?", "MessageBox", "Console", "Window", "Label", "a"),
            ("Wie nennt man eine Methode ohne Rückgabe?", "void", "int", "string", "bool", "a"),

            ("Was macht if?", "Schleife", "Bedingung", "Array", "Objekt", "b"),
            ("Was speichert string?", "Text", "Zahlen", "Farben", "Buttons", "a"),
            ("Welche Schleife hat Start, Bedingung und Schritt?", "while", "for", "if", "switch", "b"),
            ("Was bedeutet public?", "privat", "sichtbar", "versteckt", "geschützt", "b"),
            ("Welche Klasse ist ein Fenster?", "Page", "Window", "Label", "Canvas", "b"),
            ("Wie kommentiert man einzeilig?", "//", "/*", "#", "--", "a"),
            ("Was ist ein Array?", "eine Schleife", "eine Liste", "ein Fenster", "eine Farbe", "b"),
            ("Was macht break?", "stoppt", "startet", "kopiert", "zeichnet", "a"),
            ("Welche Zahl beginnt ein Arrayindex?", "1", "-1", "0", "2", "c"),
            ("Was bedeutet else?", "wiederholen", "ansonsten", "stoppen", "starten", "b"),

            ("Welche Klasse zeigt Text?", "Label", "Rectangle", "Canvas", "Brush", "a"),
            ("Was macht Random?", "Farben", "Zufallszahlen", "Fenster", "Buttons", "b"),
            ("Wie heißt die Hauptklasse in WPF?", "Page", "Window", "MainWindow", "Grid", "c"),
            ("Welche Farbe ist Brushes.Blue?", "Rot", "Gelb", "Blau", "Grün", "c"),
            ("Wie macht man eine Methode?", "void Name()", "method()", "class()", "new()", "a"),
            ("Was macht return?", "zurückgeben", "speichern", "löschen", "starten", "a"),
            ("Was ist XAML?", "Datenbank", "Designsprache", "Spiel", "Compiler", "b"),
            ("Was macht InitializeComponent()?", "lädt UI", "stoppt App", "speichert Daten", "macht Zufall", "a"),
            ("Welche Klasse enthält Kinder?", "Grid", "Brush", "Color", "Mouse", "a"),
            ("Was macht MouseEnter?", "Klick", "Maus geht hinein", "Maus verlässt", "Doppelklick", "b"),

            ("Wie speichert man Wahr/Falsch?", "bool", "string", "int", "char", "a"),
            ("Was bedeutet && ?", "oder", "nicht", "und", "plus", "c"),
            ("Welche Datei enthält Design?", ".cs", ".xaml", ".exe", ".dll", "b"),
            ("Wie heißt der Klick Event?", "MouseUp", "MouseBlue", "MouseClicker", "ButtonDown", "a"),
            ("Was macht Children.Add()?", "löscht", "hinzufügen", "kopieren", "beenden", "b"),
            ("Welche Klasse macht Farben?", "Brushes", "Colorsystem", "Paint", "UI", "a"),
            ("Was bedeutet private?", "öffentlich", "nur intern", "sichtbar", "vererbbar", "b"),
            ("Wie startet man eine App?", "Main()", "Run()", "Start()", "Open()", "a"),
            ("Was macht Visibility.Hidden?", "anzeigen", "verstecken", "löschen", "verschieben", "b"),
            ("Was ist Canvas.Left?", "Farbe", "Position", "Größe", "Text", "b"),

            ("Was macht Opacity?", "Position", "Transparenz", "Text", "Klick", "b"),
            ("Welche Klasse zeigt Rechtecke?", "Rectangle", "Label", "Window", "Grid", "a"),
            ("Wie prüft man Ungleich?", "!=", "==", ">=", "<=", "a"),
            ("Welche Klasse speichert Listen?", "List", "Canvas", "Window", "Brush", "a"),
            ("Was macht foreach?", "durchläuft Liste", "zeichnet", "speichert", "löscht", "a"),
            ("Welche Methode löscht Kinder?", "Children.Clear()", "Delete()", "RemoveAll()", "Destroy()", "a"),
            ("Was ist Margin?", "Abstand", "Farbe", "Klick", "Schrift", "a"),
            ("Welche Klasse macht Zufall?", "Random", "Brush", "Mouse", "Grid", "a"),
            ("Was macht ToString()?", "zu Text machen", "löschen", "starten", "stoppen", "a"),
            ("Welche Sprache nutzt WPF?", "HTML", "XAML", "CSS", "PHP", "b")
        };
        // Ende KI

        private Random Random = new Random();
        private int aktuelleFrage = 0;
        private List<(string frage, string a, string b, string c, string d, string richtig)> quizFragen;

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
            quizFragen = fragen


                .OrderBy(x => Random.Next())
                .Take(20)
                .ToList();

            aktuelleFrage = 0;


            ZeigeFrage();
            QuizContainer.Visibility = Visibility.Visible;
            RectQuizBackground.Visibility = Visibility.Visible;
        }

        private void ZeigeFrage()
        {
            QuizContainer.Children.Clear();

            Frage frageControl = new Frage();



            var f = quizFragen[aktuelleFrage];

            frageControl.question = f.frage;
            frageControl.a_ = f.a;
            frageControl.b_ = f.b;
            frageControl.c_ = f.c;
            frageControl.d_ = f.d;


            frageControl.correct_answer = f.richtig;
            frageControl.FrageBeendet += NaechsteFrage;


            QuizContainer.Children.Add(frageControl);


        }

        private void NaechsteFrage()
        {
            aktuelleFrage++;

            if (aktuelleFrage >= quizFragen.Count)
            {
                MessageBox.Show("Quiz beendet!");

                QuizContainer.Visibility = Visibility.Hidden;
                RectQuizBackground.Visibility = Visibility.Hidden;
                return;
            }

            ZeigeFrage();
        }
    }
}
