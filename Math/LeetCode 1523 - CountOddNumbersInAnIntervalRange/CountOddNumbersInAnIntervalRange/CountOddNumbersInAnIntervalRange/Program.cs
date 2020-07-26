using System;

namespace CountOddNumbersInAnIntervalRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountOdds(int low, int high)
        {
            if (low == high)
                return low % 2 == 0 ? 0 : 1;
            var res = low % 2 != 0 ? (high - low - 1) / 2 : (high - low) / 2;
            if (low % 2 != 0) 
                res++;
            if (high % 2 != 0) 
                res++;
            return res;
        }
    }
}
