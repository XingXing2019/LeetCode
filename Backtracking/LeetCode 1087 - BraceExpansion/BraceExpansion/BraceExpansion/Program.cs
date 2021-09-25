using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace BraceExpansion
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public static string[] Expand(string s)
		{
			var res = new List<string>();
			DFS(s, "", res);
			return res.OrderBy(x => x).ToArray();
		}

		public static void DFS(string s, string path, List<string> res)
		{
			if (s.Length == 0)
			{
				res.Add(path);
				return;
			}
			if (s.StartsWith('{'))
			{
				var index = s.IndexOf('}');
				var letters = s.Substring(1, index - 1).Split(',');
				foreach (var letter in letters)
					DFS(s.Substring(index + 1), path + letter, res);
			}
			else
				DFS(s.Substring(1), path + s[0], res);
		}
	}
}
