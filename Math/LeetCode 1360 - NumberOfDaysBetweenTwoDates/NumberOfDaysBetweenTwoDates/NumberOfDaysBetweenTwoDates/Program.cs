using System;

namespace NumberOfDaysBetweenTwoDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string date2 = "2020-01-15", date1 = "2019-12-31";
            Console.WriteLine(DaysBetweenDates(date1, date2));
        }
        static int DaysBetweenDates(string date1, string date2)
        {
            var d1 = DateTime.Parse(date1);
            var d2 = DateTime.Parse(date2);
            var ts = d1.Subtract(d2);
            return Math.Abs((int)ts.TotalDays);
        }
       
    }
}
