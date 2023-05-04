using System;
using System.Collections.Generic;

namespace TheKnightsTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 3, n = 4, r = 0, c = 0;
            Console.WriteLine(TourOfKnight(m, n, r, c));
        }

        public static int[][] TourOfKnight(int m, int n, int r, int c)
        {
            var res = new int[m][];
            for (int i = 0; i < m; i++)
            {
                res[i] = new int[n];
                Array.Fill(res[i], -1);
            }
            res[r][c] = 0;
            DFS(r, c, m, n, 1, res);
            return res;
        }

        public static bool DFS(int x, int y, int m, int n, int count, int[][] res)
        {
            if (count == m * n)
                return true;
            int[] dx = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] dy = { 1, 2, 2, 1, -1, -2, -2, -1 };
            for (int i = 0; i < 8; i++)
            {
                int newX = x + dx[i], newY = y + dy[i];
                if (newX < 0 || newX >= m || newY < 0 || newY >= n || res[newX][newY] != -1) continue;
                res[newX][newY] = count;
                if (DFS(newX, newY, m, n, count + 1, res))
                    return true;
                res[newX][newY] = -1;
            }
            return false;
        }
    }
}
