using System;

namespace CombinationSumIV
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CombinationSum4(int[] nums, int target)
		{
			var dp = new int[target + 1];
			dp[0] = 1;
			for (int i = 1; i < dp.Length; i++)
			{
				foreach (var num in nums)
				{
					if(i - num < 0) continue;
					dp[i] += dp[i - num];
				}
			}
			return dp[^1];
		}
	}
}
