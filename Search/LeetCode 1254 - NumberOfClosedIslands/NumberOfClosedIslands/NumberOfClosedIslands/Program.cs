using System;

namespace NumberOfClosedIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new int[]{ 0, 0, 1, 0, 0 },
                new int[]{ 0, 1, 0, 1, 0 },
                new int[]{ 0, 1, 1, 1, 0 }
            };
        }
        private bool isClosed;
        public int ClosedIsland(int[][] grid)
        {
            var mark = new int[grid.Length][];
            var res = 0;
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[grid[0].Length];
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (mark[x][y] == 0 && grid[x][y] == 0)
                    {
                        isClosed = true;
                        DFS(grid, mark, x, y);
                        if (isClosed)
                            res++;
                    }
                }
            }
            return res;
        }

        private void DFS(int[][] grid, int[][] mark, int x, int y)
        {
            mark[x][y] = 1;
            if (x == 0 || x == grid.Length - 1 || y == 0 || y == grid[0].Length - 1)
                isClosed = false;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = dx[i] + x;
                int newY = dy[i] + y;
                if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && grid[newX][newY] == 0)
                    DFS(grid, mark, newX, newY);
            }
        }
    }
}
