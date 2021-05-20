using System;

namespace ConsecutiveNumbersSum
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 15;
			Console.WriteLine(ConsecutiveNumbersSum(n));
		}
		public static int ConsecutiveNumbersSum(int n)
		{
			var res = 0;
			for (int i = 1; n > (i - 1) * i / 2; i++)
			{
				if ((n - (i - 1) * i / 2) % i == 0)
					res++;
			}
			return res;
		}
	}
}
