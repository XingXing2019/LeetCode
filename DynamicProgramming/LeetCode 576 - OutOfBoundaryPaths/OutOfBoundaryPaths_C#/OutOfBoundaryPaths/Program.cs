using System;

namespace OutOfBoundaryPaths
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
		{
			var mod = 1_000_000_000 + 7;
			var dp = new long[m][];
			for (int i = 0; i < m; i++)
				dp[i] = new long[n];
			while (maxMove != 0)
			{
				var temp = new long[m][];
				for (int i = 0; i < m; i++)
					temp[i] = new long[n];
				for (int i = 0; i < m; i++)
				{
					for (int j = 0; j < n; j++)
					{
						temp[i][j] += i == 0 ? 1 : dp[i - 1][j] % mod;
						temp[i][j] += j == 0 ? 1 : dp[i][j - 1] % mod;
						temp[i][j] += i == m - 1 ? 1 : dp[i + 1][j] % mod;
						temp[i][j] += j == n - 1 ? 1 : dp[i][j + 1] % mod;
					}
				}
				dp = temp;
				maxMove--;
			}
			return (int)(dp[startRow][startColumn] % mod);
		}
	}
}
