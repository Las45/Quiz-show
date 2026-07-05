using Quiz_show.src.Klassen;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Quiz_show.Frames
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mw;
        Supabase.Client client;
        public Windows.Register register;


        public Login(MainWindow window, Supabase.Client client)
        {
            InitializeComponent();
            this.mw = window;
            this.client = client;
            Logging.logger.Debug("Login page opened");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Height = 400;
            window.Width = 400;
        }
        private async void Weiter_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Logging.logger.Debug("Sign In with Password (Online Versuch)");
                Supabase.Gotrue.Session session = await this.client.Auth.SignInWithPassword(email_login.Text, password_login.Password);
                SaveOfflineCredentials(email_login.Text, password_login.Password);
                Weiter_login.IsEnabled = false;
                Shop.Load();
                mw.progress.Load();
                src.Klassen.Achievements.Load();
                this.mw.Change_Frame_by_name("Home");
            }
            catch (Exception ex)
            {
                if (IsNetworkError(ex))
                {
                    Logging.logger.Warning("Keine Internetverbindung. Versuche Offline-Login");

                    if (CheckOfflineCredentials(email_login.Text, password_login.Password))
                    {
                        MessageBox.Show("Erfolgreich im Offline-Modus angemeldet.");
                        Shop.Load();
                        mw.progress.Load();
                        src.Klassen.Achievements.Load();
                        this.mw.Change_Frame_by_name("Home");
                        return;
                    }
                }
                MessageBox.Show("Es gibt diesen User nicht, das Passwort ist falsch oder du bist offline.");
                Logging.logger.Error($"Login failed: {ex.Message}");
            }
        }

        private void SaveOfflineCredentials(string email, string password)
            {
                try
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offline_auth.txt");
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                        string hashedPassword = Convert.ToBase64String(hashBytes);
                        string content = $"{email};{hashedPassword}";
                        File.WriteAllText(path, content);
                        Logging.logger.Debug("Offline-Anmeldedaten erfolgreich aktualisiert.");
                    }
                }
                catch (Exception ex)
                {
                    Logging.logger.Error($"Fehler beim Speichern der Offline-Daten: {ex.Message}");
                }
            }

        private bool CheckOfflineCredentials(string email, string password)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "offline_auth.txt");

                // Wenn noch nie ein Online-Login stattgefunden hat, gibt es keine Offline-Datei
                if (!File.Exists(path))
                {
                    Logging.logger.Warning("Keine Offline-Anmeldedaten auf diesem PC gefunden.");
                    return false;
                }

                string content = File.ReadAllText(path);
                string[] parts = content.Split(';');

                if (parts.Length == 2)
                {
                    string savedEmail = parts[0];
                    string savedHash = parts[1];

                    // Eingegebenes Passwort hashen, um es mit dem gespeicherten Hash zu vergleichen
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                        byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                        string inputHash = Convert.ToBase64String(hashBytes);

                        // Prüfen, ob E-Mail und Passwort-Hash übereinstimmen
                        if (savedEmail.Equals(email, StringComparison.OrdinalIgnoreCase) && savedHash == inputHash)
                        {
                            Logging.logger.Information("Offline-Login erfolgreich via lokalem Hash.");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.logger.Error($"Fehler beim Prüfen der Offline-Daten: {ex.Message}");
            }

            return false;
        }

        private bool IsNetworkError(Exception ex)
            {
                // Hilfsmethode, um zu schauen, ob Supabase den Server einfach nicht erreichen konnte
                return ex.InnerException is System.Net.Http.HttpRequestException || ex.Message.Contains("Failed to fetch");
            }

        private void Password_fg_login_Click(object sender, RoutedEventArgs e)
        {
            Logging.logger.Debug("Password has been forgotten");
            mw.Change_Frame_by_name("Passwort_forgotten");
        }

        private void New_user_loin_Click(object sender, RoutedEventArgs e)
        {
            Logging.logger.Debug("A new User was Created");
            register = new Windows.Register(this.client);
            register.ShowDialog();
        }
    }
}
