using System;
using System.Linq;

namespace LongestWordWithAllPrefixes
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] words = { "a", "e" };
			Console.WriteLine(LongestWord(words));
		}

		class Node
		{
			public Node[] children;
			public Node()
			{
				children = new Node[26];
			}
		}
		public static string LongestWord(string[] words)
		{
			var root = new Node();
			var res = "";
			words = words.OrderBy(x => x.Length).ThenByDescending(x => x).ToArray();
			foreach (var word in words)
			{
				var pointer = root;
				var hasPrefix = true;
				for (int i = 0; i < word.Length; i++)
				{
					if (i != word.Length - 1 && pointer.children[word[i] - 'a'] == null)
					{
						hasPrefix = false;
						break;
					}
					if (i == word.Length - 1)
						pointer.children[word[i] - 'a'] = new Node();
					pointer = pointer.children[word[i] - 'a'];
				}
				if (!hasPrefix) continue;
				if (words.Length >= res.Length) 
					res = word;
			}
			return res;
		}
	}
}
