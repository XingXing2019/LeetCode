using System;
using System.Collections.Generic;

namespace CountPairsInTwoArrays
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums1 = { 19, 19 };
			int[] nums2 = { 19, 19 };
			Console.WriteLine(CountPairs(nums1, nums2));
		}
		public static long CountPairs(int[] nums1, int[] nums2)
		{
			var diff = new int[nums1.Length];
			for (int i = 0; i < nums1.Length; i++)
				diff[i] = nums1[i] - nums2[i];
			List<int> neg = new List<int>(), pos = new List<int>();
			int zero = 0;
			long res = 0;
			for (int i = diff.Length - 1; i >= 0; i--)
			{
				res += pos.Count;
				if (diff[i] == 0)
					zero++;
				else if (diff[i] > 0)
				{
					res += zero + BinarySearch(neg, diff[i], true);
					pos.Insert(BinarySearch(pos, diff[i], false), diff[i]);
				}
				else
				{
					res -= BinarySearch(pos, -diff[i], false);
					neg.Insert(BinarySearch(neg, -diff[i], true), -diff[i]);
				}
			}
			return res;
		}

		public static int BinarySearch(List<int> nums, int target, bool isNeg)
		{
			int li = 0, hi = nums.Count - 1;
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				if (nums[mid] > target) hi = mid - 1;
				else if (nums[mid] < target) li = mid + 1;
				else if (isNeg) hi = mid - 1;
				else li = mid + 1;
			}
			return li;
		}
	}
}
