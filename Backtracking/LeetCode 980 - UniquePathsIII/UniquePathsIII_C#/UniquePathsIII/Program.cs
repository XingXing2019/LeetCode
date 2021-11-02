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
        
        static int UniquePathsIII(int[][] grid)
        {
            int[] start = new int[2], end = new int[2];
            int countZero = 0, path = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[0].Length; c++)
                {
                    if (grid[r][c] == 0)
                        countZero++;
                    else if (grid[r][c] == 1)
                        start = new[] {r, c};
                    else if (grid[r][c] == 2)
                        end = new[] {r, c};
                }
            }
            var mark = new int[grid.Length][];
            for (int r = 0; r < mark.Length; r++)
                mark[r] = new int[grid[0].Length];
            DFS(start, grid, mark, countZero, end, ref path);
            return path;
        }

        static void DFS(int[] cur, int[][] grid, int[][] mark, int countZero, int[] end, ref int path)
        {
            mark[cur[0]][cur[1]] = 1;
            if (countZero == -1 && cur[0] == end[0] && cur[1] == end[1])
                path++;
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            for (int i = 0; i < 4; i++)
            {
                int newX = cur[0] + dx[i];
                int newY = cur[1] + dy[i];
                if(newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && grid[newX][newY] != -1)
                {
                    DFS(new []{newX, newY}, grid, mark, countZero - 1, end, ref path);
                    mark[newX][newY] = 0;
                }
            }
        }
    }
}
