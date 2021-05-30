using System;

namespace MinimizeMaximumPairSumInArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinPairSum(int[] nums)
		{
			Array.Sort(nums);
			int res = 0;
			for (int i = 0; i < nums.Length / 2; i++)
				res = Math.Max(res, nums[i] + nums[^(i + 1)]);
			return res;
		}
	}
}
