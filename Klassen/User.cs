using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_show.Klassen
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string EMail {  get; private set; }
        public string Password {  get; private set; }

        public User(int id, string name, string email, string password)
        {
            this.Id = id;
            this.Name = name;
            this.EMail = email;
            this.Password = password;
        }
    }
}
