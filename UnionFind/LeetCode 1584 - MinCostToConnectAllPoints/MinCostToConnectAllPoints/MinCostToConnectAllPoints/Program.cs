using System;
using System.Collections.Generic;
using System.Linq;

namespace MinCostToConnectAllPoints
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		private int[] parent;
		private int[] rank;
		public int MinCostConnectPoints(int[][] points)
		{
			var edges = new List<int[]>();
			for (int i = 0; i < points.Length; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					var dis = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
					edges.Add(new[] { i, j, dis});
				}
			}
			edges = edges.OrderBy(x => x[2]).ToList();
			rank = new int[points.Length];
			parent = new int[points.Length];
			for (int i = 0; i < parent.Length; i++)
				parent[i] = i;
			int res = 0;
			foreach (var edge in edges)
			{
				if (Union(edge[0], edge[1]))
					res += edge[2];
			}
			return res;
		}

		public int Find(int x)
		{
			if (parent[x] != x)
				parent[x] = Find(parent[x]);
			return parent[x];
		}

		public bool Union(int x, int y)
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
