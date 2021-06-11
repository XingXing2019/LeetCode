using System;
using System.Linq;

namespace StoneGameVII
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int StoneGameVII(int[] stones)
		{
			var cache = new int[stones.Length][];
			for (int i = 0; i < cache.Length; i++)
			{
				cache[i] = new int[stones.Length];
				Array.Fill(cache[i], int.MaxValue);
			}
			return GetMaxDiff(cache, stones, 0, stones.Length - 1, stones.Sum());
		}

		private int GetMaxDiff(int[][] cache, int[] stones, int li, int hi, int sum)
		{
			if (li == hi) return 0;
			if (cache[li][hi] == int.MaxValue)
				cache[li][hi] = Math.Max(sum - stones[li] - GetMaxDiff(cache, stones, li + 1, hi, sum - stones[li]),
					sum - stones[hi] - GetMaxDiff(cache, stones, li, hi - 1, sum - stones[hi]));
			return cache[li][hi];
		}
	}
}
