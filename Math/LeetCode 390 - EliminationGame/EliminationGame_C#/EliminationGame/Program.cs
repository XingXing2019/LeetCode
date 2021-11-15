using System;

namespace EliminationGame
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int LastRemaining(int n)
		{
			int gap = 1, first = 1, round = 1;
			while (n != 1)
			{
				if (round % 2 != 0 || n % 2 != 0)
					first += gap;
				gap *= 2;
				round++;
				n /= 2;
			}
			return first;
		}
	}
}
