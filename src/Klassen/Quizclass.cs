using Quiz_show.src.Klassen;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Quiz_show.Klassen
{
    public class Quizclass
    {
        public List<Frage> Questions =new List<Frage>();

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                Logging.logger.Debug($"Quiz file not found");
                Questions = new List<Frage>();
                return;
            }

            string json = File.ReadAllText(path);
            Questions = JsonSerializer.Deserialize<List<Frage>>(json);

            if (Questions == null)
            {
                Questions = new List<Frage>();
                Logging.logger.Debug("Quiz load failed (null)");
                return;
            }

            Logging.logger.Debug($"Quiz loaded");
        }

        public void Add(Frage frage)
        {
            Questions.Add(frage);
            Logging.logger.Debug("Question added to Quiz");
        }
    }
}

