using System.Collections.Generic;

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
            new Achievement("Absolute Gleichheit")
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
    }
}