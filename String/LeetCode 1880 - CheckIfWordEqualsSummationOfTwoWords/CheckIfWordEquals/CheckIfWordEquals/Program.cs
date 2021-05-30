using System;
using System.Collections.Generic;

namespace CheckIfWordEquals
{
	class Program
	{
		static void Main(string[] args)
		{
			string firstWord = "aaa", secondWord = "a", targetWord = "aaaa";
			Console.WriteLine(IsSumEqual(firstWord, secondWord, targetWord));
		}
		public static bool IsSumEqual(string firstWord, string secondWord, string targetWord)
		{
			int num1 = 0, num2 = 0, num3 = 0;
			foreach (var l in firstWord)
				num1 = num1 * 10 + (l - 'a');
			foreach (var l in secondWord)
				num2 = num2 * 10 + (l - 'a');
			foreach (var l in targetWord)
				num3 = num3 * 10 + (l - 'a');
			return num1 + num2 == num3;
		}
	}
}
