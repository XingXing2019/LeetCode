//思路与LeetCode 200相同，但在深度优先遍历时需额外记录每个岛屿的area。
//在主方法中每次遍历完一个岛屿就更新res。
using System;
using System.Collections.Generic;
using System.Threading;

namespace MaxAreaOfIsland
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = new int[4][];
            grid[0] = new int[5] { 1, 1, 0, 0, 0 };
            grid[1] = new int[5] { 1, 1, 0, 0, 0 };
            grid[2] = new int[5] { 0, 0, 0, 1, 1 };
            grid[3] = new int[5] { 0, 0, 0, 1, 1 };
            Console.WriteLine(MaxAreaOfIsland(grid));
        }
        static int MaxAreaOfIsland_DFS(int[][] grid)
        {
            int res = 0;
            int area = 0;
            int[][] mark = new int[grid.Length][];
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (mark[i][j] == 0 && grid[i][j] == 1)
                        res = Math.Max(res, DFS(grid, mark, i, j, area));
                }
            }
            return res;
        }
        static int DFS(int[][] grid, int[][] mark, int x, int y, int area)
        {
            area++;
            mark[x][y] = 1;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = dx[i] + x;
                int newY = dy[i] + y;
                if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && grid[newX][newY] == 1)
                   area = Math.Max(area, DFS(grid, mark, newX, newY, area));
            }
            return area;
        }

        static int MaxAreaOfIsland(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0) return 0;
            var mark = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                mark[i] = new int[grid[0].Length];
            var res = 0;
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (mark[x][y] == 0 && grid[x][y] == 1)
                    {
                        var area = 0;
                        GetArea(grid, mark, x, y, ref area);
                        res = Math.Max(res, area);
                    }
                }
            }
            return res;
        }

        static void GetArea(int[][] grid, int[][] mark, int x, int y, ref int area)
        {
            mark[x][y] = 1;
            area++;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = dx[i] + x;
                int newY = dy[i] + y;
                if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                    continue;
                if (grid[newX][newY] == 1 && mark[newX][newY] == 0)
                    GetArea(grid, mark, newX, newY, ref area);
            }
        }
    }
}
