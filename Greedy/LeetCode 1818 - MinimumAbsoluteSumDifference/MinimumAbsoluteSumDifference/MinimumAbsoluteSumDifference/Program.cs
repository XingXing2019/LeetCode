using System;
using System.Collections.Generic;

namespace MinimumAbsoluteSumDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums1 = { 1, 10, 4, 4, 2, 7 };
			int[] nums2 = { 9, 3, 5, 1, 7, 4 };
			Console.WriteLine(MinAbsoluteSumDiff(nums1, nums2));
		}
		public static int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
		{
			int max = int.MinValue, min = int.MaxValue;
			long res = 0, mod = 1_000_000_000 + 7;
			for (int i = 0; i < nums1.Length; i++)
			{
				max = Math.Max(max, Math.Abs(nums1[i] - nums2[i]));
				res += Math.Abs(nums1[i] - nums2[i]);
			}
			var nums = new HashSet<int>();
			for (int i = 0; i < nums1.Length; i++)
			{
				if (Math.Abs(nums1[i] - nums2[i]) == max)
					nums.Add(nums2[i]);
			}
			Array.Sort(nums1);
			foreach (var num in nums)
			{
				int index = Array.BinarySearch(nums1, num);
				if (index > 0) return (int)((res - max) % mod);
				if (index < 0) index = ~index;
				if (index == 0)
					min = Math.Min(min, nums1[1] - num);
				else if (index == nums1.Length)
					min = Math.Min(min, num - nums1[^1]);
				else
					min = Math.Min(num - nums1[index - 1], nums1[index] - num);
			}
			return (int)((res - max + min) % mod);
		}
	}
}
