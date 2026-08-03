using Quiz_show.src.Klassen;
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

namespace Quiz_show.src.usercontrols
{
    /// <summary>
    /// Interaktionslogik für Textbox_Frage.xaml
    /// </summary>
    public partial class Textbox_Frage : UserControl
    {
        private MainWindow _mainWindow;
        private OllamaSharp.OllamaApiClient ollama;
        public event Action<bool> FrageBeendet;
        private OllamaSharp.Chat chat;
        private Frage frage;
        StringBuilder stringBuilder = new StringBuilder();
        public Textbox_Frage(Frage frage)
        {
            InitializeComponent();
            _mainWindow = (MainWindow)Application.Current.MainWindow;
            ollama = _mainWindow.OllamaClient;
            this.frage = frage;
            Frage_Ki.Content = frage.frage;
            chat = new OllamaSharp.Chat(ollama);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_mainWindow.IsOllamaInstalled)
            {
                await foreach(string answertoken in chat.SendAsync($"Frage: {Antwort_textbox_ki.Text}\nAntwort: {frage.antworten[0]}\nStimmt die Frage und die Antwort Inhaltlich überein?\nBitte antworte mit nur true oder false und sei nicht sehr tolerant"))
                {
                    stringBuilder.Append(answertoken);
                }
                string response = stringBuilder.ToString().Trim().ToLower();

                if (response.Contains("true") || response.Contains("ja") || response.Contains("yes"))
                {
                    FrageBeendet?.Invoke(true);
                    return;
                }
                else
                    FrageBeendet?.Invoke(false);
            }
            else if (_mainWindow.IsOllamaInstalled == false)
            {
                if (frage.antworten[0].ToLower() == Antwort_textbox_ki.Text.ToLower())
                {
                    FrageBeendet?.Invoke(true);
                }
                else
                {
                    FrageBeendet?.Invoke(false);
                }
            }
        }
    }
}
