using System;
using System.Collections.Generic;

namespace DetectCyclesIn2DGrid
{
	class Program
	{
		static void Main(string[] args)
		{
			char[][] grid = new char[][]
			{
				new char[] {'c', 'a', 'd'},
				new char[] {'a', 'a', 'a'},
				new char[] {'a', 'a', 'd'},
			};
		}

		private Dictionary<string, string> parents;
		private Dictionary<string, int> rank;
		public bool ContainsCycle(char[][] grid)
		{
			parents = new Dictionary<string, string>();
			rank = new Dictionary<string, int>();
			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					parents[$"{x}:{y}"] = $"{x}:{y}";
					rank[$"{x}:{y}"] = 0;
				}
			}
			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					if (x + 1 < grid.Length && grid[x + 1][y] == grid[x][y] && !Union($"{x}:{y}", $"{x + 1}:{y}"))
						return true;
					if (y + 1 < grid[0].Length && grid[x][y + 1] == grid[x][y] && !Union($"{x}:{y}", $"{x}:{y + 1}"))
						return true;
				}
			}
			return false;
		}

		public string Find(string x)
		{
			if (parents[x] != x)
				parents[x] = Find(parents[x]);
			return parents[x];
		}

		public bool Union(string x, string y)
		{
			string rootX = Find(x), rootY = Find(y);
			if (rootX == rootY) return false;
			if (rank[rootX] >= rank[rootY])
			{
				parents[rootY] = rootX;
				if (rank[rootX] == rank[rootY])
					rank[rootX]++;
			}
			else
				parents[rootX] = rootY;
			return true;
		}
	}
}
