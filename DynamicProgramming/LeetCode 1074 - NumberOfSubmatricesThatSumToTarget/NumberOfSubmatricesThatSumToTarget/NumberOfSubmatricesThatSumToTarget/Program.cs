using System;

namespace NumberOfSubmatricesThatSumToTarget
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] matrix = new[]
			{
				new[] {0, 1, 0},
				new[] {1, 1, 1},
				new[] {0, 1, 0},
			};
			int target = 0;
			Console.WriteLine(NumSubmatrixSumTarget(matrix, target));
		}
		public static int NumSubmatrixSumTarget(int[][] matrix, int target)
		{
			int res = 0;
			var dp = new int[matrix.Length][];
			for (int i = 0; i < dp.Length; i++)
				dp[i] = new int[matrix[0].Length];
			for (int i = 0; i < dp.Length; i++)
			{
				for (int j = 0; j < dp[0].Length; j++)
				{
					if (i == 0 && j == 0)
						dp[i][j] = matrix[i][j];
					else if (i == 0 && j != 0)
						dp[i][j] = dp[i][j - 1] + matrix[i][j];
					else if (i != 0 && j == 0)
						dp[i][j] = dp[i - 1][j] + matrix[i][j];
					else
						dp[i][j] = dp[i - 1][j] + dp[i][j - 1] - dp[i - 1][j - 1] + matrix[i][j];
				}
			}
			for (int i = 0; i < dp.Length; i++)
			{
				for (int j = 0; j < dp[0].Length; j++)
				{
					int[] p2 = {i, j};
					for (int k = 0; k <= i; k++)
					{
						for (int l = 0; l <= j; l++)
						{
							int[] p1 = {k, l};
							if (GetSum(dp, p1, p2) == target)
								res++;
						}
					}
				}
			}
			return res;
		}

		public static int GetSum(int[][] matrix, int[] p1, int[] p2)
		{
			int x1 = p1[0], y1 = p1[1];
			int x2 = p2[0], y2 = p2[1];
			int num1 = matrix[x2][y2];
			int num2 = y1 - 1 < 0 ? 0 : matrix[x2][y1 - 1];
			int num3 = x1 - 1 < 0 ? 0 : matrix[x1 - 1][y2];
			int num4 = x1 - 1 < 0 || y1 - 1 < 0 ? 0 : matrix[x1 - 1][y1 - 1];
			return num1 - num2 - num3 + num4;
		}
	}
}
