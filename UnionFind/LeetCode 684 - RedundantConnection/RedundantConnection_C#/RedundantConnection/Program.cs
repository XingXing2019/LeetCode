using System;

namespace RedundantConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public int[] FindRedundantConnection(int[][] edges)
        {
            int[] parent = new int[edges.Length + 1], rank = new int[edges.Length + 1];
            for (int i = 0; i < parent.Length; i++)
                parent[i] = i;
            foreach (var edge in edges)
            {
                if (!Merge(edge[0], edge[1], parent, rank))
                    return edge;
            }
            return null;
        }
        public int Find(int x, int[] parent)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x], parent);
            return parent[x];
        }

        public bool Merge(int x, int y, int[] parent, int[] rank)
        {
            int rootX = Find(x, parent);
            int rootY = Find(y, parent);
            if (rootX == rootY) return false;
            if (rank[rootX] > rank[rootY])
                parent[rootY] = rootX;
            else if (rank[rootX] < rank[rootY])
                parent[rootX] = rootY;
            else
            {
                parent[rootX] = rootY;
                rank[rootY]++;
            }
            return true;
        }
    }
}
