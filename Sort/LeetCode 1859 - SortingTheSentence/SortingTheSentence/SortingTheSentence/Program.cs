using System;
using System.Linq;

namespace SortingTheSentence
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string SortSentence(string s)
		{
			return string.Join(" ", s.Split(" ").OrderBy(x => x[^1]).Select(x => x.Substring(0, x.Length - 1)));
		}
	}
}
