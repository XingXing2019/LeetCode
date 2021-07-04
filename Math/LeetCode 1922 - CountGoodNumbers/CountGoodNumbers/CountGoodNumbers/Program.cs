using System;

namespace CountGoodNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(CountGoodNumbers(31));
		}
		public static int CountGoodNumbers(long n)
		{
			int mod = 1_000_000_000 + 7;
			return (int)(ModPow(4, n / 2, mod) * ModPow(5, (n + 1) / 2, mod) % mod);
		}

		private static long ModPow(long x, long y, long mod)
		{
			if (y == 0) return 1;
			var pow = ModPow(x, y / 2, mod);
			return pow * pow * (y % 2 == 0 ? 1 : x) % mod;
		}
	}
}
