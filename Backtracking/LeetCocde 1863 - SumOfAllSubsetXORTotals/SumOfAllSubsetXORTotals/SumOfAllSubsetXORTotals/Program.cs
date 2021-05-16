using System;
using System.Collections.Generic;

namespace SumOfAllSubsetXORTotals
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { 5, 1, 6 };
			Console.WriteLine(SubsetXORSum(nums));
		}
		public static int SubsetXORSum(int[] nums)
		{
			var res = 0;
			BackTracking(nums, 0, 0, ref res);
			return res;
		}

		public static void BackTracking(int[] nums, int index, int total, ref int res)
		{
			if (index > nums.Length) return;
			res += total;
			for (int i = index; i < nums.Length; i++)
				BackTracking(nums, i + 1, total ^ nums[i], ref res);
		}
	}
}
