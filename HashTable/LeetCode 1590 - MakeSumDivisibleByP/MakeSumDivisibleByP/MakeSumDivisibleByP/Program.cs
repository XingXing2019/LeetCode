using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeSumDivisibleByP
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { 6, 5, 2, 3 };
			int p = 9;
			Console.WriteLine(MinSubarray(nums, p));
		}
		public static int MinSubarray(int[] nums, int p)
		{
			long sum = 0, prefix = 0;
			foreach (var num in nums)
				sum += num;
			long mod = sum % p;
			if (mod == 0) return 0;
			int min = nums.Length;
			var dict = new Dictionary<long, int> { { 0, -1 } };
			for (int i = 0; i < nums.Length; i++)
			{
				prefix += nums[i];
				var target = prefix % p - mod;
				if (target < 0) target += p;
				if (dict.ContainsKey(target))
					min = Math.Min(min, i - dict[target]);
				dict[prefix % p] = i;
			}
			return min == nums.Length ? -1 : min;
		}
	}
}
