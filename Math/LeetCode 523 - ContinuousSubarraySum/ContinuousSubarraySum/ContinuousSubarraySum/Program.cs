using System;
using System.Collections.Generic;

namespace ContinuousSubarraySum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {0, 1};
			int k = 2;
			Console.WriteLine(CheckSubarraySum(nums, k));
		}
		public static bool CheckSubarraySum(int[] nums, int k)
		{
			var dict = new Dictionary<int, int> {{0, -1}};
			int prefix = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				prefix += nums[i];
				int mod = prefix % k;
				if (!dict.ContainsKey(mod))
					dict[mod] = i;
				else if (i - dict[mod] != 1)
					return true;
			}
			return false;
		}
	}
}
