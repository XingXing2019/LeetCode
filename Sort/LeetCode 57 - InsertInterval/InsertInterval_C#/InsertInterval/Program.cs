using System;
using System.Collections.Generic;

namespace InsertInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[][]
            {
                new[] {1, 5},
            };
            int[] newInterval = {2, 3};
            Console.WriteLine(Insert(intervals, newInterval));
        }
        static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var res = new List<int[]>();
            var isInserted = false;
            foreach (var interval in intervals)
            {
                if(interval[0] >= newInterval[0] && interval[1] <= newInterval[1]) continue;
                if(interval[1] < newInterval[0])
                    res.Add(interval);
                if (interval[0] > newInterval[1])
                {
                    if (!isInserted)
                    {
                        res.Add(newInterval);
                        isInserted = true;
                    }
                    res.Add(interval);
                }
                if (interval[1] <= newInterval[1] && interval[1] >= newInterval[0])
                    newInterval[0] = interval[0];
                else if (interval[0] <= newInterval[1] && interval[0] >= newInterval[0])
                    newInterval[1] = interval[1];
                else if (interval[0] <= newInterval[0] && interval[1] >= newInterval[1])
                    newInterval = interval;
            }
            if(!isInserted)
                res.Add(newInterval);
            return res.ToArray();
        }
    }
}
