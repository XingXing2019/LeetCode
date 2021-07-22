using System;

namespace PartitionArrayIntoDisjointIntervals
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {5, 0, 3, 8, 6};
			Console.WriteLine(PartitionDisjoint(nums));
		}

		public static int PartitionDisjoint(int[] nums)
		{
			int[] rightMin = new int[nums.Length], leftMax = new int[nums.Length];
			int min = nums[^1], max = nums[0], index = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				leftMax[i] = max;
				max = Math.Max(max, nums[i]);
				rightMin[^(i + 1)] = min;
				min = Math.Min(min, nums[^(i + 1)]);
			}
			while (index < nums.Length && leftMax[index] > rightMin[index])
				index++;
			return index + 1;
		}
	}
}
