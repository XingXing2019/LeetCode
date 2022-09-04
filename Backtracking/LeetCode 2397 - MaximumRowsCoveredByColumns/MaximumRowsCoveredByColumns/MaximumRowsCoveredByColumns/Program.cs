using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumRowsCoveredByColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MaximumRows(int[][] mat, int cols)
        {
            int res = 0;
            DFS(mat, 0, cols, new HashSet<int>(), ref res);
            return res;
        }

        public void DFS(int[][] mat, int start, int cols, HashSet<int> visited, ref int res)
        {
            if (visited.Count == cols)
            {
                res = Math.Max(res, CountRows(mat, visited));
                return;
            }
            for (int i = start; i < mat[0].Length; i++)
            {
                visited.Add(i);
                DFS(mat, i + 1, cols, visited, ref res);
                visited.Remove(i);
            }
        }

        public int CountRows(int[][] mat, HashSet<int> visited)
        {
            var res = 0;
            foreach (var row in mat)
            {
                bool hasOne = false, allIn = true;
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i] != 1) continue;
                    hasOne = true;
                    if (!visited.Contains(i))
                    {
                        allIn = false;
                        break;
                    }
                }
                if (!hasOne || allIn)
                    res++;
            }
            return res;
        }
    }
}
