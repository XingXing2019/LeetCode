using System;
using System.Collections.Generic;
using System.Linq;

namespace MakingALargeIsland
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new int[][]
			{
				new int[] {0, 0, 0, 0},
				new int[] {0, 1, 1, 1},
				new int[] {0, 1, 0, 0},
				new int[] {1, 0, 1, 0},
			};
			Console.WriteLine(LargestIsland(grid));
		}

		public static int LargestIsland(int[][] grid)
		{
			var visited = new int[grid.Length][];
			for (int i = 0; i < visited.Length; i++)
				visited[i] = new int[grid[0].Length];
			var size = new Dictionary<int, int>();
			var zeros = new List<int[]>();
			int res = 1, id = 1;
			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					if (grid[x][y] == 0)
					{
						zeros.Add(new[] { x, y });
						continue;
					}
					if (visited[x][y] != 0) continue;
					DFS(grid, visited, size, id, x, y);
					id++;
				}
			}
			if (zeros.Count == 0) return grid.Length * grid[0].Length;
			foreach (var zero in zeros)
			{
				int[] dir = {1, 0, -1, 0, 1};
				HashSet<int> ids = new HashSet<int>();
				for (int i = 0; i < 4; i++)
				{
					int newX = dir[i] + zero[0], newY = dir[i + 1] + zero[1];
					if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length) continue;
					if(visited[newX][newY] != 0) ids.Add(visited[newX][newY]);
				}
				res = Math.Max(res, ids.Sum(x => size[x]) + 1);
			}
			return res;
		}

		public static void DFS(int[][] grid, int[][] visited, Dictionary<int, int> size, int id, int x, int y)
		{
			if (x < 0 || x >= grid.Length || y < 0 || y >= grid[0].Length || visited[x][y] == id || grid[x][y] == 0)
				return;
			visited[x][y] = id;
			if (!size.ContainsKey(id))
				size[id] = 0;
			size[id]++;
			DFS(grid, visited, size, id, x - 1, y);
			DFS(grid, visited, size, id, x + 1, y);
			DFS(grid, visited, size, id, x, y - 1);
			DFS(grid, visited, size, id, x, y + 1);
		}
	}
}
