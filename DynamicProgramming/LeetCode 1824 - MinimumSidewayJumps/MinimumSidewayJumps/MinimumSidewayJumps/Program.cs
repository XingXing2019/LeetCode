using System;
using System.Linq;

namespace MinimumSidewayJumps
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinSideJumps(int[] obstacles)
		{
			int[] dp = {1, 0, 1};
			foreach (var obstacle in obstacles)
			{
				if (obstacle != 0)
					dp[obstacle - 1] = int.MaxValue - 1;
				for (int i = 0; i < 3; i++)
				{
					if(obstacle == i + 1) continue;
					int min = int.MaxValue;
					dp[i] = Math.Min(dp[i], Math.Min(dp[(i + 1) % 3], dp[(i + 2) % 3]) + 1);
				}
			}
			return dp.Min();
		}
	}
}
