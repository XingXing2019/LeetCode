using System;

namespace MinimumTimeToTypeWord
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinTimeToType(string word)
		{
			int res = 0;
			char cur = 'a';
			foreach (var letter in word)
			{
				if(letter > cur)
					res += Math.Min(letter - cur, cur + 26 - letter);
				else
					res += Math.Min(cur - letter, letter + 26 - cur);
				cur = letter;
			}
			return res + word.Length;
		}
	}
}
