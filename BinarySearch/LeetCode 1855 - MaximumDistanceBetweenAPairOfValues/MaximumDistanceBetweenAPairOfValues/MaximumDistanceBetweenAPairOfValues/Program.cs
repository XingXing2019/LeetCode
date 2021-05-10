using System;

namespace MaximumDistanceBetweenAPairOfValues
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums1 = { 84, 79 };
			int[] nums2 = { 20, 19, 17, 15 };
			Console.WriteLine(MaxDistance(nums1, nums2));
		}
		public static int MaxDistance(int[] nums1, int[] nums2)
		{
			var res = 0;
			for (int i = 0; i < nums2.Length; i++)
			{
				var index = BinarySearch(nums1, nums2[i]);
				if (index == nums1.Length) continue;
				res = Math.Max(res, i - index);
			}
			return res;
		}

		public static int BinarySearch(int[] nums, int num)
		{
			int li = 0, hi = nums.Length - 1;
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				if (nums[mid] <= num) hi = mid - 1;
				else li = mid + 1;
			}
			return li;
		}
	}
}
