using System;

namespace MinimumCostHomecomingOfARobotInAGrid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] startPos = { 1, 0 }, homePos = { 2, 3 };
            int[] rowCosts = { 5, 4, 3 };
            int[] colCosts = { 8, 2, 6, 7 };
            Console.WriteLine(MinCost(startPos, homePos, rowCosts, colCosts));
        }
        
        public static int MinCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts)
        {
            int res = 0, r = startPos[0], c = startPos[1];
            while (r < homePos[0])
                res += rowCosts[++r];
            while (r > homePos[0])
                res += rowCosts[--r];
            while (c < homePos[1])
                res += colCosts[++c];
            while (c > homePos[1])
                res += colCosts[--c];
            return res;
        }
    }
}
