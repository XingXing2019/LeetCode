using System;

namespace JumpGameVI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		// LTE
		public int MaxResult(int[] nums, int k)
		{
			var dp = new int[nums.Length];
			dp[^1] = nums[^1];
			for (int i = dp.Length - 2; i >= 0; i--)
			{
				int max = int.MinValue;
				for (int j = i + 1; j <= i + k && j < dp.Length; j++)
					max = Math.Max(max, dp[j]);
				dp[i] = nums[i] + max;
			}
			return dp[0];
		}
	}
}
