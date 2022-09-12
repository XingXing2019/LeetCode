using System;

namespace PourWater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] heights = { 4, 4, 4, 4, 3, 2, 1, 2, 3, 4, 3, 2, 1 };
            int volumn = 1, k = 2;
            Console.WriteLine(PourWater(heights, volumn, k));
        }
        public static int[] PourWater(int[] heights, int volume, int k)
        {
            for (int i = 0; i < volume; i++)
                heights = DropWater(heights, k);
            return heights;
        }

        public static int[] DropWater(int[] heights, int k)
        {
            int p1 = k - 1, p2 = k + 1;
            int min = heights[k], index = k;
            while (p1 >= 0 && heights[p1] <= heights[p1 + 1])
            {
                if (heights[p1] < min)
                {
                    min = heights[p1];
                    index = p1;
                }
                p1--;
            }
            if (index != k)
            {
                heights[index]++;
                return heights;
            }
            min = heights[k];
            index = k;
            while (p2 < heights.Length && heights[p2] <= heights[p2 - 1])
            {
                if (heights[p2] < min)
                {
                    min = heights[p2];
                    index = p2;
                }
                p2++;
            }
            if (index != k)
            {
                heights[index]++;
                return heights;
            }
            heights[k]++;
            return heights;
        }
    }
}
