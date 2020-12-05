using System;
using System.Collections.Generic;

namespace PacificAtlanticWaterFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[][]
            {
                new int[] {1, 1},
                new int[] {1, 1},
                new int[] {1, 1},
            };
            Console.WriteLine(PacificAtlantic_BFS(matrix));

        }
        
        static IList<IList<int>> PacificAtlantic_BFS(int[][] matrix)
        {
            var res = new List<IList<int>>();
            if (matrix.Length == 0 || matrix[0].Length == 0) return res;
            var reachPacific = new bool[matrix.Length, matrix[0].Length];
            var reachAtlantic = new bool[matrix.Length, matrix[0].Length];
            int[] direction = { 0, 1, 0, -1, 0 };
            for (int i = 0; i < matrix[0].Length; i++)
            {
                reachPacific[0, i] = true;
                reachAtlantic[matrix.Length - 1, i] = true;
                BFS(matrix, 0, i, direction, reachPacific);
                BFS(matrix, matrix.Length - 1, i, direction, reachAtlantic);
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                reachPacific[i, 0] = true;
                reachAtlantic[i, matrix[0].Length - 1] = true;
                BFS(matrix, i, 0, direction, reachPacific);
                BFS(matrix, i, matrix[0].Length - 1, direction, reachAtlantic);
            }
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    if (reachPacific[x, y] && reachAtlantic[x, y])
                        res.Add(new List<int> { x, y });
                }
            }
            return res;
        }

        static void BFS(int[][] matrix, int x, int y, int[] direction, bool[,] visit)
        {
            var queue = new Queue<int[]>();
            queue.Enqueue(new[] { x, y });
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                for (int i = 0; i < 4; i++)
                {
                    int newX = direction[i] + cur[0], newY = direction[i + 1] + cur[1];
                    if (newX < 0 || newX >= matrix.Length || newY < 0 || newY >= matrix[0].Length)
                        continue;
                    if (matrix[newX][newY] >= matrix[cur[0]][cur[1]] && !visit[newX, newY])
                    {
                        visit[newX, newY] = true;
                        queue.Enqueue(new[] { newX, newY });
                    }
                }
            }
        }


        static IList<IList<int>> PacificAtlantic_DFS(int[][] matrix)
        {
            var res = new List<IList<int>>();
            if (matrix.Length == 0 || matrix[0].Length == 0) return res;
            var reachPacific = new bool[matrix.Length, matrix[0].Length];
            var reachAtlantic = new bool[matrix.Length, matrix[0].Length];
            int[] direction = { 0, 1, 0, -1, 0 };
            for (int i = 0; i < matrix[0].Length; i++)
            {
                reachPacific[0, i] = true;
                reachAtlantic[matrix.Length - 1, i] = true;
                DFS(matrix, 0, i, direction, reachPacific);
                DFS(matrix, matrix.Length - 1, i, direction, reachAtlantic);
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                reachPacific[i, 0] = true;
                reachAtlantic[i, matrix[0].Length - 1] = true;
                DFS(matrix, i, 0, direction, reachPacific);
                DFS(matrix, i, matrix[0].Length - 1, direction, reachAtlantic);
            }
            for (int x = 0; x < matrix.Length; x++)
            {
                for (int y = 0; y < matrix[0].Length; y++)
                {
                    if (reachPacific[x, y] && reachAtlantic[x, y])
                        res.Add(new List<int> { x, y });
                }
            }
            return res;
        }
        static void DFS(int[][] matrix, int x, int y, int[] direction, bool[,] visit)
        {
            for (int i = 0; i < 4; i++)
            {
                int newX = direction[i] + x, newY = direction[i + 1] + y;
                if (newX < 0 || newX >= matrix.Length || newY < 0 || newY >= matrix[0].Length)
                    continue;
                if (matrix[newX][newY] >= matrix[x][y] && !visit[newX, newY])
                {
                    visit[newX, newY] = true;
                    DFS(matrix, newX, newY, direction, visit);
                }
            }
        }
    }
}
