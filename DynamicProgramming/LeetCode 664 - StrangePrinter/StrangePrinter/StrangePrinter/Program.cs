using System;

namespace StrangePrinter
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int StrangePrinter(string s)
		{
			var dp = new int[s.Length][][];
			for (int i = 0; i < dp.Length; i++)
			{
				dp[i] = new int[s.Length][];
				for (int j = 0; j < dp[i].Length; j++)
					dp[i][j] = new int[s.Length];
			}
			return DFS(s, dp, 0, s.Length - 1, 0);
		}

		public int DFS(string s, int[][][] dp, int li, int hi, int k)
		{
			if (li > hi) return 0;
			while (li < hi && s[hi] == s[hi - 1])
			{
				hi--;
				k++;
			}
			if (dp[li][hi][k] > 0) return dp[li][hi][k];
			dp[li][hi][k] = DFS(s, dp, li, hi - 1, 0) + 1;
			for (int i = li; i < hi; i++)
			{
				if (s[i] == s[hi])
					dp[li][hi][k] = Math.Min(dp[li][hi][k], DFS(s, dp, li, i - 1, 0) + DFS(s, dp, i, hi - 1, k + 1));
			}
			return dp[li][hi][k];
		}
	}
}
