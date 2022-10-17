using System;
using System.Linq;

namespace CheckIfTheSentenceIsPangram
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool CheckIfPangram(string sentence)
		{
			var letters = new int[26];
			foreach (var l in sentence)
				letters[l - 'a']++;
			return letters.All(x => x > 0);
		}
	}
}
