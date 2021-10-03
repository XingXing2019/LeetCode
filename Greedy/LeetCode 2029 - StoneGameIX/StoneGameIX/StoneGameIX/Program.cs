using System;
using System.Linq;

namespace StoneGameIX
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public bool StoneGameIX(int[] stones)
		{
			var freq = new int[3];
			foreach (var stone in stones)
				freq[stone % 3]++;
			if (freq[0] % 2 == 0)
				return freq[1] != 0 && freq[2] != 0;
			return Math.Abs(freq[1] - freq[2]) > 2;
		}
	}
}
