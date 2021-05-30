using System;

namespace MaximumGap
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaximumGap(int[] nums)
		{
			if (nums.Length < 2) return 0;
			Array.Sort(nums);
			int res = 0;
			for (int i = 1; i < nums.Length; i++)
				res = Math.Max(res, nums[i] - nums[i - 1]);
			return res;
		}
	}
}
