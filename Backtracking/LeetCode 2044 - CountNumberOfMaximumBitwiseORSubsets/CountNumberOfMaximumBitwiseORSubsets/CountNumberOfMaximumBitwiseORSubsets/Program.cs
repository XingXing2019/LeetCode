using System;
using System.Collections.Generic;

namespace CountNumberOfMaximumBitwiseORSubsets
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {3, 2, 1, 5};
			Console.WriteLine(CountMaxOrSubsets(nums));
		}

		public static int CountMaxOrSubsets(int[] nums)
		{
			int max = -1;
			var dict = new Dictionary<int, int>();
			DFS(nums, 0, 0, dict, ref max);
			return dict[max];
		}

		public static void DFS(int[] nums, int start, int or, Dictionary<int, int> dict, ref int max)
		{
			if (!dict.ContainsKey(or))
				dict[or] = 0;
			dict[or]++;
			max = Math.Max(max, or);
			for (int i = start; i < nums.Length; i++)
			{
				DFS(nums, i + 1, or | nums[i], dict, ref max);
			}
		}
	}
}
