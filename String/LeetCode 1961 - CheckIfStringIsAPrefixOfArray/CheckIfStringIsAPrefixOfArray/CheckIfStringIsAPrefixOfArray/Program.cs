using System;

namespace CheckIfStringIsAPrefixOfArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool IsPrefixString(string s, string[] words)
		{
			var pattern = "";
			for (int i = 0; i < words.Length && pattern.Length < s.Length; i++)
				pattern += words[i];
			return s == pattern;
		}
	}
}
