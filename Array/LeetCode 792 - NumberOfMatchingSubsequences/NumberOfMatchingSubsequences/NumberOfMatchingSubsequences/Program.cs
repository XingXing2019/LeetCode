using System;
using System.Collections.Generic;
using System.Text;

namespace NumberOfMatchingSubsequences
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = "abcde";
			string[] words = {"a", "bb", "acd", "ace"};
			Console.WriteLine(NumMatchingSubseq(s, words));
		}
		public static int NumMatchingSubseq(string s, string[] words)
		{
			var record = new List<StringBuilder>[26];
			for (int i = 0; i < record.Length; i++)
				record[i] = new List<StringBuilder>();
			int res = 0;
			foreach (var word in words)
				record[word[0] - 'a'].Add(new StringBuilder(word));
			foreach (var l in s)
			{
				var temp = record[l - 'a'];
				record[l - 'a'] = new List<StringBuilder>();
				foreach (var word in temp)
				{
					word.Remove(0, 1);
					if (word.Length == 0) 
						res++;
					else
						record[word[0] - 'a'].Add(word);
				}
			}
			return res;
		}
	}
}
