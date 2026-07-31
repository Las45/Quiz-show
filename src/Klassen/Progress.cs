using Supabase.Gotrue;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Quiz_show.src.Klassen
{
    public class Progress
    {
        public List<Checker> Subjects { get; set; }

        public Progress()
        {
            Subjects = new List<Checker>();

            for (int i = 0; i < 6; i++)
            {
                Subjects.Add(new Checker());
            }
        }

        private MainWindow GetMainWindow() => (MainWindow)Application.Current.MainWindow;

        /// <summary>
        /// Speichert alle 6 Fächer/Slot-Zustände einzeln in Supabase ab.
        /// </summary>
        public async Task Save()
        {
            string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
            if (string.IsNullOrEmpty(userId))
                return;

            try
            {
                // Für jedes Fach (0 bis 5) wird ein eigenen Eintrag in user_progress angelegt/aktualisiert
                for (int i = 0; i < Subjects.Count; i++)
                {
                    string json = JsonSerializer.Serialize(Subjects[i]);

                    UserProgressModel model = new UserProgressModel
                    {
                        UserId = userId,
                        SubjectIndex = i,
                        ProgressData = json
                    };

                    await GetMainWindow().client
                        .From<UserProgressModel>()
                        .Upsert(model);
                }

                Logging.logger.Debug("Fortschritt für alle Fächer erfolgreich in Supabase gespeichert.");
            }
            catch (Exception ex)
            {
                Logging.logger.Error($"Fehler beim Speichern des Fortschritts in Supabase: {ex.Message}");
            }
        }

        /// <summary>
        /// Lädt die Fortschritte der Fächer (Slots 0 bis 5) aus Supabase.
        /// </summary>
        public async Task Load()
        {
            string userId = GetMainWindow().client.Auth.CurrentUser?.Id;
            if (string.IsNullOrEmpty(userId))
                return;

            try
            {
                var response = await GetMainWindow().client
                    .From<UserProgressModel>()
                    .Where(x => x.UserId == userId)
                    .Get();

                if (response?.Models != null)
                {
                    foreach (var row in response.Models)
                    {
                        // Stellt sicher, dass der Index im zulässigen Bereich liegt
                        if (row.SubjectIndex >= 0 && row.SubjectIndex < Subjects.Count && !string.IsNullOrEmpty(row.ProgressData))
                        {
                            Checker? loadedChecker = JsonSerializer.Deserialize<Checker>(row.ProgressData);
                            if (loadedChecker != null)
                            {
                                Subjects[row.SubjectIndex] = loadedChecker;
                            }
                        }
                    }
                }

                Logging.logger.Debug("Fortschritt für alle Fächer aus Supabase geladen.");
            }
            catch (Exception ex)
            {
                Logging.logger.Error($"Fehler beim Laden des Fortschritts aus Supabase: {ex.Message}");
            }
        }
    }
}