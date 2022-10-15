using System;

namespace NumberOfValidClockTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountTime(string time)
        {
            var res = 1;
            if (time[0] == '?')
                res *= time[1] == '?' ? 24 : time[1] - '0' < 4 ? 3 : 2;
            else if (time[1] == '?')
                res *= time[0] == '?' || time[0] - '0' < 2 ? 10 : 4;
            if (time[3] == '?')
                res *= 6;
            if (time[4] == '?')
                res *= 10;
            return res;
        }
    }
}
