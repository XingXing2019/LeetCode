using System;
using System.Linq;

namespace MinimizeRoundingErrorToMeetTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] prices = { "0.700", "2.800", "4.900" };
            int target = 8;
            Console.WriteLine(MinimizeError(prices, target));
        }

        public static string MinimizeError(string[] prices, int target)
        {
            var nums = new double[prices.Length];
            var floor = new double[prices.Length];
            double min = 0, max = 0, res = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                nums[i] = double.Parse(prices[i]);
                min += Math.Floor(nums[i]);
                max += Math.Ceiling(nums[i]);
            }
            if (target < min || target > max)
                return "-1";
            nums = nums.OrderBy(x => Math.Ceiling(x) - x).ToArray();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                floor[i] = Math.Floor(nums[i]);
                if (i == nums.Length - 1) continue;
                floor[i] += floor[i + 1];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (target > floor[i])
                {
                    target -= (int)Math.Ceiling(nums[i]);
                    res += Math.Ceiling(nums[i]) - nums[i];
                }
                else
                {
                    target -= (int)Math.Floor(nums[i]);
                    res += nums[i] - Math.Floor(nums[i]);
                }
            }
            return res.ToString("0.000");
        }
    }
}
