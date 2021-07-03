using System;

namespace MaxSumOfRectangleNoLargerThanK
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] matrix = new[]
			{
				new int[] {5, -4, -3, 4},
				new int[] {-3, -4, 4, 5},
				new int[] {5, 1, 5, -4},
			};
			var k = 3;
			Console.WriteLine(MaxSumSubmatrix(matrix, k));
		}
		public static int MaxSumSubmatrix(int[][] matrix, int k)
		{
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					if(i == 0 && j == 0) continue;
					if (i == 0 && j != 0) matrix[i][j] += matrix[i][j - 1];
					else if (i != 0 && j == 0) matrix[i][j] += matrix[i - 1][j];
					else matrix[i][j] += matrix[i - 1][j] + matrix[i][j - 1] - matrix[i - 1][j - 1];
				}
			}
			int res = int.MinValue;
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					for (int m = 0; m <= i; m++)
					{
						for (int n = 0; n <= j; n++)
						{
							int sum = matrix[i][j];
							if (m != 0) sum -= matrix[m - 1][j];
							if (n != 0) sum -= matrix[i][n - 1];
							if (m != 0 && n != 0) sum += matrix[m - 1][n - 1];
							if (sum <= k)
								res = Math.Max(res, sum);
						}
					}
				}
			}
			return res;
		}
	}
}
