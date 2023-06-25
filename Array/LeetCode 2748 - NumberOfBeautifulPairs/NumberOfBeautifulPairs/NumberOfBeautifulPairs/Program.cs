using System;

namespace NumberOfBeautifulPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountBeautifulPairs(int[] nums)
        {
            var res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var d1 = nums[i].ToString()[0] - '0';
                    var d2 = nums[j].ToString()[^1] - '0';
                    if (GCD(d1, d2) == 1)
                        res++;
                }
            }
            return res;
        }

        public int GCD(int x, int y)
        {
            if (y == 0)
                return x;
            return GCD(y, x % y);
        }
    }
}
