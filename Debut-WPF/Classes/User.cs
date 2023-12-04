using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public MonthSubscriptions.eSubscriptions Subscription { get; set; }
        public bool Newsletter { get; set; }

        public User(string lastName, string firstName, MonthSubscriptions.eSubscriptions subscription, bool newsletter)
        {
            LastName = lastName;
            FirstName = firstName;
            Subscription = subscription;
            Newsletter = newsletter;
        }

        public string GetStringRepresentation()
        {
            string result = LastName + " " + FirstName + "\n";
            result = MonthSubscriptions.SubscriptionAsString(Subscription) + "\n";

            if (Newsletter)
                result += "Inscrit à la Newsletter\n";
            else
                result += "N'est pas inscrit à la Newsletter\n";

            return result;
        }
    }
}
