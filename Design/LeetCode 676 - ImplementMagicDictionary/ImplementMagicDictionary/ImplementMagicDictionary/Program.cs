using System;
using System.Collections.Generic;

namespace ImplementMagicDictionary
{
	class Program
	{
		static void Main(string[] args)
		{
			var dict = new MagicDictionary();
			string[] dictionary = { "hello", "leetcode" };
			dict.BuildDict(dictionary);
			//Console.WriteLine(dict.Search("hello"));
			Console.WriteLine(dict.Search("hhllo"));
			Console.WriteLine(dict.Search("hell"));
			Console.WriteLine(dict.Search("leetcoded"));
		}
	}

	public class MagicDictionary
	{
		private Dictionary<int, List<string>> dict;
		public MagicDictionary()
		{
			dict = new Dictionary<int, List<string>>();
		}

		public void BuildDict(string[] dictionary)
		{
			foreach (var word in dictionary)
			{
				if (!dict.ContainsKey(word.Length))
					dict[word.Length] = new List<string>();
				dict[word.Length].Add(word);
			}
		}

		public bool Search(string searchWord)
		{
			if (!dict.ContainsKey(searchWord.Length))
				return false;
			foreach (var word in dict[searchWord.Length])
			{
				if (Match(word, searchWord))
					return true;
			}
			return false;
		}

		private bool Match(string word, string searchWord)
		{
			int diff = 0;
			for (int i = 0; i < word.Length; i++)
			{
				if (word[i] != searchWord[i])
					diff++;
				if (diff > 1) return false;
			}
			return diff == 1;
		}
	}
}
