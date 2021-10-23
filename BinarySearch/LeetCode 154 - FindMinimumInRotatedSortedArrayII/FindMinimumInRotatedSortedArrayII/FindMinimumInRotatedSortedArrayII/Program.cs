using System;
using System.Linq;

namespace FindMinimumInRotatedSortedArrayII
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {1, 3, 5};
			Console.WriteLine(FindMin_BinarySearch(nums));
		}

		public static int FindMin(int[] nums)
		{
			return nums.Min();
		}

		public static int FindMin_BinarySearch(int[] nums)
		{
			int li = 0, hi = nums.Length - 1;
			while (li < hi)
			{
				var mid = li + (hi - li) / 2;
				if (nums[mid] > nums[hi])
					li = mid + 1;
				else if (nums[mid] < nums[hi])
					hi = mid;
				else
					hi--;
			}
			return nums[li];
		}
	}
}
