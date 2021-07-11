using System;

namespace CountSquareSumTriples
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			Console.WriteLine(CountTriples(n));
		}

		public static int CountTriples(int n)
		{
			int res = 0;
			for (int a = 1; a <= n; a++)
			{
				for (int b = 1; b <= Math.Sqrt(n * n - a * a) ; b++)
				{
					var c = Math.Sqrt(a * a + b * b);
					if (c <= n && c == (int) c)
						res++;
				}
			}
			return res;
		}
	}
}
