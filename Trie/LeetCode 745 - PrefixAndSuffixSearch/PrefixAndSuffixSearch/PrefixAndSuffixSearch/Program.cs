using System;
using System.Collections.Generic;

namespace PrefixAndSuffixSearch
{
	class Program
	{
		static void Main(string[] args)
		{
			var filter = new WordFilter(new[] { "cabaabaaaa", "ccbcababac", "bacaabccba", "bcbbcbacaa", "abcaccbcaa" });
			Console.WriteLine(filter.F("bccbacbcba", "a"));
			Console.WriteLine(filter.F("ab", "abcaccbcaa"));
		}
		public class WordFilter
		{
			class Trie
			{
				public Trie[] children;
				public List<int> words;
				public HashSet<int> set;
				public Trie()
				{
					children = new Trie[26];
					words = new List<int>();
					set = new HashSet<int>();
				}
			}

			private Trie prefixRoot;
			private Trie suffixRoot;
			private Dictionary<string, int> cache;
			public WordFilter(string[] words)
			{
				prefixRoot = new Trie();
				suffixRoot = new Trie();
				cache = new Dictionary<string, int>();
				for (int i = 0; i < words.Length; i++)
				{
					var point = prefixRoot;
					for (int j = 0; j < words[i].Length; j++)
					{
						if (point.children[words[i][j] - 'a'] == null)
							point.children[words[i][j] - 'a'] = new Trie();
						point = point.children[words[i][j] - 'a'];
						point.words.Add(i);
						point.set.Add(i);
					}
					point = suffixRoot;
					for (int j = words[i].Length - 1; j >= 0 ; j--)
					{
						if (point.children[words[i][j] - 'a'] == null)
							point.children[words[i][j] - 'a'] = new Trie();
						point = point.children[words[i][j] - 'a'];
						point.words.Add(i);
						point.set.Add(i);
					}
				}
			}

			public int F(string prefix, string suffix)
			{
				if (cache.ContainsKey($"{prefix}:{suffix}"))
					return cache[$"{prefix}:{suffix}"];
				var point = prefixRoot;
				for (int i = 0; i < prefix.Length; i++)
				{
					if (point.children[prefix[i] - 'a'] == null)
						return -1;
					point = point.children[prefix[i] - 'a'];
				}
				var prefixWords = point.words;
				point = suffixRoot;
				for (int i = suffix.Length - 1; i >= 0; i--)
				{
					if (point.children[suffix[i] - 'a'] == null)
						return -1;
					point = point.children[suffix[i] - 'a'];
				}
				var suffixWords = point.set;
				for (int i = prefixWords.Count - 1; i >= 0; i--)
				{
					if (!suffixWords.Contains(prefixWords[i])) continue;
					cache[$"{prefix}:{suffix}"] = prefixWords[i];
					return prefixWords[i];
				}
				return -1;
			}
		}
	}
}
