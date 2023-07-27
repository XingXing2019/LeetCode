using System;
using System.Linq;

namespace MaximumRunningTimeOfNComputers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            int[] batteries = { 3, 3, 3 };
            Console.WriteLine(MaxRunTime(n, batteries));
        }

        public static long MaxRunTime(int n, int[] batteries)
        {
            long li = 0, hi = (long)batteries.Max() * batteries.Length;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if (CanRun(batteries, n, mid))
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }

        public static bool CanRun(int[] batteries, int n, long minutes)
        {
            long power = 0;
            foreach (var battery in batteries)
                power += Math.Min(minutes, battery);
            return power >= n * minutes;
        }
    }
}
