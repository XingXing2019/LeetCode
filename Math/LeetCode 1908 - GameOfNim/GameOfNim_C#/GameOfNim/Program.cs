using System;

namespace GameOfNim
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool NimGame(int[] piles)
		{
			int xOr = 0;
			foreach (var pile in piles)
				xOr ^= pile;
			return xOr != 0;
		}
	}
}
