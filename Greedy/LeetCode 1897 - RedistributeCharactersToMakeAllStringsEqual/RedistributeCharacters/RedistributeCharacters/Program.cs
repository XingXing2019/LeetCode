using System;
using System.Linq;

namespace RedistributeCharacters
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public bool MakeEqual(string[] words)
		{
			var letters = new int[26];
			foreach (var word in words)
			{
				foreach (var letter in word)
					letters[letter - 'a']++;
			}
			return letters.All(x => x % words.Length == 0);
		}
	}
}
