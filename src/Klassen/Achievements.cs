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
                    Logging.logger.Debug($"Achievement unlocked: {name}");
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

            Logging.logger.Debug("Achievements saved");
            File.WriteAllText("achievements.json", json);
        }

        public static void Load()
        {
            if (!File.Exists("achievements.json"))
            {
                Logging.logger.Debug("No achievements file found!");
                return;
            }


            string json = File.ReadAllText("achievements.json");

            List<Achievement> geladeneAchievements = JsonSerializer.Deserialize<List<Achievement>>(json);

            if (geladeneAchievements == null)
            {
                Logging.logger.Debug("Achievements load failed (null)");
                return;
            }

            achievements = geladeneAchievements;
            Logging.logger.Debug("Achievements loaded");
        }
    }
}