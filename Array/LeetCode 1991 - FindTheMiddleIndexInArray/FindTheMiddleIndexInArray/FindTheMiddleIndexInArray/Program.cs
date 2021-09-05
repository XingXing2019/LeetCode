

using System;

namespace FindTheMiddleIndexInArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int FindMiddleIndex(int[] nums)
		{
			for (int i = 1; i < nums.Length; i++)
				nums[i] += nums[i - 1];
			for (int i = 0; i < nums.Length; i++)
			{
				if (i == 0 && nums[^1] - nums[i] == 0)
					return 0;
				if (i != 0 && nums[^1] - nums[i] == nums[i - 1])
					return i;
			}
			return -1;
		}
	}
}
