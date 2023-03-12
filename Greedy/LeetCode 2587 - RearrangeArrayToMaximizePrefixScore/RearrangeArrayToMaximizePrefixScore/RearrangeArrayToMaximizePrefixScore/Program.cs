using System;

namespace RearrangeArrayToMaximizePrefixScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaxScore(int[] nums)
        {
            Array.Sort(nums, (a, b) => b - a);
            long prefix = 0;
            int res = 0;
            foreach (var num in nums)
            {
                prefix += num;
                if (prefix <= 0)
                    return res;
                res++;
            }
            return res;
        }
    }
}
