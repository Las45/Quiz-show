using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Quiz_show.src.Klassen
{
    public static class Achievements
    {
        private static List<Achievement> achievements = new()
        {
            new Achievement("Perfektionist"),
            new Achievement("5er Schüler"),
            new Achievement("1er Schüler"),
            new Achievement("Mode Designer"),
            new Achievement("Absolute Gleichheit"),
            new Achievement("Discord")
        };

        public static List<Achievement> AchievementList
        {
            get { return achievements; }
        }






        public static void Unlock(string name)
        {
            foreach (Achievement achievement in achievements)
            {
                if (achievement.Name == name)
                {
                    achievement.IsUnlocked = true;
                    Save();
                    return;


                }
            }
        }

        public static bool IsUnlocked(string name)
        {
            foreach (Achievement achievement in achievements)
            {
                if (achievement.Name == name)
                {

                    return achievement.IsUnlocked;
                }
            }

            return false;
        }

        public static void Save()
        {
            string json = JsonSerializer.Serialize(achievements);


            File.WriteAllText("achievements.json", json);
        }




        public static void Load()
        {
            if (!File.Exists("achievements.json"))
            {
                return;
            }


            string json = File.ReadAllText("achievements.json");

            List<Achievement> geladeneAchievements = JsonSerializer.Deserialize<List<Achievement>>(json);

            if (geladeneAchievements == null)
            {
                return;
            }

            achievements = geladeneAchievements;
        }
    }
}