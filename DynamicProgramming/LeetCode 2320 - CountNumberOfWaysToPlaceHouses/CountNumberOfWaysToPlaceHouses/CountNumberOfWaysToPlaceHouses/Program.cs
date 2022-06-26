using System;

namespace CountNumberOfWaysToPlaceHouses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int CountHousePlacements(int n)
        {
            long f0 = 1, f1 = 2, mod = 1_000_000_000 + 7;
            for (int i = 0; i < n; i++)
            {
                var temp = (f0 + f1) % mod;
                f0 = f1;
                f1 = temp;
            }
            return (int)(f0 * f0 % mod);
        }
    }
}
