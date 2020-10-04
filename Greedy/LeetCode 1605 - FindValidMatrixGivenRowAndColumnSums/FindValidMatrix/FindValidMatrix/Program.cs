using System;
using System.Linq;

namespace FindValidMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int[][] RestoreMatrix(int[] rowSum, int[] colSum)
        {
            var res = new int[rowSum.Length][];
            for (int i = 0; i < res.Length; i++)
                res[i] = new int[colSum.Length];
            var count = rowSum.Count(x => x != 0) + colSum.Count(x => x != 0);
            while (count != 0)
            {
                int r = 0, rowMin = int.MaxValue;
                int c = 0, colMin = int.MaxValue;
                for (int i = 0; i < rowSum.Length; i++)
                {
                    if (rowSum[i] == 0 || rowSum[i] >= rowMin) continue;
                    rowMin = rowSum[i];
                    r = i;
                }
                for (int i = 0; i < colSum.Length; i++)
                {
                    if (colSum[i] == 0 || colSum[i] >= colMin) continue;
                    colMin = colSum[i];
                    c = i;
                }
                res[r][c] = Math.Min(rowMin, colMin);
                rowSum[r] -= Math.Min(rowMin, colMin);
                colSum[c] -= Math.Min(rowMin, colMin);
                if (rowSum[r] == 0) count--;
                if (colSum[c] == 0) count--;
            }
            return res;
        }
    }
}
