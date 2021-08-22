using System;
using System.Linq;

namespace FindGreatestCommonDivisorOfArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int FindGCD(int[] nums)
		{
			return GCD(nums.Max(), nums.Min());
		}

		public int GCD(int num1, int num2)
		{
			return num1 % num2 == 0 ? num2 : GCD(num2, num1 % num2);
		}
	}
}
