using System;

namespace CollectingChocolates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MinCost(int[] nums, int x)
        {
            long res = long.MaxValue;
            var temp = new long[nums.Length];
            Array.Fill(temp, long.MaxValue);
            for (int i = 0; i < nums.Length; i++)
            {
                long sum = (long)x * i;
                for (int j = 0; j < nums.Length; j++)
                {
                    temp[j] = Math.Min(temp[j], nums[(i + j) % nums.Length]);
                    sum += temp[j];
                }
                res = Math.Min(res, sum);
            }
            return res;
        }
    }
}
