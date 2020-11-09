//创建DFS方法深度优先搜索。传入参数为与grid大小相同的mark数组，grid数组，x和y坐标。
//向将mark中x，y坐标点标记为1，证明已经搜索过该点。创建方向数组dx和dy辅助搜索上下左右四个位置。
//利用方向数组dx和dy获取到新坐标，如果新坐标越界，则跳过该次搜索。如果新坐标在mark中未被标记。并且在grid中为1，证明该坐标为未被搜索过的陆地。则调用DFS方法，并将新坐标传入。
//在主方法中，遍历grid中每个坐标。如果该坐标在mark中未被标记，并且在grid中为1。则调用DFS搜索岛屿，搜索结束后count加一。
//由于在搜索过程中会在mark中标记已经搜索过的陆地，则可以保证每次调用DFS只会搜索新的岛屿。
using System;
using System.Collections.Generic;

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int NumIslands_DFS(char[][] grid)
        {
            int count = 0;
            int[][] mark = new int[grid.Length][];
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[grid[0].Length];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (mark[i][j] == 0 && grid[i][j] == '1')
                    {
                        DFS(mark, grid, i, j);
                        count++;
                    }      
                }
            }
            return count;
        }
        static void DFS (int[][] mark, char[][] grid, int x, int y)
        {
            mark[x][y] = 1;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if (newX < 0 || newX >= mark.Length || newY < 0 || newY >= mark[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && grid[newX][newY] == '1')
                    DFS(mark, grid, newX, newY);
            }
        }

        static int NumIslands_BFS(char[][] grid)
        {
            var visited = new int[grid.Length][];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = new int[grid[0].Length];
            var res = 0;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int x = 0; x < grid.Length; x++)
            {
                for (int y = 0; y < grid[0].Length; y++)
                {
                    if (visited[x][y] == 1 || grid[x][y] == '0')
                        continue;
                    var queue = new Queue<int[]>();
                    queue.Enqueue(new[] { x, y });
                    while (queue.Count != 0)
                    {
                        var cur = queue.Dequeue();
                        for (int i = 0; i < 4; i++)
                        {
                            int newX = dx[i] + cur[0];
                            int newY = dy[i] + cur[1];
                            if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length)
                                continue;
                            if (visited[newX][newY] == 0 && grid[newX][newY] == '1')
                            {
                                queue.Enqueue(new[] { newX, newY });
                                visited[newX][newY] = 1;
                            }
                        }
                    }
                    res++;
                }
            }
            return res;
        }
    }
}
