using System;
using System.Collections.Generic;

namespace CountSubarraysWithMoreOnesThanZeros
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { 1, 0, 1, 0, 1 };
			Console.WriteLine(SubarraysWithMoreZerosThanOnes(nums));
		}
		public static int SubarraysWithMoreZerosThanOnes(int[] nums)
		{
			int sum = 0;
			long res = 0, mod = 1_000_000_000 + 7;
			for (int i = 0; i < nums.Length; i++)
			{
				sum += nums[i] == 0 ? -1 : 1;
				nums[i] = sum;
			}
			var smaller = new List<int> { 0 };
			for (int i = 0; i < nums.Length; i++)
			{
				var index = BinarySearch(smaller, nums[i]);
				res += index;
				smaller.Insert(index, nums[i]);
			}
			return (int)(res % mod);
		}

		public static int BinarySearch(List<int> nums, int target)
		{
			int li = 0, hi = nums.Count - 1;
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				if (nums[mid] >= target)
					hi = mid - 1;
				else
					li = mid + 1;
			}
			return li;
		}
	}
}
