using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSubIslands
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid1 = new int[][]
			{
				new int[] {1, 1, 1, 0, 0},
				new int[] {0, 1, 1, 1, 1},
				new int[] {0, 0, 0, 0, 0},
				new int[] {1, 0, 0, 0, 0},
				new int[] {1, 1, 0, 1, 1}
			};
			int[][] grid2 = new int[][]
			{
				new int[] {1, 1, 1, 0, 0},
				new int[] {0, 0, 1, 1, 1},
				new int[] {0, 1, 0, 0, 0},
				new int[] {1, 0, 1, 1, 0},
				new int[] {0, 1, 0, 1, 0}
			};
			Console.WriteLine(CountSubIslands(grid1, grid2));
		}
		
		public static int CountSubIslands(int[][] grid1, int[][] grid2)
		{
			int[] dir = {1, 0, -1, 0, 1};
			int res = 0;
			var visited = new HashSet<string>();
			for (int x = 0; x < grid1.Length; x++)
			{
				for (int y = 0; y < grid1[0].Length; y++)
				{
					if (grid2[x][y] != 1 || !visited.Add($"{x}:{y}")) 
						continue;
					if (DFS(grid1, grid2, x, y, dir, visited))
						res++;
				}
			}
			return res;
		}

		private static bool DFS(int[][] grid1, int[][] grid2, int x, int y, int[] dir, HashSet<string> visited)
		{
			var res = grid1[x][y] == 1;
			for (int i = 0; i < 4; i++)
			{
				int newX = x + dir[i];
				int newY = y + dir[i + 1];
				if (newX < 0 || newX >= grid1.Length || newY < 0 || newY >= grid1[0].Length || grid2[newX][newY] == 0)
					continue;
				if(visited.Add($"{newX}:{newY}"))
					res &= DFS(grid1, grid2, newX, newY, dir, visited);
			}
			return res;
		}
	}
}
