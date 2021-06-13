using System;
using System.Security.Cryptography;

namespace LargestMagicSquare
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new int[][]
			{
				new int[] {7, 1, 4, 5, 6},
				new int[] {2, 5, 1, 6, 4},
				new int[] {1, 5, 4, 3, 2},
				new int[] {1, 2, 7, 3, 4},
			};
			Console.WriteLine(LargestMagicSquare(grid));
		}

		public static int LargestMagicSquare(int[][] grid)
		{
			var row = new int[grid.Length][];
			var col = new int[grid.Length][];
			var dia1 = new int[grid.Length][];
			var	dia2 = new int[grid.Length][];
			for (int i = 0; i < grid.Length; i++)
			{
				row[i] = new int[grid[0].Length];
				col[i] = new int[grid[0].Length];
				dia1[i] = new int[grid[0].Length];
				dia2[i] = new int[grid[0].Length];
				for (int j = 0; j < grid[0].Length; j++)
				{
					row[i][j] = j == 0 ? grid[i][j] : row[i][j - 1] + grid[i][j];
					col[i][j] = i == 0 ? grid[i][j] : col[i - 1][j] + grid[i][j];
					dia1[i][j] = i == 0 || j == 0 ? grid[i][j] : dia1[i - 1][j - 1] + grid[i][j];
					dia2[i][j] = i == 0 || j == grid[0].Length - 1 ? grid[i][j] : dia2[i - 1][j + 1] + grid[i][j];
				}
			}
			int res = 1;
			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					int len = Math.Min(x, y) + 1;
					for (int i = 1; i <= len; i++)
					{
						if (IsMagic(x, y, i, row, col, dia1, dia2))
							res = Math.Max(res, i);
					}
				}
			}
			return res;
		}

		private static bool IsMagic(int x, int y, int len, int[][] row, int[][] col, int[][] dia1, int[][] dia2)
		{
			int sum1 = x - len >= 0 && y - len >= 0 ? dia1[x][y] - dia1[x - len][y - len] : dia1[x][y];
			int sum2 = x - len >= 0 && y + 1 < dia2[0].Length ? dia2[x][y - len + 1] - dia2[x - len][y + 1] : dia2[x][y - len + 1];
			if (sum1 != sum2) return false;
			for (int i = x - len + 1; i <= x; i++)
			{
				int sum = y - len >= 0 ? row[i][y] - row[i][y - len] : row[i][y];
				if (sum != sum1) return false;
			}
			for (int i = y - len + 1; i <= y; i++)
			{
				int sum = x - len >= 0 ? col[x][i] - col[x - len][i] : col[x][i];
				if (sum != sum1) return false;
			}
			return true;
		}
	}
}
