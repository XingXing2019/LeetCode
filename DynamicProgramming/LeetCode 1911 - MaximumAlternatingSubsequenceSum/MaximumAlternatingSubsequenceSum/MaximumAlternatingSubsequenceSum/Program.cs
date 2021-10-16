using System;

namespace MaximumAlternatingSubsequenceSum
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public long MaxAlternatingSum(int[] nums)
		{
			long[] even = new long[nums.Length], odd = new long[nums.Length];
			odd[0] = nums[0];
			long maxEven = 0, maxOdd = odd[0], res = odd[0];
			for (int i = 1; i < nums.Length; i++)
			{
				even[i] = maxOdd - nums[i];
				odd[i] = Math.Max(nums[i], maxEven + nums[i]);
				res = Math.Max(res, Math.Max(odd[i], even[i]));
				maxOdd = Math.Max(maxOdd, odd[i]);
				maxEven = Math.Max(maxEven, even[i]);
			}
			return res;
		}
	}
}
