using System;

namespace MaximumProductOfTwoElementsInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxProduct(int[] nums)
        {
            int max = 0, secondMax = 0;
            foreach (var num in nums)
            {
                if (num > max)
                {
                    secondMax = max;
                    max = num;
                }
                else if (num > secondMax)
                    secondMax = num;
            }
            return (max - 1) * (secondMax - 1);
        }
    }
}
