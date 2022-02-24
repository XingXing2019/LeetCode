using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumNumberOfFlips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] mat = new[]
            {
                new[] { 0, 0 },
                new[] { 0, 1 }
            };
            Console.WriteLine(MinFlips(mat));
        }

        class State
        {
            public int[][] mat;
            public int[] last;
            public int count;

            public State(int[][] mat, int[] last, int count)
            {
                this.mat = mat;
                this.last = last;
                this.count = count;
            }
        }

        public static int MinFlips(int[][] mat)
        {
            var queue = new Queue<State>();
            var visited = new HashSet<int> { Mask(mat) };
            queue.Enqueue(new State(mat, new []{-1, -1}, 0));
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                if (cur.mat.All(x => x.All(y => y != 1)))
                    return cur.count;
                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[0].Length; j++)
                    {
                        if (i == cur.last[0] && j == cur.last[1]) continue;
                        var newMat = Filp(cur.mat, i, j);
                        if (!visited.Add(Mask(newMat))) continue;
                        queue.Enqueue(new State(newMat, new []{i, j}, cur.count + 1));
                    }
                }
            }
            return -1;
        }

        public static int[][] Filp(int[][] mat, int i, int j)
        {
            var res = new int[mat.Length][];
            for (int x = 0; x < mat.Length; x++)
            {
                res[x] = new int[mat[0].Length];
                for (int y = 0; y < mat[0].Length; y++)
                {
                    res[x][y] = mat[x][y];
                    if (x == i && y == j) res[i][j] ^= 1;
                    if (x == i - 1 && y == j) res[i - 1][j] ^= 1;
                    if (x == i + 1 && y == j) res[i + 1][j] ^= 1;
                    if (x == i && y == j - 1) res[i][j - 1] ^= 1;
                    if (x == i && y == j + 1) res[i][j + 1] ^= 1;
                }
            }
            return res;
        }

        public static int Mask(int[][] mat)
        {
            int res = 0, index = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    if (mat[i][j] == 1)
                        res += (1 << index);
                    index++;
                }
            }
            return res;
        }
    }
}
