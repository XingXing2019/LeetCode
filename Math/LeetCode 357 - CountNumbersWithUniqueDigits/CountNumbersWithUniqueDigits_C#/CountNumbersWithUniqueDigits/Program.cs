using System;

namespace CountNumbersWithUniqueDigits
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CountNumbersWithUniqueDigits(int n)
		{
			if (n == 0) return 1;
			int res = 10, start = 9, temp = 9;
			for (int i = 2; i <= n; i++)
			{
				temp *= start;
				res += temp;
				start--;
			}
			return res;
		}
	}
}
