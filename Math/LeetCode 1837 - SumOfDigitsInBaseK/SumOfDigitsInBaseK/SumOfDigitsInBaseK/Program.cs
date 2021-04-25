using System;

namespace SumOfDigitsInBaseK
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int SumBase(int n, int k)
		{
			int res = 0;
			while (n != 0)
			{
				res += n % k;
				n /= k;
			}
			return res;
		}
	}
}
