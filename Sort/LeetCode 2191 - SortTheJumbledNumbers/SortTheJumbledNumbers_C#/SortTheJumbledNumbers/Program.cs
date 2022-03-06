using System;
using System.Linq;

namespace SortTheJumbledNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mapping = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            int[] nums = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(SortJumbled(mapping, nums));
        }
        public static int[] SortJumbled(int[] mapping, int[] nums)
        {
            return nums.OrderBy(x => Decode(mapping, x)).ToArray();
        }

        public static int Decode(int[] mapping, int num)
        {
            if (num == 0) return mapping[0];
            int res = 0, pow = 1;
            while (num != 0)
            {
                var digit = num % 10;
                num /= 10;
                res += pow * mapping[digit];
                pow *= 10;
            }
            return res;
        }
    }
}
