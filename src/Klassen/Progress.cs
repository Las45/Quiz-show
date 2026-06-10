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
        }

        public void Load()
        {
            if (!File.Exists("progress.json"))
                return;

            string json = File.ReadAllText("progress.json");



            Progress geladen = JsonSerializer.Deserialize<Progress>(json);





            if (geladen != null)
            {
                Subjects = geladen.Subjects;
            }
        }
    }
}