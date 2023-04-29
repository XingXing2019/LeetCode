using System;
using System.Linq;

namespace MaximumSumWithExactlyKElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximizeSum(int[] nums, int k)
        {
            return (2 * nums.Max() + k - 1) * k / 2;
        }
    }
}
