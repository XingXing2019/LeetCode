using System;
using System.Collections.Generic;

namespace ShortestDistanceFromAllBuildings
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new[]
			{
				new[] {1, 0, 2, 0, 1},
				new[] {0, 0, 0, 0, 0},
				new[] {0, 0, 1, 0, 0},
			};
			Console.WriteLine(ShortestDistance(grid));
		}
		public static int ShortestDistance(int[][] grid)
		{
			int house = 0;
			var empty = new List<int[]>();
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[0].Length; j++)
				{
					if (grid[i][j] == 1)
						house++;
					else if (grid[i][j] == 0)
						empty.Add(new[] { i, j });
				}
			}
			int res = int.MaxValue;
			foreach (var e in empty)
				res = Math.Min(res, BFS(e[0], e[1], grid, house));
			return res == int.MaxValue ? -1 : res;
		}

		public static int BFS(int x, int y, int[][] grid, int houses)
		{
			var queue = new Queue<int[]>();
			queue.Enqueue(new[] { x, y, 0 });
			var visited = new HashSet<int>();
			visited.Add(100 * x + y);
			int[] dir = { 1, 0, -1, 0, 1 };
			int dis = 0;
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				for (int i = 0; i < 4; i++)
				{
					int newX = cur[0] + dir[i];
					int newY = cur[1] + dir[i + 1];
					if (newX < 0 || newX >= grid.Length || newY < 0 || newY >= grid[0].Length || grid[newX][newY] == 2)
						continue;
					if (visited.Add(100 * newX + newY))
					{
						if (grid[newX][newY] == 1)
						{
							dis += cur[2] + 1;
							houses--;
						}
						else
							queue.Enqueue(new[] {newX, newY, cur[2] + 1});
					}
				}
			}
			return houses == 0 ? dis : int.MaxValue;
		}
	}
}
