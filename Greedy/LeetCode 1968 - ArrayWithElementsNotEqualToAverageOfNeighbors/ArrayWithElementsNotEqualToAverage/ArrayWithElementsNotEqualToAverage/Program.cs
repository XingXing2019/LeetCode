using System;

namespace ArrayWithElementsNotEqualToAverage
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int[] RearrangeArray(int[] nums)
		{
			Array.Sort(nums);
			var res = new int[nums.Length];
			int li = 0, hi = nums.Length - 1, index = 0;
			while (li <= hi)
			{
				res[index++] = nums[li++];
				if (li > hi) break;
				res[index++] = nums[hi--];
			}
			return res;
		}
	}
}
