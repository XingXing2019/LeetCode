using System;
using System.Collections.Generic;
using System.Linq;

namespace CountVowelSubstringsOfAString
{
	class Program
	{
		static void Main(string[] args)
		{
			var word = "aeiouu";
			Console.WriteLine(CountVowelSubstrings(word));
		}

		public static int CountVowelSubstrings(string word)
		{
			var res = 0;
			var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
			for (int i = 0; i < word.Length; i++)
			{
				if (!vowels.Contains(word[i])) continue;
				var dict = new Dictionary<char, int>();
				foreach (var vowel in vowels)
					dict[vowel] = 0;
				for (int j = i; j < word.Length && vowels.Contains(word[j]); j++)
				{
					if (dict.All(x => x.Value > 0)) res++;
					dict[word[j]]++;
				}
				if (dict.All(x => x.Value > 0)) res++;
			}
			return res;
		}
	}
}
