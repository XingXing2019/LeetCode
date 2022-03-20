using System;
using System.Collections.Generic;
using System.Resources;
using Microsoft.VisualBasic;

namespace MaximumPointsInAnArcheryCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numArrows = 3;
            int[] aliceArrows = { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2 };
            Console.WriteLine(MaximumBobPoints(numArrows, aliceArrows));
        }
        
        public static int[] MaximumBobPoints(int numArrows, int[] aliceArrows)
        {
            int max = 0;
            var res = new List<int>();
            DFS(numArrows, 0, aliceArrows, new int[aliceArrows.Length], 0, ref res, ref max);
            return res.ToArray();
        }

        public static void DFS(int numArrows, int index, int[] aliceArrows, int[] bobArrows, int score, ref List<int> res, ref int max)
        {
            if (index == aliceArrows.Length)
            {
                if (score <= max) return;
                bobArrows[^1] += numArrows;
                max = score;
                res = new List<int>(bobArrows);
                return;
            }
            DFS(numArrows, index + 1, aliceArrows, bobArrows, score, ref res, ref max);
            if (numArrows > aliceArrows[index])
            {
                bobArrows[index] = aliceArrows[index] + 1;
                DFS(numArrows - bobArrows[index], index + 1, aliceArrows, bobArrows, score + index, ref res, ref max);
            }
            bobArrows[index] = 0;
        }
    }
}
