using System;

namespace MinimumNonZeroProduct
{
	class Program
	{
		static void Main(string[] args)
		{
			int p = 38;
			Console.WriteLine(MinNonZeroProduct(p));
		}

		public static int MinNonZeroProduct(int p)
		{
			if (p == 1) return 1;
			long max = (long)Math.Pow(2, p) - 1;
			long mod = 1_000_000_000 + 7;
			var num = max - 1;
			var n = max / 2;
			return (int)(max * ModPow(num, n, mod) % mod);
		}

		public static decimal ModPow(long num, long n, long mod)
		{
			if (n == 0) return 1;
			var pow = ModPow(num, n / 2, mod);
			var temp = pow * pow % mod;
			if (n % 2 == 0)
				return temp;
			return temp * num % mod;
		}
	}
}
