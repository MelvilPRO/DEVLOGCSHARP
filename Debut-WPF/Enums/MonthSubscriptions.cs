using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public class MonthSubscriptions
    {
        public enum eSubscriptions
        {
            SingleMonth,
            SixMonths,
            SingleYear
        }

        static public string SubscriptionAsString(eSubscriptions subscription)
        {
            string result = "";

            switch(subscription)
            {
            case eSubscriptions.SingleMonth:
                result = "1 Month";
                break;
            case eSubscriptions.SixMonths:
                result = "6 Month";
                break;
            case eSubscriptions.SingleYear:
                result = "1 Year";
                break;
            default:
                result += "Unknown Time!";
                break;
            }

            return result;
        }
    }
}
