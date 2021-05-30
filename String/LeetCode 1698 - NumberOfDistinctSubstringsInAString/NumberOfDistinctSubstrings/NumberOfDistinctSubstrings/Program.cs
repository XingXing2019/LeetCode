using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberOfDistinctSubstrings
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		class TrieNode
		{
			public char letter;
			public TrieNode[] children;
			public TrieNode()
			{
				children = new TrieNode[26];
			}
		}
		public int CountDistinct(string s)
		{
			int res = 0;
			var root = new TrieNode();
			for (int i = 0; i < s.Length; i++)
			{
				var cur = root;
				for (int j = i; j < s.Length; j++)
				{
					if (cur.children[s[j] - 'a'] == null)
					{
						res++;
						cur.children[s[j] - 'a'] = new TrieNode();
					}
					cur = cur.children[s[j] - 'a'];
				}
			}
			return res;
		}
	}
}
