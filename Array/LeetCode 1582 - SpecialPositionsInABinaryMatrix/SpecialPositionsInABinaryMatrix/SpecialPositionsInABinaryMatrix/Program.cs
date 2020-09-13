using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialPositionsInABinaryMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = new int[][]
            {
                new[] {1, 0, 0},
                new[] {0, 0, 1},
                new[] {1, 0, 0},
            };
            Console.WriteLine(NumSpecial(mat));
        }
        static int NumSpecial(int[][] mat)
        {
            var res = 0;
            var records = new List<int[]>();
            for (int c = 0; c < mat[0].Length; c++)
            {
                var temp = new List<int[]>();
                for (int r = 0; r < mat.Length; r++)
                {
                    if (mat[r][c] == 1)
                        temp.Add(new[] {r, c});
                }
                if(temp.Count == 1)
                    records.Add(temp[0]);
            }
            foreach (var record in records)
            {
                if (mat[record[0]].Count(x => x == 1) == 1)
                    res++;
            }
            return res;
        } 
    }
}
