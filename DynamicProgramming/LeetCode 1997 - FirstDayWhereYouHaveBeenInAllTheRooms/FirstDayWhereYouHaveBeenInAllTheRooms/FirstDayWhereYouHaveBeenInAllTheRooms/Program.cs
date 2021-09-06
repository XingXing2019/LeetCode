using System;

namespace FirstDayWhereYouHaveBeenInAllTheRooms
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int FirstDayBeenInAllRooms(int[] nextVisit)
		{
			var dp = new long[nextVisit.Length];
			int mod = 1_000_000_000 + 7;
			for (int i = 1; i < nextVisit.Length; i++)
			{
				if (nextVisit[i - 1] == i - 1)
					dp[i] = dp[i - 1] + 2;
				else
					dp[i] = (2 * dp[i - 1] - dp[nextVisit[i - 1]] + 2 + mod) % mod;
			}
			return (int) dp[^1] % mod;
		}
	}
}
