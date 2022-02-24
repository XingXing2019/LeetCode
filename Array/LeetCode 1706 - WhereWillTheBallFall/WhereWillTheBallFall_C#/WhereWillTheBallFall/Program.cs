using System;

namespace WhereWillTheBallFall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new[] { 1, 1, 1, -1, -1 },
                new[] { 1, 1, 1, -1, -1 },
                new[] { -1, -1, -1, 1, 1 },
                new[] { 1, 1, 1, 1, -1 },
                new[] { -1, -1, -1, -1, -1 }
            };
            Console.WriteLine(FindBall(grid));
        }

        public static int[] FindBall(int[][] grid)
        {
            var res = new int[grid[0].Length];
            for (int i = 0; i < grid[0].Length; i++)
            {
                var cur = i;
                foreach (var row in grid)
                {
                    if (row[cur] == 1 && (cur == grid[0].Length - 1 || row[cur + 1] == -1) || 
                        row[cur] == -1 && (cur == 0 || row[cur - 1] == 1))
                    {
                        res[i] = -1;
                        break;
                    }
                    cur += row[cur];
                }
                if (res[i] != -1) res[i] = cur;
            }
            return res;
        }
    }
}
