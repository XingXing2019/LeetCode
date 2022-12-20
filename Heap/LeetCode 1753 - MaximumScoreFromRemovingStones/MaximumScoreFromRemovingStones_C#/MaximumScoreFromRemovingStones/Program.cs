using System;

namespace MaximumScoreFromRemovingStones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaximumScore(int a, int b, int c)
        {
            int[] piles = {a, b, c};
            Array.Sort(piles);
            int res = 0;
            while (piles[^1] != 0 && piles[^2] != 0)
            {
                res++;
                piles[^1]--;
                piles[^2]--;
                Array.Sort(piles);
            }
            return res;
        }
    }
}
