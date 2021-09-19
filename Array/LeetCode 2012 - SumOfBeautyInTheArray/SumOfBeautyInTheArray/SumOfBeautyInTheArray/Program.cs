using System;

namespace SumOfBeautyInTheArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int SumOfBeauties(int[] nums)
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
			for (int i = 1; i < nums.Length - 1; i++)
			{
				if (nums[i] > leftMax[i] && nums[i] < rightMin[i])
					res += 2;
				else if (nums[i - 1] < nums[i] && nums[i] < nums[i + 1])
					res++;
			}
			return res;
		}
	}
}
