using System;
using System.Linq;

namespace FindMissingObservations
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int[] MissingRolls(int[] rolls, int mean, int n)
		{
			int sum = mean * (n + rolls.Length) - rolls.Sum();
			if (sum < n || sum > 6 * n)
				return new int[0];
			var res = new int[n];
			var avg = sum / n;
			var gap = sum - avg * n;
			for (int i = 0; i < n; i++)
				res[i] = i < n - gap ? avg : avg + 1;
			return res;
		}
	}
}
