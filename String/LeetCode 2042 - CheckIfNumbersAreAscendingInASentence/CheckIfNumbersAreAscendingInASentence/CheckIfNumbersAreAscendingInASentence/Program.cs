using System;

namespace CheckIfNumbersAreAscendingInASentence
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool AreNumbersAscending(string s)
		{
			var tokens = s.Split(" ");
			int start = 0;
			foreach (var token in tokens)
			{
				if(!int.TryParse(token, out var num))
					continue;
				if (num <= start)
					return false;
				start = num;
			}
			return true;
		}
	}
}
