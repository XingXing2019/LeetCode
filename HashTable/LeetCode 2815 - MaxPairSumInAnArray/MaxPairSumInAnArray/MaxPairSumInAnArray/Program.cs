using System;
using System.Linq;

namespace MaxPairSumInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxSum(int[] nums)
        {
            var dict = nums.GroupBy(GetMax).ToDictionary(x => x.Key, x => x.OrderByDescending(y => y).ToList());
            var res = -1;
            foreach (var key in dict.Keys)
            {
                if (dict[key].Count < 2) continue;
                res = Math.Max(res, dict[key][0] + dict[key][1]);
            }
            return res;
        }

        public int GetMax(int num)
        {
            var res = 0;
            while (num != 0)
            {
                res = Math.Max(res, num % 10);
                num /= 10;
            }
            return res;
        }
    }
}
