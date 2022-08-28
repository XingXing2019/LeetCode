using System;

namespace LongestSubsequenceWithLimitedSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            for (int i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];
            var res = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                var index = Array.BinarySearch(nums, queries[i]);
                res[i] = index >= 0 ? index + 1 : ~index;
            }
            return res;
        }
    }
}
