using System;
using System.Collections.Generic;

namespace CountNicePairsInAnArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CountNicePairs(int[] nums)
		{
			int[] rev = new int[nums.Length];
			for (int i = 0; i < nums.Length; i++)
			{
				int num = nums[i];
				while (num != 0)
				{
					rev[i] = rev[i] * 10 + num % 10;
					num /= 10;
				}
			}
			long res = 0, mod = 1_000_000_000 + 7;
			var dict = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				if (dict.ContainsKey(nums[i] - rev[i]))
					res += dict[nums[i] - rev[i]];
				else
					dict[nums[i] - rev[i]] = 0;
				dict[nums[i] - rev[i]]++;
			}
			return (int) (res % mod);
		}
	}
}
