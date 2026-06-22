using OllamaSharp;
using OllamaSharp.Models;
using Quiz_show.Frames;
using Quiz_show.Klassen;
using Quiz_show.src.Klassen;
using Quiz_show.src.Windows;
using Supabase;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace Quiz_show
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool discord = false;
        Quizclass steuerung = new Quizclass();
        public Progress progress = new Progress();
        private Process? _ollamaProcess;
        public bool IsOllamaInstalled = false;
        public OllamaApiClient OllamaClient = new OllamaApiClient(new Uri("http://localhost:11434"));
        public Dictionary<string, Page> Frames = new Dictionary<string, Page>();
        public Supabase.Client client = new Client("https://qlfhcheflwewcyjhyzfr.supabase.co", "sb_publishable_DeKeXIVOxjyrM5OQSKUtmQ_NBlyc-zp");
        public MainWindow()
        {
            Logging.init();

            Logging.logger.Debug("App starting");
            progress.Load();
            Shop.Load();
            src.Klassen.Achievements.Load();
            Logging.logger.Debug("Data loaded (progress/shop/achievements)");
            Checker_Menue checkerMenu = new Checker_Menue(progress);
            Frames.Add("Home", new Homepage());
            Frames.Add("Login", new Login(this, client));
            Frames.Add("Checker", checkerMenu);
            Frames.Add("Passwort_forgotten", new forgotten_password(client, this));
            Frames.Add("Shop", new Shoppage());
            Frames.Add("Quiz", new QuizAuswahl(checkerMenu, progress));
            Frames.Add("Achievements", new Achievementspage());
            InitializeComponent();
            UpdateUI();
            Logging.logger.Debug("UI initialized + frames ready");
            StartOllamaServer();
            OllamaClient.SelectedModel = "llama3.2:1b";
            Logging.logger.Debug("Ollama started + model set");
            Main_frames.Content = Frames["Login"];
            Logging.logger.Debug("Login screen loaded");
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (Page page in Frames.Values)
            {
                page.Height = window.ActualHeight;
                page.Width = window.ActualWidth;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //((Checker_Menue)Frames["Stats"]).Save();
            _ollamaProcess?.Kill();
            _ollamaProcess?.Dispose(); // Lässt alle resurcen los
            Shop.Save();
            progress.Save();
        }
        public void Change_Frame_by_name(string frame)
        {
            Main_frames.Content = Frames[frame];
        }
        public void Change_Frame(Page frame)
        {
            Main_frames.Content = frame;
        }

        private void UpdateUI()
        {
            Main_frames.Background = new SolidColorBrush(Shop.GetBackgroundColor());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Das Achievements ist eine Reference zu dem längsten Discord Call in dem Klassen Discord Server, welcher 18 Stunden ging.
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = TimeSpan.FromHours(18);

            timer.Tick += (sender, e) =>
            {
                if (!discord)
                {
                    Shop.Money += 100;
                    discord = true;
                }
                src.Klassen.Achievements.Unlock("Discord");
                timer.Stop();
            };
            timer.Start();
        }
        private async Task CheckOllamaAsync() // Das mit Task kam vom Claude sowie nur IEnumerable<Model>, der restliche code kam von mir
        {
            try
            {
                IEnumerable<Model> models = await OllamaClient.ListLocalModelsAsync();
                bool modellVorhanden = models.Any(m => m.Name.Contains("llama3.2")); // Und diese Line hat claude verkürzt

                if (!modellVorhanden)
                {
                    IsOllamaInstalled = false;
                }
                else
                {
                    IsOllamaInstalled = true;
                }
            }
            catch
            {
                IsOllamaInstalled = false;
            }
        }
        // Folgender Code kommt von claude:
        // Promt: Wie kann man die Ollama.exe starten?
        private void StartOllamaServer()
        {
            // Pfad zur gebündelten ollama.exe
            string ollamaPath = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "src", "AI", "ollama.exe"
            );

            // Prüfen ob Ollama schon läuft (z.B. vom User manuell gestartet)
            if (Process.GetProcessesByName("ollama").Length > 0)
            {
                Logging.logger.Information("Ollama läuft bereits");
                return;
            }

            _ollamaProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ollamaPath,
                    Arguments = "serve",
                    UseShellExecute = false,
                    CreateNoWindow = true,   // kein schwarzes Fenster
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };

            _ollamaProcess.Start();
            Logging.logger.Information("Ollama Server gestartet");
        }
        // Claude ende
    }
}