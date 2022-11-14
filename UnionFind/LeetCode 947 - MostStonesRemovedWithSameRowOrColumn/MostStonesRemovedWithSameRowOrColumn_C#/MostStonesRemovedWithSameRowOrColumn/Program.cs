using System;
using System.Collections.Generic;

namespace MostStonesRemovedWithSameRowOrColumn
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] stones = 
			{
				new[] {0, 0},
				new[] {0, 2},
				new[] {1, 1},
				new[] {2, 0},
				new[] {2, 2},
			};
		}

		private int[] parents;
		private int[] rank;
		public int RemoveStones(int[][] stones)
		{
			parents = new int[stones.Length];
			for (int i = 0; i < parents.Length; i++)
				parents[i] = i;
			rank = new int[stones.Length];
			int left = stones.Length;
			var dict = new Dictionary<int[], int>();
			for (int i = 0; i < stones.Length; i++)
				dict.Add(stones[i], i);
			var graph = new List<int>[stones.Length];
			for (int i = 0; i < graph.Length; i++)
				graph[i] = new List<int>();
			for (int i = 0; i < stones.Length; i++)
			{
				for (int j = i + 1; j < stones.Length; j++)
				{
					if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
						graph[i].Add(j);
				}
			}
			for (int i = 0; i < graph.Length; i++)
			{
				var cur = i;
				foreach (var next in graph[i])
				{
					if (Merge(cur, next))
						left--;
				}
			}
			return stones.Length - left;
		}

		public int Find(int x)
		{
			if (parents[x] != x)
				parents[x] = Find(parents[x]);
			return parents[x];
		}

		public bool Merge(int x, int y)
		{
			int rootX = Find(x), rootY = Find(y);
			if (rootX == rootY) return false;
			if (rank[rootX] > rank[rootY]) parents[rootY] = rootX;
			else if (rank[rootX] > rank[rootY]) parents[rootX] = rootY;
			else
			{
				parents[rootY] = rootX;
				rank[rootX]++;
			}
			return true;
		}
	}
}
