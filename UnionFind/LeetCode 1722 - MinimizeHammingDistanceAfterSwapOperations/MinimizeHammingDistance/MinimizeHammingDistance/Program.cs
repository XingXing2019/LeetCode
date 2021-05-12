using System;
using System.Linq;
using System.Collections.Generic;

namespace MinimizeHammingDistance
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] source = { 1, 4, 5, 6, 7, 2, 8, 9, 10, 12, 11, 3, 15, 3 };
			int[] target = { 1, 16, 17, 18, 19, 13, 20, 21, 17, 22, 2, 19, 2, 23 };
			var allowedSwaps = new int[][]
			{
				new[] {0, 11},
				new[] {5, 9},
				new[] {6, 9},
				new[] {5, 7},
				new[] {3, 6},
				new[] {0, 4},
				new[] {0, 13},
			};
			MinimumHammingDistance(source, target, allowedSwaps);
		}

		private static int[] parents;
		private static int[] rank;
		public static int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
		{
			parents = new int[source.Length];
			for (int i = 0; i < parents.Length; i++)
				parents[i] = i;
			rank = new int[source.Length];
			foreach (var swap in allowedSwaps)
				Union(swap[0], swap[1]);
			for (int i = 0; i < parents.Length; i++)
				parents[i] = Find(parents[i]);
			int res = 0;
			var groups = new Dictionary<int, List<int>>();
			for (int i = 0; i < parents.Length; i++)
			{
				if (!groups.ContainsKey(parents[i]))
					groups[parents[i]] = new List<int>();
				groups[parents[i]].Add(i);
			}
			foreach (var group in groups)
			{
				var count = new Dictionary<int, int>();
				foreach (var index in group.Value)
				{
					if (!count.ContainsKey(source[index]))
						count[source[index]] = 0;
					count[source[index]]++;
					if (!count.ContainsKey(target[index]))
						count[target[index]] = 0;
					count[target[index]]--;
				}
				res += count.Sum(x => Math.Abs(x.Value)) / 2;
			}
			return res;
		}

		public static int Find(int x)
		{
			if (parents[x] == x)
				return x;
			parents[x] = Find(parents[x]);
			return parents[x];
		}

		public static void Union(int x, int y)
		{
			int rootX = Find(x), rootY = Find(y);
			if (rootX == rootY) return;
			if (rank[rootX] >= rank[rootY])
			{
				parents[rootY] = rootX;
				if (rank[rootX] == rank[rootY])
					rank[rootX]++;
			}
			else
				parents[rootX] = rootY;
		}

	}
}
