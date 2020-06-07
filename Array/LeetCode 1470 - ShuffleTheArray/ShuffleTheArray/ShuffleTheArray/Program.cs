
using System;

namespace ShuffleTheArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] Shuffle(int[] nums, int n)
        {
            var res = new int[2 * n];
            int point = 0;
            for (int i = 0; i < n; i++)
            {
                res[point++] = nums[i];
                res[point++] = nums[i + n];
            }
            return res;
        }
    }
}
