using System;
using System.Text;

namespace RemoveAllOccurrencesOfASubstring
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string RemoveOccurrences(string s, string part)
		{
			var str = new StringBuilder();
			foreach (var l in s)
			{
				str.Append(l);
				if (str.Length < part.Length) continue;
				if (str.ToString(str.Length - part.Length, part.Length) == part)
					str.Remove(str.Length - part.Length, part.Length);
			}
			return str.ToString();
		}
	}
}
