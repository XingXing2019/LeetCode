using System;
using System.Linq;

namespace MinimumTimeToCompleteTrips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] time = { 1, 2, 3 };
            int totalTrips = 5;
            Console.WriteLine(MinimumTime(time, totalTrips));
        }

        public static long MinimumTime(int[] time, int totalTrips)
        {
            long li = 0, hi = (long) totalTrips * time.Max();
            while (li < hi)
            {
                var mid = li + (hi - li) / 2;
                var trips = time.Sum(t => mid / t);
                if (trips >= totalTrips)
                    hi = mid;
                else
                    li = mid + 1;
            }
            return li;
        }
    }
}
