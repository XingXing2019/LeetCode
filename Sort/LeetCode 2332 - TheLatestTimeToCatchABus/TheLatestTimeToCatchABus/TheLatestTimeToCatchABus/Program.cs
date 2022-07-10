using System;
using System.Collections.Generic;
using System.Threading;

namespace TheLatestTimeToCatchABus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] buses = { 18, 8, 3, 12, 9, 2, 7, 13, 20, 5 };
            int[] passengers = { 13, 10, 8, 4, 12, 14, 18, 19, 5, 2, 30, 34 };
            int capacity = 1;
            Console.WriteLine(LatestTimeCatchTheBus(buses, passengers, capacity));
        }

        public static int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity)
        {
            Array.Sort(buses);
            Array.Sort(passengers);
            HashSet<int> used = new HashSet<int>(passengers);
            int p1 = 0, p2 = 0, res = 1;
            while (p1 < buses.Length)
            {
                int end = Math.Min(passengers.Length, p2 + capacity), t = 0;
                while (p2 < end && passengers[p2] <= buses[p1])
                {
                    if (!used.Contains(passengers[p2] - 1)) 
                        res = passengers[p2] - 1;
                    p2++;
                    t++;
                }
                if (t < capacity && !used.Contains(buses[p1])) 
                    res = buses[p1];
                p1++;
            }
            return res;
        }
    }
}
