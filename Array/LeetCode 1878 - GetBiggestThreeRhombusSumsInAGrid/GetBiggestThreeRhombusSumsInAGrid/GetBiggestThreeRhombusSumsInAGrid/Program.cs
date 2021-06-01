using System;
using System.Collections.Generic;
using System.Linq;

namespace GetBiggestThreeRhombusSumsInAGrid
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new[]
			{
				new[] {3, 4, 5, 1, 3},
				new[] {3, 3, 4, 2, 3},
				new[] {20, 30, 200, 40, 10},
				new[] {1, 5, 5, 4, 1},
				new[] {4, 3, 2, 2, 5}
			};
			Console.WriteLine(GetBiggestThree(grid));
		}

		public static int[] GetBiggestThree(int[][] grid)
		{
			int row = grid.Length, col = grid[0].Length;
			var set = new HashSet<int>();
			for (int x = 0; x < row; x++)
			{
				for (int y = 0; y < col; y++)
				{
					int maxLen = Math.Min(Math.Min(y + 1, col - y), (int)Math.Ceiling(((double)row - x) / 2));
					for (int len = 1; len <= maxLen; len++)
					{
						int sum = GetSum(grid, x, y, len);
						set.Add(sum);
					}
				}
			}
			return set.OrderByDescending(x => x).Take(3).ToArray();
		}

		private static int GetSum(int[][] grid, int x, int y, int len)
		{
			int[] dx = { 1, 1, -1, -1 };
			int[] dy = { -1, 1, 1, -1 };
			int sum = len == 1 ? grid[x][y] : 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 1; j < len; j++)
				{
					x += dx[i];
					y += dy[i];
					sum += grid[x][y];
				}
			}
			return sum;
		}
	}
}
