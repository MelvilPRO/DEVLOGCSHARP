using System;

namespace Projet
{
    public class Program
    {
        static void Main(string[] args)
        {
            Calendar calendar = new Calendar(2022, EMonths.November, 29, EDays.Monday);

            while (calendar.Year != 2026)
                calendar.NextDay();

            Console.WriteLine("Fin du programme calendrier!");
        }
    }
}