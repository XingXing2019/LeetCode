using System;

namespace AverageValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int AverageValue(int[] nums)
        {
            int sum = 0, count = 0;
            foreach (var num in nums)
            {
                if (num % 6 != 0) continue;
                sum += num;
                count++;
            }
            return count == 0 ? 0 : sum / count;
        }
    }
}
