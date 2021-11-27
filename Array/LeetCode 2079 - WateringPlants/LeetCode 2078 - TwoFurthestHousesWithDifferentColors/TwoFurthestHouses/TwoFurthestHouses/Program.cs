using System;

namespace TwoFurthestHouses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int MaxDistance(int[] colors)
        {
            int res = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                int li = 0, hi = colors.Length - 1;
                while (li < i && colors[li] == colors[i] && i - li > res)
                    li++;
                while (i < hi && colors[hi] == colors[i] && hi - i > res)
                    hi--;
                res = Math.Max(res, Math.Max(i - li, hi - i));
            }
            return res;
        }
    }
}
