using System;

namespace MinimumOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinOperations(int[] nums)
		{
			int res = 0;
			for (int i = 1; i < nums.Length; i++)
			{
				if(nums[i] > nums[i - 1]) continue;
				res += nums[i - 1] - nums[i] + 1;
				nums[i] = nums[i - 1] + 1;
			}
			return res;
		}
	}
}
