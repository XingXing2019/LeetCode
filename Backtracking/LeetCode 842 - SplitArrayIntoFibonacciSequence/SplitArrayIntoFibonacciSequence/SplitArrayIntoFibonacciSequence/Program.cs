using System;
using System.Collections.Generic;

namespace SplitArrayIntoFibonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = "1101111";
            Console.WriteLine(SplitIntoFibonacci(num));
        }

        private static List<int> res;
        public static IList<int> SplitIntoFibonacci(string num)
        {
            res = new List<int>();
            DFS(num, 0, new List<int>());
            return res;
        }

        public static bool DFS(string num, int start, List<int> nums)
        {
            if (nums.Count > 2 && nums[^1] != nums[^2] + nums[^3])
                return false;
            if (nums.Count > 2 && start == num.Length)
            {
                res = new List<int>(nums);
                return true;
            }
            for (int i = 1; i <= num.Length - start; i++)
            {
                var part = num.Substring(start, i);
                if ((part.Length > 1 && part[0] == '0') || !int.TryParse(part, out var temp))
                    continue;
                nums.Add(temp);
                if (DFS(num, start + i, nums)) return true;
                nums.RemoveAt(nums.Count - 1);
            }
            return false;
        }
    }
}
