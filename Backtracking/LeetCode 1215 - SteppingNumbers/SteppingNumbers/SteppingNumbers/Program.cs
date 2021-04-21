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
			var res = new List<int>();
			if (low == 0) res.Add(0);
			for (int i = 1; i < 10; i++)
				DFS(i, low, high, res);
			res.Sort();
			return res;
		}

		public static void DFS(long num, int low, int high, List<int> res)
		{
			if (num > high) return;
			if (num >= low && num <= high)
				res.Add((int)num);
			var lastDigit = num % 10;
			if (lastDigit != 9)
				DFS(num * 10 + lastDigit + 1, low, high, res);
			if (lastDigit != 0)
				DFS(num * 10 + lastDigit - 1, low, high, res);
		}
	}
}
