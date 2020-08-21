using System;
using System.Collections.Generic;

namespace RemoveInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
        {
            int low = Math.Min(toBeRemoved[0], toBeRemoved[1]);
            int high = Math.Max(toBeRemoved[0], toBeRemoved[1]);
            var res = new List<IList<int>>();
            foreach (var interval in intervals)
            {
                if (interval[0] >= high || interval[1] <= low)
                {
                    res.Add(interval);
                    continue;
                }
                if (interval[0] < low)
                {
                    if(interval[1] < high)
                        res.Add(new int[]{interval[0], low});
                    else
                    {
                        res.Add(new int[]{interval[0], low});
                        res.Add(new int[] {high, interval[1]});
                    }
                }
                else if (interval[1] >= high)
                    res.Add(new int[] {high, interval[1]});
            }
            return res;
        }
    }
}
