using System;

namespace ReversePrefixOfWord
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public string ReversePrefix(string word, char ch)
		{
			int index = word.IndexOfAny(new []{ch});
			if (index == -1) return word;
			var res = "";
			for (int i = index; i >= 0; i--)
				res += word[i];
			return res + word.Substring(index + 1);
		}
	}
}
