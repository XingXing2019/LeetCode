using System;
using System.Linq;

namespace MaximumNumberOfPointsWithCost
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] points = new[]
			{
				new[] {4, 1, 0, 4, 0},
				new[] {1, 0, 4, 0, 5},
			};
			Console.WriteLine(MaxPoints(points));
		}

		public static long MaxPoints(int[][] points)
		{
			var dp = new long[points.Length][];
			for (int i = 0; i < dp.Length; i++)
				dp[i] = new long[points[0].Length];
			long res = 0;
			for (int i = 0; i < dp[0].Length; i++)
			{
				dp[0][i] = points[0][i];
				res = Math.Max(res, dp[0][i]);
			}
			for (int i = 1; i < dp.Length; i++)
			{
				var left = new long[dp[0].Length];
				var right = new long[dp[0].Length];
				long leftMax = int.MinValue, rightMax = int.MinValue;
				for (int j = 0; j < left.Length; j++)
				{
					leftMax = Math.Max(leftMax, dp[i - 1][j] + j);
					left[j] = leftMax;
					rightMax = Math.Max(rightMax, dp[i - 1][^(j + 1)] - (dp[0].Length - j - 1));
					right[^(j + 1)] = rightMax ;					
				}
				for (int j = 0; j < dp[0].Length; j++)
				{
					dp[i][j] = Math.Max(left[j] - j, right[j] + j) + points[i][j];
					res = Math.Max(res, dp[i][j]);
				}
			}
			return res;
		}
	}
}
