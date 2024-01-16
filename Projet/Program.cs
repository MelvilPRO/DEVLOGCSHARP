using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Projet
{
    public class Program
    {
        static void Main(string[] args)
        {
            ChaineCommencantParP("Papa");
            ChaineCommencantParP("dapa");
            Console.WriteLine("");
            ChaineCommencantParPSuiviExactement4Caracterees("PHell");
            ChaineCommencantParPSuiviExactement4Caracterees("PHella");
            ChaineCommencantParPSuiviExactement4Caracterees("PHel");
            Console.WriteLine("");
            ChaineCommencantParPSuiviExactement4CaractereesAlphabetiques("PHeka");
            ChaineCommencantParPSuiviExactement4CaractereesAlphabetiques("PHe2a");
            ChaineCommencantParPSuiviExactement4CaractereesAlphabetiques("PHe$a");
            Console.WriteLine("");
            ChaineCommencantParPTerminantParT("PHe$T");
            ChaineCommencantParPTerminantParT("PHe$A");
            ChaineCommencantParPTerminantParT("P");
            Console.WriteLine("");
            CapturerToutesLesChainesDe10CaracteresSuivantes("<item>SalutationThomasMansion");
            CapturerToutesLesChainesDe10CaracteresSuivantes("<ite");
            CapturerToutesLesChainesDe10CaracteresSuivantes("aaaaaaa<item>SalutationThomasMansion");
        }

        static void ChaineCommencantParP(string input)
        {
            REMatch(@"^P", input);
        }

        static void ChaineCommencantParPSuiviExactement4Caracterees(string input)
        {
            REMatch(@"^P.{4}$", input);
        }

        static void ChaineCommencantParPSuiviExactement4CaractereesAlphabetiques(string input)
        {
            REMatch(@"^P[A-Za-z]{4}$", input);
        }

        static void ChaineCommencantParPTerminantParT(string input)
        {
            REMatch(@"^P.*T$", input);
        }

        static void CapturerToutesLesChainesDe10CaracteresSuivantes(string input)
        {
            int numberExtraction = 10;
            string searchedKey = "<item>";

            int position = input.IndexOf(searchedKey);
            if (position == -1)
            {
                Console.WriteLine("La clé cherchée n'est pas présente, nous ne pouvons pas récupérer les 10 caractères par 10 caractères suivant!");
                return;
            }

            int startPosition = position + searchedKey.Length;
            while (numberExtraction <= input.Length - startPosition)
            {
                string extracted = input.Substring(startPosition, numberExtraction);
                Console.WriteLine("Voici les 10 caractères suivants: " + extracted);
                startPosition += numberExtraction;
            }
        }

        static void REMatch(string pattern, string input) 
        {
            Regex regex;
            try
            {
                regex = new Regex(pattern);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue avec le constructeur de Regex!");
                return;
            }
            bool match;
            try
            {
                match = regex.IsMatch(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue avec la methode regex.IsMatch!");
                return;
            }

            Console.WriteLine(match);
        }
    }
}