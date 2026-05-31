using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show.src.Klassen
{
    public class Achievement
    {
        public string Name { get; set; }
        public bool IsUnlocked { get; set; }

        public Achievement(string name)
        {
            Name = name;
            IsUnlocked = false;
        }
    }
}
