using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlTest
{
       public class User
    {
        public string Id { get; set; }
        public string Name {  get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Telephone { get; set; }
        public DateTime DateBirth { get; set; }

        public User (string ID)
        {
            ID = Id;
        }
    }
}
