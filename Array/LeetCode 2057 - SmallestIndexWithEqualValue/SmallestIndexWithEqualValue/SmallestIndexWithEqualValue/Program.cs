using System;

namespace SmallestIndexWithEqualValue
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int SmallestEqual(int[] nums)
		{
			for (int i = 0; i < nums.Length; i++)
			{
				if (i % 10 == nums[i])
					return i;
			}
			return -1;
		}
	}
}
