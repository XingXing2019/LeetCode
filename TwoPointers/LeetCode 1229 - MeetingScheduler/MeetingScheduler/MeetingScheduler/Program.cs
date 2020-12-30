using System;
using System.Collections.Generic;
using System.Linq;

namespace MeetingScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var slots1 = new int[][]
            {
                new[] {10, 50},
                new[] {60, 120},
                new[] {140, 210},
            };
            var slots2 = new int[][]
            {
                new[] {0, 15},
                new[] {60, 70},
            };
            int duration = 8;
            Console.WriteLine(MinAvailableDuration(slots1, slots2, duration));
        }
        static IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
        {
            slots1 = slots1.OrderBy(x => x[0]).ToArray();
            slots2 = slots2.OrderBy(x => x[0]).ToArray();
            int p1 = 0, p2 = 0;
            while (p1 < slots1.Length && p2 < slots2.Length)
            {
                int start1 = slots1[p1][0], end1 = slots1[p1][1];
                int start2 = slots2[p2][0], end2 = slots2[p2][1];
                if (start2 <= start1 && start1 <= end2 || start1 <= start2 && start2 <= end1)
                {
                    if (Math.Max(start1, start2) + duration <= Math.Min(end1, end2))
                        return new List<int> { Math.Max(start1, start2), Math.Max(start1, start2) + +duration };
                }
                if (end1 < end2)
                    p1++;
                else
                    p2++;
            }
            return new List<int>();
        }
    }
}
