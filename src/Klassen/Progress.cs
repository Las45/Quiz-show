using Supabase.Gotrue;
using Supabase.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

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
                // 1. Hole zuerst alle bestehenden Einträge des Users
                var existingResponse = await GetMainWindow().client
                    .From<UserProgressModel>()
                    .Where(x => x.UserId == userId)
                    .Get();

                var existingRecords = existingResponse?.Models ?? new List<UserProgressModel>();

                for (int i = 0; i < Subjects.Count; i++)
                {
                    string json = JsonSerializer.Serialize(Subjects[i]);
                    try
                    {
                        UserProgressModel model = new UserProgressModel
                        {
                            UserId = userId,
                            SubjectIndex = i,
                            ProgressData = json,
                            TimeStamp = DateTime.UtcNow,
                        };

                        // 2. Prüfe, ob für dieses Fach (SubjectIndex) schon ein Eintrag existiert
                        var existing = existingRecords.FirstOrDefault(x => x.SubjectIndex == i);
                        if (existing != null)
                        {
                            // 3. Wenn ja, übernimm dessen Datenbank-Id für den Upsert!
                            model.Id = existing.Id;
                        }

                        await GetMainWindow().client
                            .From<UserProgressModel>()
                            .Upsert(model);
                    }
                    catch (Exception ex)
                    {
                        Logging.logger.Error($"Error beim Speichern von Supabase: {ex.Message}");
                    }
                    File.WriteAllText("progress.json", $"{json}\n{DateTime.UtcNow}");
                }

                Logging.logger.Debug("Fortschritt für alle Fächer erfolgreich gespeichert.");
            }
            catch (Exception ex)
            {
                Logging.logger.Error($"Fehler beim Speichern des Fortschritts: {ex.Message}");
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
                Supabase.Postgrest.Responses.ModeledResponse<UserProgressModel> response = await GetMainWindow().client
                    .From<UserProgressModel>()
                    .Where(x => x.UserId == userId)
                    .Get();

                if (response?.Models != null)
                {
                    foreach (UserProgressModel row in response.Models)
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

                Logging.logger.Debug("Fortschritt für alle Fächer geladen.");
            }
            catch (Exception ex)
            {
                Logging.logger.Error($"Fehler beim Laden des Fortschritts: {ex.Message}");
            }
        }
    }
}