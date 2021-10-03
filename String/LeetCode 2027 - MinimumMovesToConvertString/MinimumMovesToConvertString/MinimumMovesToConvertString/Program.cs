using System;

namespace MinimumMovesToConvertString
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int MinimumMoves(string s)
		{
			int res = 0, index = 0;
			while (index < s.Length)
			{
				if (s[index] == 'O')
					index++;
				else
				{
					if (s.Substring(index, Math.Min(3, s.Length - index)).Contains('X'))
						res++;
					index += 3;
				}
			}
			return res;
		}
	}
}
