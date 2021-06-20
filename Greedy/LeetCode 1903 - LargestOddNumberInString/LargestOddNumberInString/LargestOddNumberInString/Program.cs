using System;

namespace LargestOddNumberInString
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string LargestOddNumber(string num)
		{
			for (int i = num.Length - 1; i >= 0; i--)
			{
				if ((num[i] - '0') % 2 != 0)
					return num.Substring(0, i + 1);
			}
			return "";
		}
	}
}
