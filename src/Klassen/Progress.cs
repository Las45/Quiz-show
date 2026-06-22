using System.IO;
using System.Text.Json;

namespace Quiz_show.src.Klassen
{
    public class Progress
    {
        public List<Checker> Subjects { get; set; }

        public Progress()
        {
            Subjects = new List<Checker>();

            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
            Subjects.Add(new Checker());
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText("progress.json", json);

            Logging.logger.Debug("Progress saved");
        }

        public void Load()
        {
            if (!File.Exists("progress.json"))
            {
                Logging.logger.Debug("Progress file not found");
                return;
            }

            string json = File.ReadAllText("progress.json");
            Progress geladen = JsonSerializer.Deserialize<Progress>(json);
            if (geladen != null)
            {
                Subjects = geladen.Subjects;
                Logging.logger.Debug("Progress loaded");


            }
            else
            {
                Logging.logger.Debug("Progress load failed (null)");
            }
        }
    }
}