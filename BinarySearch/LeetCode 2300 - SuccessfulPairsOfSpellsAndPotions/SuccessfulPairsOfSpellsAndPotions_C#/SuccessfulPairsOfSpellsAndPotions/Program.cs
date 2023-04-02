using System;

namespace SuccessfulPairsOfSpellsAndPotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            Array.Sort(potions);
            var res = new int[spells.Length];
            for (int i = 0; i < res.Length; i++)
                res[i] = potions.Length - BinarySearch(potions, spells[i], success) - 1;
            return res;
        }

        public int BinarySearch(int[] potions, int num, long success)
        {
            int li = 0, hi = potions.Length - 1;
            while (li <= hi)
            {
                var mid = li + (hi - li) / 2;
                if ((long)num * potions[mid] < success)
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return hi;
        }
    }
}
