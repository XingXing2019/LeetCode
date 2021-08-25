using System;

namespace SumOfSquareNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int c = 1000;
			Console.WriteLine(JudgeSquareSum(c));
		}
		public static bool JudgeSquareSum(int c)
		{
			for (int i = 0; i <= Math.Sqrt(c); i++)
			{
				int num = (int) Math.Sqrt(c - i * i);
				if (num * num == c - i * i)
					return true;
			}
			return false;
		}
	}
}
