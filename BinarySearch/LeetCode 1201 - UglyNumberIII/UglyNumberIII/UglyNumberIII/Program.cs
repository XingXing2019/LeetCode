using System;

namespace UglyNumberIII
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 4, a = 6, b = 3, c = 4;
			Console.WriteLine(NthUglyNumber(n, a, b, c));
		}
		public static int NthUglyNumber(int n, int a, int b, int c)
		{
			long lcmAB = LCM(a, b), lcmAC = LCM(a, c), lcmBC = LCM(b, c), lcmABC = LCM(lcmAB, c);
			long li = 0, hi = int.MaxValue;
			while (li <= hi)
			{
				long mid = li + (hi - li) / 2;
				long count = mid / a + mid / b + mid / c - mid / lcmAB - mid / lcmAC - mid / lcmBC + mid / lcmABC;
				if (count < n) li = mid + 1;
				else hi = mid - 1;
			}
			return (int)li;
		}

		public static long GCD(long num1, long num2)
		{
			if (num2 == 0) return num1;
			return GCD(num2, num1 % num2);
		}

		public static long LCM(long num1, long num2)
		{
			return num1 * num2 / GCD(num1, num2);
		}
	}
}
