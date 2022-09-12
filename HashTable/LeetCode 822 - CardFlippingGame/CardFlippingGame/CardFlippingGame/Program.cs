using System;
using System.Collections.Generic;

namespace CardFlippingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int Flipgame(int[] fronts, int[] backs)
        {
            var same = new HashSet<int>();
            var res = int.MaxValue;
            for (int i = 0; i < fronts.Length; i++)
            {
                if (fronts[i] != backs[i]) continue;
                same.Add(fronts[i]);
            }
            for (int i = 0; i < fronts.Length; i++)
            {
                if (!same.Contains(fronts[i]) && !same.Contains(backs[i]))
                    res = Math.Min(res, Math.Min(fronts[i], backs[i]));
                else if (!same.Contains(fronts[i]))
                    res = Math.Min(res, fronts[i]);
                else if (!same.Contains(backs[i]))
                    res = Math.Min(res, backs[i]);
            }
            return res == int.MaxValue ? 0 : res;
        }
    }
}
