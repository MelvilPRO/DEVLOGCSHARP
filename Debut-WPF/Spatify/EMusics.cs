using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut_WPF
{
    public enum EMusics
    {
        Rock,
        Rap,
        Jazz,
        Pop,
    }
    public class EMusicsHelper
    {
        public static string GetString(EMusics musicType)
        {
            switch (musicType)
            {
                case EMusics.Rock:
                    return "Rock";
                case EMusics.Rap:
                    return "Rap";
                case EMusics.Jazz:
                    return "Jazz";
                case EMusics.Pop:
                    return "Pop";
                default:
                    return "";
            }
        }
    }
    
}
