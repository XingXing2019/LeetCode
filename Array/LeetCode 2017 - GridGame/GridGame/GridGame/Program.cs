using System;

namespace GridGame
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new int[2][]
			{
				new int[] {1, 3, 1, 15},
				new int[] {1, 3, 3, 1},
			};
			Console.WriteLine(GridGame(grid));
		}

		public static long GridGame(int[][] grid)
		{
			var prefix = new long[2][];
			for (int i = 0; i < 2; i++)
			{
				prefix[i] = new long[grid[0].Length];
				prefix[i][0] = grid[i][0];
				for (int j = 1; j < grid[0].Length; j++)
					prefix[i][j] = prefix[i][j - 1] + grid[i][j];
			}
			long res = long.MaxValue;
			for (int i = 0; i < grid[0].Length; i++)
			{
				long option1 = prefix[0][^1] - prefix[0][i];
				long option2 = i == 0 ? 0 : prefix[1][i - 1];
				res = Math.Min(res, Math.Max(option1, option2));
			}
			return res;
		}
	}
}
