using System;
using System.Collections.Generic;

namespace FindAllGroupsOfFarmland
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int[][] FindFarmland(int[][] land)
		{
			var visited = new bool[land.Length][];
			for (int x = 0; x < land.Length; x++)
				visited[x] = new bool[land[0].Length];
			var res = new List<int[]>();
			for (int x = 0; x < land.Length; x++)
			{
				for (int y = 0; y < land[0].Length; y++)
				{
					if (visited[x][y] || land[x][y] != 1) continue;
					int maxX = 0, maxY = 0;
					DFS(land, visited, x, y, ref maxX, ref maxY);
					res.Add(new[] { x, y, maxX, maxY });
				}
			}
			return res.ToArray();
		}

		public void DFS(int[][] land, bool[][] visited, int x, int y, ref int maxX, ref int maxY)
		{
			if (x < 0 || x >= land.Length || y < 0 || y >= land[0].Length || visited[x][y] || land[x][y] != 1)
				return;
			visited[x][y] = true;
			maxX = Math.Max(maxX, x);
			maxY = Math.Max(maxY, y);
			DFS(land, visited, x + 1, y, ref maxX, ref maxY);
			DFS(land, visited, x - 1, y, ref maxX, ref maxY);
			DFS(land, visited, x, y + 1, ref maxX, ref maxY);
			DFS(land, visited, x, y - 1, ref maxX, ref maxY);
		}
	}
}
