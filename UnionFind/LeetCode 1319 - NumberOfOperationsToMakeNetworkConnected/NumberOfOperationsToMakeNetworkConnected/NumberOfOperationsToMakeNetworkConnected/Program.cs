using System;

namespace NumberOfOperationsToMakeNetworkConnected
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			int[][] connections = {
				new[] {0, 1},
				new[] {0, 2},
				new[] {3, 4},
				new[] {2, 3},
			};
			Console.WriteLine(MakeConnected(n, connections));
		}

		private int[] parent;
		private int[] rank;
		public int MakeConnected(int n, int[][] connections)
		{
			parent = new int[n];
			for (int i = 0; i < parent.Length; i++)
				parent[i] = i;
			rank = new int[n];
			int count = 0;
			foreach (var connection in connections)
			{
				if (Merge(connection[0], connection[1]))
					n--;
				else
					count++;
			}
			return n - count <= 1 ? Math.Min(n - 1, count) : -1;
		}

		public int Find(int x)
		{
			if (parent[x] != x)
				parent[x] = Find(parent[x]);
			return parent[x];
		}

		public bool Merge(int x, int y)
		{
			int rootX = Find(x), rootY = Find(y);
			if (rootX == rootY) return false;
			if (rank[rootX] >= rank[rootY])
			{
				parent[rootY] = rootX;
				if (rank[rootX] == rank[rootY])
					rank[rootX]++;
			}
			else
				parent[rootX] = rootY;
			return true;
		}
	}
}
