using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    internal class Calendar
    {
        public int Year { get; set; }
        public EMonths Month { get; set; }
        public int DayNumber { get; set; }
        public EDays Day { get; set; }

        private bool passingNextWeek;
        private bool passingNextMonth;
        private bool passingNextYear;

        public Calendar(int year, EMonths month, int dayNumber, EDays day)
        {
            Year = year;
            Month = month;
            DayNumber = dayNumber;
            Day = day;

            passingNextWeek = false;
            passingNextMonth = false;
            passingNextYear = false;
        }

        public delegate void NewDayDelegate();
        public event NewDayDelegate OnNextDaySubscribers;
        public void NextDay()
        {
            if (OnNextDaySubscribers == null)
            {
                OnNextDaySubscribers += OnNextDay;
                OnNextDaySubscribers += OnNextWeek;
                OnNextDaySubscribers += OnNextMonth;
                OnNextDaySubscribers += OnNextYear;
                OnNextDaySubscribers += OnNextDayApplied;
                OnNextDaySubscribers += OnNextDayEnd;
            }

            OnNextDaySubscribers();
        }

        public void OnNextDay()
        {
            
        }

        public void OnNextWeek()
        {
            if (Day == EDays.Sunday)
                passingNextWeek = true;
        }

        public void OnNextMonth()
        {
            if (DayNumber == 30)
                passingNextMonth = true;
        }

        public void OnNextYear()
        {
            if (passingNextMonth && Month == EMonths.December)
                passingNextYear = true;
        }

        public void OnNextDayApplied()
        {
            if (DayNumber < 30)
            {
                DayNumber++;
            }

            if (passingNextWeek)
                Day = EDays.Monday;
            else
            {
                Day++;
            }

            if (passingNextMonth)
            {
                if (Month == EMonths.December)
                    Month = EMonths.January;
                else
                    Month++;

                DayNumber = 0;
            }
               
            if (passingNextYear)
            {
                Year++;
            }
        }

        public void OnNextDayEnd()
        {
            string consoleMessage = "We are passing a new day!";

            if (passingNextWeek)
            {
                consoleMessage += " We are also passing a new week!";
            }

            if (passingNextMonth)
            {
                consoleMessage += " We are also passing a new month!";
            }

            if (passingNextYear)
            {
                consoleMessage += " We are also passing a new year!";
            }

            passingNextWeek = false;
            passingNextMonth = false;
            passingNextYear = false;

            Console.WriteLine(consoleMessage);
            Console.WriteLine("Here is the current date: " + DayNumber + "/" + Month + "/" + Year);
        }
    }
}
