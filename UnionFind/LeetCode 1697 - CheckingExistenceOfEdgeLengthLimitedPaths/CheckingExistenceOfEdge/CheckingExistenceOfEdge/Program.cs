using System;
using System.Linq;

namespace CheckingExistenceOfEdge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private int[] parents;
        private int[] rank;

        public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries)
        {
            parents = new int[n];
            rank = new int[n];
            var res = new bool[queries.Length];
            for (int i = 0; i < queries.Length; i++)
                queries[i] = new[] { queries[i][0], queries[i][1], queries[i][2], i };
            for (int i = 0; i < n; i++)
                parents[i] = i;
            var index = 0;
            edgeList = edgeList.OrderBy(x => x[2]).ToArray();
            queries = queries.OrderBy(x => x[2]).ToArray();
            foreach (var query in queries)
            {
                while (index < edgeList.Length && edgeList[index][2] < query[2])
                {
                    int x = edgeList[index][0], y = edgeList[index][1];
                    Union(x, y);
                    index++;
                }
                res[query[3]] = Find(query[0]) == Find(query[1]);
            }
            return res;
        }

        public int Find(int x)
        {
            if (parents[x] != x)
                parents[x] = Find(parents[x]);
            return parents[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x), rootY = Find(y);
            if (rootX == rootY) return;
            if (rank[rootX] < rank[rootY])
                parents[rootX] = rootY;
            else
            {
                parents[rootY] = rootX;
                if (rank[rootX] == rank[rootY])
                    rank[rootX]++;
            }
        }
    }
}
