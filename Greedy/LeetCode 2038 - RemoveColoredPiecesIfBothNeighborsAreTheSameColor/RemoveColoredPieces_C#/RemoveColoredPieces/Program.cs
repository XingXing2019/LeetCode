using System;

namespace RemoveColoredPieces
{
	class Program
	{
		static void Main(string[] args)
		{
			var colors = "AAAABBBB";
			Console.WriteLine(WinnerOfGame(colors));
		}
		public static bool WinnerOfGame(string colors)
		{
			colors += '#';
			return CountChance(colors, 'A') > CountChance(colors, 'B');
		}

		private static int CountChance(string colors, char target)
		{
			int res = 0, count = 0;
			foreach (var c in colors)
			{
				if (c == target)
					count++;
				else
				{
					if (count >= 3)
						res += count - 2;
					count = 0;
				}
			}
			return res;
		}
	}
}
