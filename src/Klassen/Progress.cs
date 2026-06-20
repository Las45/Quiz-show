using Supabase.Gotrue;
using Supabase.Interfaces;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Quiz_show.src.Klassen
{
    public class Progress
    {
        public List<Checker> Subjects { get; set; }
        MainWindow mainWindow;
        public Progress()
        {
            Subjects = new List<Checker>();

            for (int i=0; i<6; i++)
            {
                Subjects.Add(new Checker());
            }
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        public async Task Save()
        {
            string userId = mainWindow.client.Auth.CurrentUser?.Id;
            if (string.IsNullOrEmpty(userId)) 
                return;

            string json = JsonSerializer.Serialize(this);

            try
            {
                // Ki Anfang:
                // Model: Claude, Promt: Wie können wir den progress.json pro user auf superbase free server speichern
                UserProgressModel model = new UserProgressModel
                {
                    UserId = userId,
                    ProgressData = json
                };

                await mainWindow.client
                    .From<UserProgressModel>()
                    .Upsert(model);
                // Ki Ende
                Logging.logger.Debug("Progress wurde in der Cloude gesaved");
            }
            catch
            {
                Logging.logger.Error("Es konnte nicht auf Superbase gespeichert werden");
            }
        }

        public async Task Load()
        {
            string userId = mainWindow.client.Auth.CurrentUser?.Id;
            if (string.IsNullOrEmpty(userId)) 
                return;
            try
            {
                // Ki Anfang:
                // Model: Claude, Promt: Wie können wir den progress.json pro user auf superbase free server speichern
                UserProgressModel? row = await mainWindow.client
            .From<UserProgressModel>()
            .Where(x => x.UserId == userId)
            .Single();

                if (row?.ProgressData == null) return;

                Progress? geladen = JsonSerializer.Deserialize<Progress>(row.ProgressData);
                if (geladen != null)
                    Subjects = geladen.Subjects;
                // Ki ende
                Logging.logger.Debug("Progress wurde geloaded von der Cloude");
            }
            catch 
            {
                Logging.logger.Error("Es konnte nicht von Superbase geladen werden");
            }
        }
    }
}