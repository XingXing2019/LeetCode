using System;
using System.Collections.Generic;

namespace CountOfSmallerNumbersAfterSelf
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public IList<int> CountSmaller(int[] nums)
		{
			var right = new List<int>();
			var res = new int[nums.Length];
			for (int i = nums.Length - 1; i >= 0; i--)
			{
				int li = 0, hi = right.Count - 1;
				while (li <= hi)
				{
					int mid = li + (hi - li) / 2;
					if (right[mid] >= nums[i]) hi = mid - 1;
					else li = mid + 1;
				}
				res[i] = li;
				right.Insert(li, nums[i]);
			}
			return res;
		}
	}
}
