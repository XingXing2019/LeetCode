using System;

namespace MaximumProductDifferenceBetweenTwoPairs
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaxProductDifference(int[] nums)
		{
			Array.Sort(nums);
			return nums[^1] * nums[^2] - nums[0] * nums[1];
		}
	}
}
