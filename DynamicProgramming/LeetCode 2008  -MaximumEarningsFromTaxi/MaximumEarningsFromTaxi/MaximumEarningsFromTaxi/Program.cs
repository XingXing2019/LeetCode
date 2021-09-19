using System;
using System.Linq;

namespace MaximumEarningsFromTaxi
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public long MaxTaxiEarnings(int n, int[][] rides)
		{
			var dict = rides.GroupBy(x => x[1]).ToDictionary(x => x.Key, x => x.ToList());
			var dp = new long[n + 1];
			for (int i = 1; i < dp.Length; i++)
			{
				dp[i] = dp[i - 1];
				if(!dict.ContainsKey(i)) continue;
				long max = 0;
				foreach (var ride in dict[i])
					max = Math.Max(max, dp[ride[0]] + ride[1] - ride[0] + ride[2]);
				dp[i] = Math.Max(max, dp[i]);
			}
			return dp[^1];
		}
	}
}
