using System;
using System.Collections.Generic;

namespace NumberOfDaysInAMonth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NumberOfDays(int Y, int M)
        {
            var isLoopYear = (Y % 4 == 0 && Y % 100 != 0) || Y % 400 == 0;
            if (M == 2)
                return isLoopYear ? 29 : 28;
            var thirtyOneDays = new List<int> {1, 3, 5, 7, 8, 10, 12};
            return thirtyOneDays.Contains(M) ? 31 : 30;
        }
    }
}
