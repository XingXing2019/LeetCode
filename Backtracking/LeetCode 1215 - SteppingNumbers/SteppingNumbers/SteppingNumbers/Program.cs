using System;
using System.Collections.Generic;
using System.Linq;

namespace SteppingNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int low = 0, high = 1000000000;
			Console.WriteLine(CountSteppingNumbers(low, high));
		}
		public static IList<int> CountSteppingNumbers(int low, int high)
		{
			var nums = new HashSet<int>();
			for (int i = 0; i < 10; i++)
				DFS(i, i, low, high, nums);
			var res = nums.ToList();
			res.Sort();
			return res;
		}

		public static void DFS(long num, int lastDigit, int low, int high, HashSet<int> nums)
		{
			if (num > high) return;
			if (num >= low)
				nums.Add((int)num);
			if (lastDigit != 9)
				DFS(num * 10 + lastDigit + 1, lastDigit + 1, low, high, nums);
			if (lastDigit != 0)
				DFS(num * 10 + lastDigit - 1, lastDigit - 1, low, high, nums);
		}
	}
}
