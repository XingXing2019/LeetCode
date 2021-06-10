using System;
using System.Collections.Generic;

namespace UniqueWordAbbreviation
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
	public class ValidWordAbbr
	{
		private Dictionary<string, HashSet<string>> dict;
		public ValidWordAbbr(string[] dictionary)
		{
			dict = new Dictionary<string, HashSet<string>>();
			foreach (var word in dictionary)
			{
				var abbr = GetAbbreviation(word);
				if (!dict.ContainsKey(abbr))
					dict[abbr] = new HashSet<string>();
				dict[abbr].Add(word);
			}
		}

		public bool IsUnique(string word)
		{
			var abbr = GetAbbreviation(word);
			if (!dict.ContainsKey(abbr))
				return true;
			return dict[abbr].Count == 1 && dict[abbr].Contains(word);
		}

		private string GetAbbreviation(string word)
		{
			var count = word.Length - 2 <= 0 ? "" : (word.Length - 2).ToString();
			return $"{word[0]}{count}{word[^1]}";
		}
	}
}
