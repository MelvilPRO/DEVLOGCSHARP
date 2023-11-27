using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class Database
    {
        public List<User> DB;

        public Database()
        {
            DB = new List<User>();
        }

        public string GetStringRepresentation()
        {
            string result = "";
            for (int i = 0; i < DB.Count; i++)
            {
                User user = DB[i];
                result += user.GetStringRepresentation();
                result += "\n\n";
            }

            return result;
        }
    }
}
