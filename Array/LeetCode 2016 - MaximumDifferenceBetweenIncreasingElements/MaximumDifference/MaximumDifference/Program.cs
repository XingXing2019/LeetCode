using System;

namespace MaximumDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaximumDifference(int[] nums)
		{
			int max = int.MinValue, res = -1;
			for (int i = nums.Length - 1; i >= 0; i--)
			{
				if (i != nums.Length - 1 && nums[i] < max)
					res = Math.Max(res, max - nums[i]);
				max = Math.Max(max, nums[i]);
			}
			return res;
		}
	}
}
