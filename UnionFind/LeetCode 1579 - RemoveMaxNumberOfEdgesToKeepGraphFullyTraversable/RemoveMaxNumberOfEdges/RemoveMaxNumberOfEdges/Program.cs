using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveMaxNumberOfEdges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
            {
                new[] { 3, 1, 2 },
                new[] { 3, 2, 3 },
                new[] { 1, 1, 3 },
                new[] { 1, 2, 4 },
                new[] { 1, 1, 2 },
                new[] { 2, 3, 4 },
            };
            var n = 4;
            Console.WriteLine(MaxNumEdgesToRemove(n, edges));
        }

        class UnionFind
        {
            private int[] _parent;
            private int[] _rank;
            public UnionFind(int n)
            {
                _parent = new int[n];
                for (int i = 0; i < n; i++)
                    _parent[i] = i;
                _rank = new int[n];
            }

            private int Find(int x)
            {
                if (_parent[x] != x)
                    _parent[x] = Find(_parent[x]);
                return _parent[x];
            }

            public bool Union(int x, int y)
            {
                int rootX = Find(x), rootY = Find(y);
                if (rootX == rootY) 
                    return false;
                if (_rank[rootX] < _rank[rootY])
                    _parent[rootX] = rootY;
                else
                {
                    _parent[rootY] = rootX;
                    if (_rank[rootX] == _rank[rootY])
                        _rank[rootX]++;
                }
                return true;
            }

            public int Count()
            {
                var groups = new HashSet<int>();
                foreach (var p in _parent)
                    groups.Add(Find(p));
                return groups.Count;
            }
        }

        public static int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            var res = 0;
            edges = edges.OrderByDescending(x => x[0]).ToArray();
            var alice = new UnionFind(n);
            var bob = new UnionFind(n);
            foreach (var edge in edges)
            {
                int x = edge[1] - 1, y = edge[2] - 1;
                var canRemove = false;
                if (edge[0] == 3)
                {
                    if (!alice.Union(x, y))
                        canRemove = true;
                    if (!bob.Union(x, y))
                        canRemove = true;
                }
                else if (edge[0] == 1)
                {
                    if (!alice.Union(x, y))
                        canRemove = true;
                }
                else
                {
                    if (!bob.Union(x, y)) 
                        canRemove = true;
                }
                if (canRemove)
                    res++;
            }
            return alice.Count() == 1 && bob.Count() == 1 ? res : -1;
        }
    }
}
