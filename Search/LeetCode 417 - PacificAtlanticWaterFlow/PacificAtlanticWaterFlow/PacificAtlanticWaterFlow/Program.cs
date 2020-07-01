using System;
using System.Collections.Generic;

namespace PacificAtlanticWaterFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[3][]
            {
                new int[] {1, 2, 3},
                new int[] {8, 9, 4},
                new int[] {7, 6, 5},
            };
            Console.WriteLine(PacificAtlantic(matrix));

        }
        static IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            var res = new List<IList<int>>();
            if (matrix.Length == 0 || matrix[0].Length == 0) return res;
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[0].Length; c++)
                {
                    var mark = new int[matrix.Length][];
                    for (int i = 0; i < mark.Length; i++)
                        mark[i] = new int[matrix[0].Length];
                    var reach = new HashSet<string>();
                    DFS(matrix, mark, r, c, reach);
                    if (reach.Contains("Pacific") && reach.Contains("Atlantic"))
                        res.Add(new int[] {r, c});
                }
            }
            return res;
        }

        static void DFS(int[][] matrix, int[][] mark, int x, int y, HashSet<string> reach)
        {
            mark[x][y] = 1;
            if (x == 0 || y == 0)
                reach.Add("Pacific");
            if (x == matrix.Length - 1 || y == matrix[0].Length - 1)
                reach.Add("Atlantic");
            if(reach.Contains("Pacific") && reach.Contains("Atlantic")) 
                return;
            int[] dx = {-1, 1, 0, 0};
            int[] dy = {0, 0, -1, 1};
            for (int i = 0; i < 4; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if(newX < 0 || newX >= matrix.Length || newY < 0 || newY >= matrix[0].Length) continue;
                if(matrix[newX][newY] <= matrix[x][y] && mark[newX][newY] == 0) 
                    DFS(matrix, mark, newX, newY, reach);
            }
        }
    }
}
