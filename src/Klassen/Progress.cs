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
            string json = JsonSerializer.Serialize(this);
            //File.WriteAllText("progress.json", json);
        }

        public async Task Load()
        {
            Progress? geladen;
            try
            {
                // Ki Anfang:
                // Model: Claude, Promt: Wie können wir den progress.json pro user auf superbase free server speichern
                Supabase.Postgrest.Responses.ModeledResponse<UserProgressModel> result = await mainWindow.client
                    .From<UserProgressModel>()
                    .Where(x => x.UserId == $"{mainWindow.client.Auth.CurrentUser}")
                    .Get();

                UserProgressModel row = result.Models.FirstOrDefault();
                if (row?.ProgressData == null) return;

                geladen = JsonSerializer.Deserialize<Progress>(row.ProgressData);
                if (geladen != null)
                    Subjects = geladen.Subjects;
                // Ki ende
            }
            catch 
            {
                Logging.logger.Error("Es konnte nicht von Superbase geladen werden");
            }

            if (geladen != null)
            {
                Subjects = geladen.Subjects;
            }
        }
    }
}