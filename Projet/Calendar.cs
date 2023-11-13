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

        public Calendar(int Year, EMonths Month, int DayNumber, EDays Day)
        {
            this.Year = Year;
            this.Month = Month;
            this.DayNumber = DayNumber;
            this.Day = Day;
        }

        public delegate void NewDay();
        public event NewDay OnNewDay;

        public delegate void NewWeek();
        public event NewWeek OnNewWeek;

        public delegate void NewMonth();
        public event NewMonth OnNewMonth;

        public delegate void NewYear();
        public event NewYear OnNewYear;
    }
}
