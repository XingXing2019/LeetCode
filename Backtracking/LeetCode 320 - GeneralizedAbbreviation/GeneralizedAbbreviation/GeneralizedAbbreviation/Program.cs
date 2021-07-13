using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralizedAbbreviation
{
	class Program
	{
		static void Main(string[] args)
		{
			var word = "asdasdasda";
			Console.WriteLine(GenerateAbbreviations(word));
		}
		public static IList<string> GenerateAbbreviations(string word)
		{
			var res = new List<string>();
			DFS(word, 0, new StringBuilder(), res);
			return res;
		}

		public static void DFS(string word, int start, StringBuilder path, List<string> res)
		{
			if (start == word.Length)
			{
				res.Add(path.ToString());
				return;
			}
			path.Append(word[start]);
			DFS(word, start + 1, path, res);
			path.Remove(path.Length - 1, 1);
			if (path.Length == 0 || !char.IsDigit(path[^1]))
			{
				for (int i = start; i < word.Length; i++)
				{
					var num = (word.Length - i).ToString();
					path.Append(num);
					DFS(word, start + word.Length - i, path, res);
					path.Remove(path.Length - num.Length, num.Length);
				}
			}
		}
	}
}
