using System;
using System.Collections.Generic;

namespace LargestPlusSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = 5;
            int[][] mines = new int[][]
            {
                new[] { 4, 2 },
            };
            Console.WriteLine(OrderOfLargestPlusSign(n, mines));
        }

        public static int OrderOfLargestPlusSign(int n, int[][] mines)
        {
            int[][] left = new int[n][], right = new int[n][];
            int[][] up = new int[n][], down = new int[n][];
            for (int i = 0; i < n; i++)
            {
                left[i] = new int[n];
                right[i] = new int[n];
                up[i] = new int[n];
                down[i] = new int[n];
                Array.Fill(left[i], 1);
                Array.Fill(right[i], 1);
                Array.Fill(up[i], 1);
                Array.Fill(down[i], 1);
            }
            var zeros = new HashSet<int>();
            foreach (var mine in mines)
                zeros.Add(mine[0] * 5000 + mine[1]);
            for (int i = 0; i < n; i++)
            {
                int l = 0, r = 0;
                for (int j = 0; j < n; j++)
                {
                    l = zeros.Contains(i * 5000 + j) ? 0 : l + 1;
                    left[i][j] = l;
                    r = zeros.Contains(i * 5000 + (n - j - 1)) ? 0 : r + 1;
                    right[i][^(j + 1)] = r;
                }
            }
            for (int j = 0; j < n; j++)
            {
                int u = 0, d = 0;
                for (int i = 0; i < n; i++)
                {
                    u = zeros.Contains(i * 5000 + j) ? 0 : u + 1;
                    up[i][j] = u;
                    d = zeros.Contains((n - i - 1) * 5000 + j) ? 0 : d + 1;
                    down[^(i + 1)][j] = d;
                }
            }
            var res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res = Math.Max(res, Math.Min(left[i][j], Math.Min(right[i][j], Math.Min(up[i][j], down[i][j]))));
                }
            }
            return res;
        }
    }
}
