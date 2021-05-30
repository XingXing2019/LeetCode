using System;

namespace SubstringsOfSizeThree
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CountGoodSubstrings(string s)
		{
			if (s.Length < 3) return 0;
			var res = 0;
			for (int i = 0; i <= s.Length - 3; i++)
			{
				if (s[i] != s[i + 1] && s[i] != s[i + 2] && s[i + 1] != s[i + 2])
					res++;
			}
			return res;
		}
	}
}
