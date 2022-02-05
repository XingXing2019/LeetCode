using System;

namespace PathWithMaximumGold
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[][]
            {
                new int[]{0, 6, 0}, 
                new int[]{5, 8, 7}, 
            };
        }

        private int maxGold;
        public int GetMaximumGold(int[][] grid)
        {
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if(grid[x][y] == 0) continue;
                    var mark = new int[grid.Length][];
                    for (int i = 0; i < mark.Length; i++)
                        mark[i] = new int[grid[0].Length];
                    DFS(grid, mark, x, y, grid[x][y]);
                }
            }
            return maxGold;
        }

        private void DFS(int[][] grid, int[][] mark, int x, int y, int gold)
        {
            mark[x][y] = 1;
            maxGold = Math.Max(maxGold, gold);
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if(newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if (grid[newX][newY] != 0 && mark[newX][newY] == 0)
                {
                    DFS(grid, mark, newX, newY, gold + grid[newX][newY]);
                    mark[newX][newY] = 0;
                }
            }
        }
    }
}
