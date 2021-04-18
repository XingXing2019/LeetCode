using System;

namespace MaximumXORForEachQuery
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = {2, 3, 4, 7};
			int maximumBit = 3;
			Console.WriteLine(GetMaximumXor(nums, maximumBit));
		}
		public static int[] GetMaximumXor(int[] nums, int maximumBit)
		{
			var res = new int[nums.Length];
			for (int i = 1; i < nums.Length; i++)
				nums[i] ^= nums[i - 1];
			for (int i = 0; i < res.Length; i++)
			{
				int temp = 0;
				for (int j = 0; j < maximumBit; j++)
				{
					temp <<= 1;
					temp += (nums[i] & 1) ^ 1;
					nums[i] >>= 1;
				}
				for (int j = 0; j < maximumBit; j++)
				{
					res[^(i + 1)] <<= 1;
					res[^(i + 1)] += temp & 1;
					temp >>= 1;
				}
			}
			return res;
		}
	}
}
