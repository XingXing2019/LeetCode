using System;

namespace MaximumNumberOfCoinsYouCanGet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxCoins(int[] piles)
        {
            Array.Sort(piles);
            var res = 0;
            for (int i = piles.Length / 3; i < piles.Length; i+= 2)
                res += piles[i];
            return res;
        }
    }
}
