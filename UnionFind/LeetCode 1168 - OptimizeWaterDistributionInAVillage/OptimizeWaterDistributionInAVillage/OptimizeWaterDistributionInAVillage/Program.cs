using System;
using System.Linq;

namespace OptimizeWaterDistributionInAVillage
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 3;
			int[] wells = {1, 2, 2};
			int[][] pipes = new[]
			{
				new[] {1, 2, 1},
				new[] {2, 3, 1},
			};
			Console.WriteLine(MinCostToSupplyWater(n, wells, pipes));
		}

		private static int[] parent;
		private static int[] rank;
		public static int MinCostToSupplyWater(int n, int[] wells, int[][] pipes)
		{
			parent = new int[n + 1];
			for (int i = 0; i < parent.Length; i++)
				parent[i] = i;
			rank = new int[n + 1];
			int[][] connections = new int[wells.Length + pipes.Length][];
			int index = 0, res = 0;
			foreach (var pipe in pipes)
				connections[index++] = pipe;
			for (int i = 0; i < wells.Length; i++)
				connections[index++] = new[] {i + 1, 0, wells[i]};
			connections = connections.OrderBy(x => x[2]).ToArray();
			foreach (var connection in connections)
			{
				if (Union(connection[0], connection[1]))
					res += connection[2];
			}
			return res;
		}

		public static int Find(int x)
		{
			if (parent[x] != x)
				parent[x] = Find(parent[x]);
			return parent[x];
		}

		public static bool Union(int x, int y)
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
