using System;

namespace ConcatenationOfArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int[] GetConcatenation(int[] nums)
		{
			var res = new int[nums.Length * 2];
			for (int i = 0; i < res.Length; i++)
				res[i] = nums[i % nums.Length];
			return res;
		}
	}
}
