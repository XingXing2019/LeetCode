using System;

namespace MaximumAlternatingSubarraySum
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public long MaximumAlternatingSubarraySum(int[] nums)
		{
			var even = new long[nums.Length];
			var odd = new long[nums.Length];
			odd[0] = nums[0];
			long res = odd[0];
			for (int i = 1; i < nums.Length; i++)
			{
				even[i] = odd[i - 1] - nums[i];
				odd[i] = Math.Max(nums[i], even[i - 1] + nums[i]);
				res = Math.Max(res, Math.Max(odd[i], even[i]));
			}
			return res;
		}
	}
}
