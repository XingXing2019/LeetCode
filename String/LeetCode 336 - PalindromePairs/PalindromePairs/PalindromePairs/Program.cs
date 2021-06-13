using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PalindromePairs
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] words = { "a", "" };
			Console.WriteLine(PalindromePairs(words));
		}
		public static IList<IList<int>> PalindromePairs(string[] words)
		{
			var res = new List<IList<int>>();
			var dict = new Dictionary<string, int>();
			var palindromes = new List<int>();
			for (int i = 0; i < words.Length; i++)
			{
				if (IsPalindrome(words[i]))
					palindromes.Add(i);
				var reversed = words[i].ToCharArray().Reverse();
				dict.Add(string.Join("", reversed), i);
			}
			for (int i = 0; i < words.Length; i++)
			{
				if (words[i] == "")
					res.AddRange(palindromes.Where(x => x != i).Select(x => new List<int> { i, x }));
				for (int j = 0; j < words[i].Length; j++)
				{
					var left = words[i].Substring(0, j);
					var right = words[i].Substring(j);
					if (dict.ContainsKey(right) && dict[right] != i && IsPalindrome(left))
						res.Add(new List<int> { dict[right], i });
					if (dict.ContainsKey(left) && dict[left] != i && IsPalindrome(right))
						res.Add(new List<int> { i, dict[left] });
				}
			}
			return res;
		}

		private static bool IsPalindrome(string str)
		{
			int li = 0, hi = str.Length - 1;
			while (li < hi)
			{
				if (str[li++] != str[hi--])
					return false;
			}
			return true;
		}
	}
}
