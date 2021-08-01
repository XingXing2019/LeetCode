using System;

namespace ThreeDivisors
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 79;
			Console.WriteLine(IsThree(n));
		}
		public static bool IsThree(int n)
		{
			if (n == 1 || (int)Math.Sqrt(n) * (int)Math.Sqrt(n) != n)
				return false;
			for (int i = 2; i < Math.Sqrt(n); i++)
			{
				if (n % i == 0)
					return false;
			}
			return true;
		}
	}
}
