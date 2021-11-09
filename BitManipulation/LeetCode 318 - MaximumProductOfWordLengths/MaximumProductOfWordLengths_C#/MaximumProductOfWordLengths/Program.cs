using System;

namespace MaximumProductOfWordLengths
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MaxProduct(string[] words)
		{
			var res = 0;
			for (int i = 0; i < words.Length; i++)
			{
				for (int j = i + 1; j < words.Length; j++)
				{
					if (Check(words[i], words[j]))
						res = Math.Max(res, words[i].Length * words[j].Length);
				}
			}
			return res;
		}

		public bool Check(string s1, string s2)
		{
			var letter = new int[26];
			foreach (var l in s1)
				letter[l - 'a']++;
			foreach (var l in s2)
			{
				if (letter[l - 'a'] != 0)
					return false;
			}
			return true;
		}
	}
}
