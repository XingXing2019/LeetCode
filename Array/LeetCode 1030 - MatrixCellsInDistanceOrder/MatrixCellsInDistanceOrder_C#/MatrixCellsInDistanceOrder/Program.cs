using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixCellsInDistanceOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int R = 2, C = 3, r0 = 1, c0 = 2;
            Console.WriteLine(AllCellsDistOrder(R, C, r0, c0));
        }
        static int[][] AllCellsDistOrder(int R, int C, int r0, int c0)
        {
            int max = Math.Max(r0 - 0, R - 1 - r0) + Math.Max(c0 - 0, C - 1 - c0);
            List<int[]>[] record = new List<int[]>[max + 1];
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    int distance = Math.Abs(r - r0) + Math.Abs(c - c0);
                    if(record[distance] == null)
                        record[distance] = new List<int[]>{new []{r, c}};
                    else
                        record[distance].Add(new []{r, c});
                }
            }
            int[][] res = new int[R * C][];
            int index = 0;
            for (int i = 0; i < record.Length; i++)
            {
                if(record[i] == null)
                    continue;
                foreach (var pos in record[i])
                    res[index++] = pos;
            }
            return res;
        }
        public int[][] AllCellsDistOrder_Linq(int R, int C, int r0, int c0)
        {
            var res = new int[R * C][];
            var index = 0;
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    res[index++] = new int[] { r, c };
                }
            }
            res = res.OrderBy(x => Math.Abs(x[0] - r0) + Math.Abs(x[1] - c0)).ToArray();
            return res;
        }
    }
}
