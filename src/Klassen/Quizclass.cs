using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

<<<<<<< HEAD
namespace Quiz_show.Klassen
=======

namespace Quiz_show.src.Klassen
>>>>>>> 0c985d25c9bd066bcf49fcc533061dc2878291a0
{
    public class Quizclass
    {
        public List<Frage> Questions =
            new List<Frage>();

        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("Datei nicht gefunden: " + path);
                Questions = new List<Frage>();
                return;
            }

            string json = File.ReadAllText(path);

            Questions = JsonSerializer.Deserialize<List<Frage>>(json);

            if (Questions == null)
            {
                Questions = new List<Frage>();
            }
        }

        public void Add(Frage frage)
        {
            Questions.Add(frage);
        }
    }
}