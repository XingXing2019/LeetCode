using System;

namespace DetermineIfTwoEventsHaveConflict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool HaveConflict(string[] event1, string[] event2)
        {
            int start1 = CalcTime(event1[0]), end1 = CalcTime(event1[1]);
            int start2 = CalcTime(event2[0]), end2 = CalcTime(event2[1]);
            return end1 >= start2 && start1 <= end2 && end2 >= start1 && start2 <= end2;
        }

        public int CalcTime(string time)
        {
            int hour = int.Parse(time.Substring(0, 2)), min = int.Parse(time.Substring(3));
            return hour * 60 + min;
        }
    }
}
