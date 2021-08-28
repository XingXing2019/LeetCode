using System;
using System.Collections.Generic;

namespace WidestPairOfIndicesWithEqualRangeSum
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int WidestPairOfIndices(int[] nums1, int[] nums2)
		{
			for (int i = 1; i < nums1.Length; i++)
			{
				nums1[i] += nums1[i - 1];
				nums2[i] += nums2[i - 1];
			}
			int res = 0;
			var dict = new Dictionary<int, int>();
			dict[0] = -1;
			for (int i = 0; i < nums1.Length; i++)
			{
				if (!dict.ContainsKey(nums1[i] - nums2[i]))
					dict[nums1[i] - nums2[i]] = i;
				else
					res = Math.Max(res, i - dict[nums1[i] - nums2[i]]);
			}
			return res;
		}
	}
}
