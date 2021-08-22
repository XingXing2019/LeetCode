using System;

namespace MaximumMatrixSum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] board = new[]
			{
				new[] {-1, 0, -1},
				new[] {-2, 1, 3},
				new[] {3, 2, 2}
			};
			Console.WriteLine(MaxMatrixSum(board));
		}
		public static long MaxMatrixSum(int[][] matrix)
		{
			int countNeg = 0, countZero = 0;
			long max = long.MinValue, min = long.MaxValue, sum = 0;
			for (int i = 0; i < matrix.Length; i++)
			{
				for (int j = 0; j < matrix[0].Length; j++)
				{
					sum += Math.Abs(matrix[i][j]);
					if (matrix[i][j] < 0)
					{
						countNeg++;
						max = Math.Max(max, matrix[i][j]);
					}
					else if (matrix[i][j] == 0)
						countZero++;
					else
						min = Math.Min(min, matrix[i][j]);
				}
			}
			return (countNeg - countZero) % 2 == 0 || countZero > countNeg ? sum : sum - Math.Min(-max, min) * 2;
		}
	}
}
