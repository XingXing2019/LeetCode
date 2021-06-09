using System;
using System.Collections.Generic;

namespace JumpGameVI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		
		public int MaxResult(int[] nums, int k)
		{
			var dp = new int[nums.Length];
			dp[0] = nums[0];
			var queue = new LinkedList<int>();
			queue.AddLast(0);
			for (int i = 1; i < dp.Length; i++)
			{
				while (i - queue.First.Value > k)
					queue.RemoveFirst();
				dp[i] = dp[queue.First.Value] + nums[i];
				while (queue.Count > 0 && dp[i] >= dp[queue.Last.Value])
					queue.RemoveLast();
				queue.AddLast(i);
			}
			return dp[^1];
		}
	}
}
