using System;

namespace UniquePathsIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[3][]
            {
                new int[]{1,0,0,0}, 
                new int[]{0,0,0,0}, 
                new int[]{0,0,0,2} 
            };
            Console.WriteLine(UniquePathsIII(grid));
        }

        static int path;
        static int UniquePathsIII(int[][] grid)
        {
            int startX = 0, startY = 0;
            int endX = 0, endY = 0;
            int countZero = 0;
            int row = grid.Length, col = grid[0].Length;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (grid[r][c] == 0)
                        countZero++;
                    else if (grid[r][c] == 1)
                    {
                        startX = r;
                        startY = c;
                    }
                    else if (grid[r][c] == 2)
                    {
                        endX = r;
                        endY = c;
                    }
                }
            }

            var mark = new int[row][];
            for (int r = 0; r < row; r++)
                mark[r] = new int[col];
            DFS(startX, startY, grid, mark, countZero, endX, endY);
            return path;
        }

        static void DFS(int x, int y, int[][] grid, int[][] mark, int countZero, int endX, int endY)
        {
            mark[x][y] = 1;
            if (countZero == -1 && x == endX && y == endY)
                path++;
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if(newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && grid[newX][newY] != -1)
                {
                    DFS(newX, newY, grid, mark, countZero - 1, endX, endY);
                    mark[newX][newY] = 0;
                }
            }
        }
    }
}
