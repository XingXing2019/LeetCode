using System;

namespace CountEqualAndDivisiblePairsInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountPairs(int[] nums, int k)
        {
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] != nums[j] || i * j % k != 0) continue;
                    res++;
                }
            }
            return res;
        }
    }
}
