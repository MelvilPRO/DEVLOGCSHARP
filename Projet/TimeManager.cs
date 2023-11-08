using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class TimeManager
    {
        /* Script de test pour le module */
        public static void SeparateTP()
        {
            int secondes = 163;
            int heures = 0;
            int minutes = 0;
            GetFullTimeFromSeconds(ref secondes, ref heures, ref minutes);
            Console.WriteLine(heures + "H" + minutes + "M" + secondes);
        }
        /* Prendre la référence des secondes comme un parametre en entrée
         * Prendre la référence des heures comme un parametre de sortie
         * Prendre la référence des minutes comme un parametre de sortie
         */
        public static void GetFullTimeFromSeconds(ref int secondes, ref int heures, ref int minutes)
        {
            minutes = secondes / 60;
            heures = minutes / 60;
            secondes %= 60;
        }
    }
}
