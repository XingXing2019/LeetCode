using System;
using System.Text;

namespace ReplaceAllDigitsWithCharacters
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string ReplaceDigits(string s)
		{
			var str = new StringBuilder(s);
			for (int i = 1; i < str.Length; i += 2)
				str[i] = (char) (str[i - 1] + str[i] - '0');
			return str.ToString();
		}
	}
}
