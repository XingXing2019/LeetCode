using System;

namespace SumGame
{
	class Program
	{
		static void Main(string[] args)
		{
			var num = "1999??";
			Console.WriteLine(SumGame(num));
		}

		public static bool SumGame(string num)
		{
			int sumDiff = 0, markDiff = 0;
			for (int i = 0; i < num.Length; i++)
			{
				if (i < num.Length / 2)
				{
					if (num[i] == '?') markDiff++;
					else sumDiff += num[i] - '0';
				}
				else
				{
					if (num[i] == '?') markDiff--;
					else sumDiff -= num[i] - '0';
				}
			}
			if (sumDiff == 0 && markDiff == 0) return false;
			int bob = -markDiff / 2, alice = -markDiff - bob;
			if (bob == 0) return true;
			int left = sumDiff - alice * 9;
			return left / bob < 0 || left / bob > 9 || sumDiff / bob < 0 || sumDiff / bob > 9;
		}
	}
}
