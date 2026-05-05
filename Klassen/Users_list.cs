using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz_show.Klassen
{
    public class Users_list
    {
        public List<User> Users = new List<User>();

        public Users_list() 
        {
            Load_users();
        }

        public void Load_users()
        {
            string users_string;
            try
            {
                users_string = File.ReadAllText("users.json");
                Users = JsonSerializer.Deserialize<List<User>>(users_string);
            }
            catch (Exception ex)
            {
                
            }
        }

        public void Save_users()
        {
            File.WriteAllText("users.json", JsonSerializer.Serialize(Users)); 
        }
    }
}
