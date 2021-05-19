using System;
using System.Collections.Generic;
using System.Linq;

namespace FindKthLargestXORCoordinateValue
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] matrix = new[]
			{
				new[] {10, 9, 5},
				new[] {2, 0, 4},
				new[] {1, 0, 9},
				new[] {3, 4, 8}
			};
			int k = 10;
			Console.WriteLine(KthLargestValue(matrix, k));
		}
		public static int KthLargestValue(int[][] matrix, int k)
		{
			var nums = new List<int> {matrix[0][0]};
			for (int i = 1; i < matrix.Length; i++)
			{
				matrix[i][0] ^= matrix[i - 1][0];
				nums.Add(matrix[i][0]);
			}
			for (int i = 1; i < matrix[0].Length; i++)
			{
				matrix[0][i] ^= matrix[0][i - 1];
				nums.Add(matrix[0][i]);
			}
			for (int i = 1; i < matrix.Length; i++)
			{
				for (int j = 1; j < matrix[0].Length; j++)
				{
					matrix[i][j] ^= matrix[i - 1][j] ^ matrix[i][j - 1] ^ matrix[i - 1][j - 1];
					nums.Add(matrix[i][j]);
				}
			}
			return nums.OrderByDescending(x => x).Take(k).ToList()[^1];
		}
    }
}
