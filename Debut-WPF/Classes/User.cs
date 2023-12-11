using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class User
    {
        string Name { get; set; }
        int Score { get; set; }
        public User(string nameInit, int scoreInit)
        {
            Name = nameInit;
            Score = scoreInit;
        }
    }
}
