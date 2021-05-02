using System;
using System.Reflection.Metadata.Ecma335;

namespace SplittingAString
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = "99999999999999999999";
			Console.WriteLine(decimal.Parse(s));
		}

		public static bool SplitString(string s)
		{
			return DFS(s, "0", s.Length);
		}

		public static bool DFS(string s, string last, int len)
		{
			if (s.Length == 0 && last.Length != len) return true;
			string num = "";
			for (int i = 0; i < s.Length; i++)
			{
				num += s[i];
				if (s.Length != len && decimal.Parse(num) - decimal.Parse(last) > 1) return false;
				if (s.Length == len || decimal.Parse(last) - decimal.Parse(num) == 1)
				{
					if (DFS(s.Substring(i + 1), num, len))
						return true;
				}
			}
			return false;
		}
	}
}
