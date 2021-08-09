using System;
using System.Collections.Generic;
using System.Linq;

namespace RankTransformOfAMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] matirx = new[]
			{
				new[] {-43},
			};
			Console.WriteLine(MatrixRankTransform(matirx));
		}

        public class Unions
        {
            private readonly int[] _parents;
            private readonly int[] _ranks;
            public Unions(int n)
            {
                _parents = new int[n];
                _ranks = new int[n];
                for (int i = 0; i < n; i++)
                    _parents[i] = i;
            }

            public int Find(int x)
            {
                if (x != _parents[x])
                    x = Find(_parents[x]);
                return _parents[x];
            }

            public bool Union(int x, int y)
            {
                int px = Find(x);
                int py = Find(y);
                if (px == py)
                    return false;
                if (_ranks[px] > _ranks[py])
                {
                    _parents[py] = px;
                    _ranks[px]++;
                }
                else
                {
                    _parents[px] = py;
                    _ranks[py]++;
                }
                return true;
            }
        }

        public static int[][] MatrixRankTransform(int[][] matrix)
        {
            int n = matrix.Length, m = matrix[0].Length;
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
                res[i] = new int[m];
            Unions dsu = new Unions(n * m);
            for (int i = 0; i < n; i++)
            {
                IDictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
                for (int j = 0; j < m; j++)
                {
                    var val = matrix[i][j];
                    if (!map.ContainsKey(val))
                        map[val] = new List<int>();
                    map[val].Add(j);
                }
                foreach (var kv in map)
                {
                    for (int k = 1; k < kv.Value.Count; k++)
                        dsu.Union(i * m + kv.Value[k], i * m + kv.Value[k - 1]);
                }
            }
            for (int j = 0; j < m; j++)
            {
                IDictionary<int, IList<int>> map = new Dictionary<int, IList<int>>();
                for (int i = 0; i < n; i++)
                {
                    var val = matrix[i][j];
                    if (!map.ContainsKey(val))
                        map[val] = new List<int>();
                    map[val].Add(i);
                }

                foreach (var kv in map)
                {
                    for (int k = 1; k < kv.Value.Count; k++)
                        dsu.Union(kv.Value[k] * m + j, kv.Value[k - 1] * m + j);
                }
            }

            IDictionary<int, IList<int>> root2Indices = new Dictionary<int, IList<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var lin = i * m + j;
                    var root = dsu.Find(lin);
                    if (!root2Indices.ContainsKey(root))
                        root2Indices[root] = new List<int>();
                    root2Indices[root].Add(lin);
                }
            }

            List<(int val, int row, int col)> data = new List<(int val, int row, int col)>(n * m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    data.Add((matrix[i][j], i, j));
            }
            data.Sort((d1, d2) =>
            {
                var cmp = d1.val.CompareTo(d2.val);
                if (cmp == 0)
                    cmp = d1.row.CompareTo(d2.row);
                if (cmp == 0)
                    cmp = d1.col.CompareTo(d2.col);
                return cmp;
            });
            int[] rowRanks = new int[n];
            int[] colRanks = new int[m];
            int idx = 0;
            while (idx != n * m)
            {
                var tmp = data[idx];
                var row = tmp.row;
                var col = tmp.col;
                var lin = row * m + col;
                if (res[row][col] != 0)
                {
                    idx++;
                    continue;
                }
                int maxRank = 0;
                var root = dsu.Find(lin);
                foreach (var index in root2Indices[root])
                {
                    var r = index / m;
                    var c = index % m;
                    maxRank = Math.Max(maxRank, Math.Max(rowRanks[r], colRanks[c]));
                }

                var thisRank = maxRank + 1;
                foreach (var index in root2Indices[root])
                {
                    var r = index / m;
                    var c = index % m;
                    res[r][c] = thisRank;
                    rowRanks[r] = thisRank;
                    colRanks[c] = thisRank;
                }
                idx++;
            }
            return res;
        }
    }
}
