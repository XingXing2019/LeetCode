using System;
using System.Collections.Generic;

namespace ElementsInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 0, 1, 2 };
            int[][] queries =
            {
                new[] { 0, 2 },
                new[] { 2, 0 },
                new[] { 3, 2 },
                new[] { 5, 0 }
            };
            Console.WriteLine(ElementInNums(nums, queries));
        }

        public static int[] ElementInNums(int[] nums, int[][] queries)
        {
            var record = new List<int>[nums.Length * 2];
            record[0] = new List<int>(nums);
            var point = 0;
            for (int i = 1; i < record.Length; i++)
            {
                record[i] = new List<int>(record[i - 1]);
                if (i <= nums.Length)
                    record[i].RemoveAt(0);
                else
                    record[i].Add(nums[point++]);
            }
            var res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int time = queries[i][0] % record.Length, index = queries[i][1];
                res[i] = index < record[time].Count ? record[time][index] : -1;
            }
            return res;
        }
    }
}
