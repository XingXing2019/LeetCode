using System;
using System.Collections.Generic;

namespace BuildingsWithAnOceanView
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int[] FindBuildings(int[] heights)
        {
            var rightMax = new int[heights.Length];
            var res = new List<int>();
            for (int i = heights.Length - 2; i >= 0; i--)
                rightMax[i] = Math.Max(heights[i + 1], rightMax[i + 1]);
            for (int i = 0; i < heights.Length; i++)
            {
                if(heights[i] > rightMax[i])
                    res.Add(i);
            }
            return res.ToArray();
        }
    }
}
