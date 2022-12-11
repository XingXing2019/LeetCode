using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSquareStreakInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 10, 2, 13, 16, 8, 9, 13 };
            Console.WriteLine(LongestSquareStreak(nums));
        }

        public static int LongestSquareStreak(int[] nums)
        {
            var unique = new HashSet<long>(nums.OrderBy(x => x).Select(x => (long)x));
            var copy = new HashSet<long>(unique);
            var max = nums.Max();
            var dict = new Dictionary<long, int>();
            foreach (var num in copy)
            {
                if (!unique.Contains(num)) continue;
                var temp = num;
                dict[num] = 0;
                while (temp <= max)
                {
                    if (unique.Contains(temp))
                    {
                        unique.Remove(temp);
                        dict[num]++;
                    }
                    else
                        break;
                    temp *= temp;
                }
            }
            return dict.Values.Where(count => count != 1).Append(-1).Max();
        }
    }
}
