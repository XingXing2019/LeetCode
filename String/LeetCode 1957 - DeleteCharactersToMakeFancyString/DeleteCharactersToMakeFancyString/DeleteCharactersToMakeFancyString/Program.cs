using System;
using System.Text;

namespace DeleteCharactersToMakeFancyString
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string MakeFancyString(string s)
		{
			var res = new StringBuilder();
			int count = 0;
			char character = s[0];
			foreach (var c in s)
			{
				if (c == character)
					count++;
				else
				{
					character = c;
					count = 1;
				}
				if (count < 3)
					res.Append(c);
			}
			return res.ToString();
		}
	}
}
