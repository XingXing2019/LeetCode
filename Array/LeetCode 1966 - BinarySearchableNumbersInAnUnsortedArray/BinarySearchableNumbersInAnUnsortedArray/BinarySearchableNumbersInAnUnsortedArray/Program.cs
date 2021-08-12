using System;

namespace BinarySearchableNumbersInAnUnsortedArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int BinarySearchableNumbers(int[] nums)
		{
			int[] leftMax = new int[nums.Length], rightMin = new int[nums.Length];
			int max = int.MinValue, min = int.MaxValue, res = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				leftMax[i] = max;
				max = Math.Max(max, nums[i]);
				rightMin[^(i + 1)] = min;
				min = Math.Min(min, nums[^(i + 1)]);
			}
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] > leftMax[i] && nums[i] < rightMin[i])
					res++;
			}
			return res;
		}
	}
}
