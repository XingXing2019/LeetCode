using System;
using System.Collections.Generic;

namespace DistinctNumbersInEachSubarray
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {1, 2, 3, 2, 2, 1, 3};
			int k = 3;
			Console.WriteLine(DistinctNumbers(nums, k));
		}
		public static int[] DistinctNumbers(int[] nums, int k)
		{
			var res = new int[nums.Length - k + 1];
			var record = new Dictionary<int, int>();
			int li = 0, hi = k;
			for (int i = 0; i < k; i++)
			{
				if (!record.ContainsKey(nums[i]))
					record[nums[i]] = 0;
				record[nums[i]]++;
			}
			while (hi < nums.Length)
			{
				res[li] = record.Count;
				if (!record.ContainsKey(nums[hi]))
					record[nums[hi]] = 0;
				record[nums[hi]]++;
				hi++;
				record[nums[li]]--;
				if (record[nums[li]] == 0)
					record.Remove(nums[li]);
				li++;
			}
			res[li] = record.Count;
			return res;
		}
	}
}
