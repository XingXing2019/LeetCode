using System;
using System.Linq;

namespace MaximumNumberOfWordsYouCanType
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CanBeTypedWords(string text, string brokenLetters)
		{
			return text.Split(' ').Count(x => !x.Any(y => brokenLetters.Contains(y)));
		}
	}
}
