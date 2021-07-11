using System;
using System.Collections.Generic;

namespace UniqueLength3PalindromicSubsequences
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int CountPalindromicSubsequence(string s)
		{
			var dict = new Dictionary<char, int[]>();
			for (int i = 0; i < s.Length; i++)
			{
				if (!dict.ContainsKey(s[i]))
					dict[s[i]] = new[] {i, -1};
			}
			for (int i = s.Length - 1; i >= 0; i--)
			{
				if (dict[s[i]][1] == -1)
					dict[s[i]][1] = i;
			}
			int res = 0;
			foreach (var letter in dict)
			{
				var set = new HashSet<char>();
				for (int i = letter.Value[0] + 1; i < letter.Value[1]; i++)
					set.Add(s[i]);
				res += set.Count;
			}
			return res;
		}
	}
}
