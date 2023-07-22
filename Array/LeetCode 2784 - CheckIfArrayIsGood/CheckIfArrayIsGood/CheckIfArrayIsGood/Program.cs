using System;
using System.Linq;

namespace CheckIfArrayIsGood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 3, 3, 2 };
            Console.WriteLine(IsGood(nums));
        }

        public static bool IsGood(int[] nums)
        {
            var n = nums.Max();
            var dict = nums.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            for (int i = 1; i <= n; i++)
            {
                if (i == n && (!dict.ContainsKey(i) || dict[i] != 2))
                    return false;
                if (i != n && (!dict.ContainsKey(i) || dict[i] != 1))
                    return false;
            }
            return true;
        }
    }
}
