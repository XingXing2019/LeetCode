using System;
using System.Linq;

namespace FrequencyOfTheMostFrequentElement
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { 1, 2, 4, 4, 2, 1, 2, 3, 4, 5, 2, 1 };
			int k = 7;
			Console.WriteLine(MaxFrequency(nums, k));
		}
		public static int MaxFrequency(int[] nums, int k)
		{
			Array.Sort(nums);
			int li = 0, hi = 0, res = 0;
			long sum = 0;
			while (hi < nums.Length)
			{
				sum += nums[hi];
				while (sum + k < (long)nums[hi] * (hi - li + 1))
					sum -= nums[li++];
				res = Math.Max(res, hi - li + 1);
				hi++;
			}
			return res;
		}
	}
}
