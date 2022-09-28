using System;
using System.Linq;

namespace MinimumAbsoluteDifferenceQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 4, 8 };
            int[][] queries = new int[][]
            {
                new[] { 0, 1 },
                new[] { 1, 2 },
                new[] { 2, 3 },
                new[] { 0, 3 },
            };
            Console.WriteLine(MinDifference(nums, queries));
        }

        public static int[] MinDifference(int[] nums, int[][] queries)
        {
            var record = new int[nums.Length][];
            var res = new int[queries.Length];
            var max = nums.Max();
            for (int i = 0; i < nums.Length; i++)
            {
                record[i] = new int[max + 1];
                if (i != 0)
                    Array.Copy(record[i - 1], record[i], record[i].Length);
                record[i][nums[i]]++;
            }
            for (int i = 0; i < queries.Length; i++)
            {
                var start = queries[i][0] == 0 ? new int[max + 1] : record[queries[i][0] - 1];
                var end = record[queries[i][1]];
                int temp = int.MaxValue, num = -1;
                for (int j = 0; j < start.Length; j++)
                {
                    if (end[j] - start[j] == 0) continue;
                    if (num != -1)
                        temp = Math.Min(temp, j - num);
                    num = j;
                }
                res[i] = temp == int.MaxValue ? -1 : temp;
            }
            return res;
        }
    }
}
