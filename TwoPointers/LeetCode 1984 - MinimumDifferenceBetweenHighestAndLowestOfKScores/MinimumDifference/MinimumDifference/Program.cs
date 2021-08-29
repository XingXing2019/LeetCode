using System;

namespace MinimumDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinimumDifference(int[] nums, int k)
		{
			Array.Sort(nums);
			int min = int.MaxValue;
			int li = 0, hi = k - 1;
			while (hi < nums.Length)
			{
				min = Math.Min(min, nums[hi] - nums[li]);
				hi++;
				li++;
			}
			return min;
		}
	}
}
