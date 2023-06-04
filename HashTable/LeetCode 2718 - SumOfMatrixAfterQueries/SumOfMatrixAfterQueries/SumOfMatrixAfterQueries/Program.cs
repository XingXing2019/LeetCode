using System;
using System.Collections.Generic;

namespace SumOfMatrixAfterQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MatrixSumQueries(int n, int[][] queries)
        {
            var rows = new HashSet<int>();
            var cols = new HashSet<int>();
            long res = 0;
            for (int i = queries.Length - 1; i >= 0; i--)
            {
                int type = queries[i][0], index = queries[i][1], val = queries[i][2];
                if (type == 0)
                {
                    if (!rows.Add(index)) continue;
                    res += (long)val * (n - cols.Count);
                }
                else
                {
                    if (!cols.Add(index)) continue;
                    res += (long)val * (n - rows.Count);
                }
            }
            return res;
        }
    }
}
