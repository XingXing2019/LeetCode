using System;
using System.Linq;

namespace DivideIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] intervals = new int[][]
            {
                new int[] { 1, 1 }
            };
            Console.WriteLine(MinGroups(intervals));
        }

        public static int MinGroups(int[][] intervals)
        {
            var max = intervals.Max(x => x[1]);
            var freq = new int[max + 2];
            foreach (var interval in intervals)
            {
                freq[interval[0]]++;
                freq[interval[1] + 1]--;
            }
            int sum = 0, res = 0;
            for (int i = 0; i < freq.Length; i++)
            {
                sum += freq[i];
                res = Math.Max(res, sum);
            }
            return res;
        }
    }
}
