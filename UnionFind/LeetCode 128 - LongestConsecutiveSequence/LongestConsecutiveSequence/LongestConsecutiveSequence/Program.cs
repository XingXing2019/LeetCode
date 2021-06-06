using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestConsecutiveSequence
{
	class Program
	{
		static void Main(string[] args)
		{

		}

		private Dictionary<int, int> parents = new Dictionary<int, int>();
		private Dictionary<int, int> rank = new Dictionary<int, int>();
		public int LongestConsecutive_UnionFind(int[] nums)
		{
			foreach (var num in nums)
			{
				parents[num] = num;
				rank[num] = 0;
			}
			var set = new HashSet<int>(nums);
			foreach (var num in set)
			{
				if (set.Contains(num + 1))
					Merge(num, num + 1);
				if (set.Contains(num - 1))
					Merge(num, num - 1);
			}
			foreach (var num in set)
				parents[num] = Find(num);
			var roots = new Dictionary<int, int>();
			int res = 0;
			foreach (var p in parents)
			{
				if (!roots.ContainsKey(p.Value))
					roots[p.Value] = 0;
				roots[p.Value]++;
				res = Math.Max(res, roots[p.Value]);
			}
			return res;
		}

		private int Find(int x)
		{
			if (parents[x] != x)
				parents[x] = Find(parents[x]);
			return parents[x];
		}

		private bool Merge(int x, int y)
		{
			int rootX = Find(x), rootY = Find(y);
			if (rootX == rootY) return false;
			if (rank[rootX] >= rank[rootY])
			{
				parents[rootY] = rootX;
				if (rank[rootX] == rank[rootY])
					rank[rootX]++;
			}
			else
				parents[rootX] = rootY;
			return true;
		}

		public int LongestConsecutive_Set(int[] nums)
		{
			if (nums.Length == 0) return 0;
			var set = new HashSet<int>(nums);
			int res = 1;
			foreach (var num in set)
			{
				if (!set.Contains(num - 1))
				{
					var cur = num;
					while (set.Contains(cur))
						cur++;
					res = Math.Max(res, cur - num);
				}
			}
			return res;
		}

		public int LongestConsecutive_Sort(int[] nums)
		{
			if (nums.Length == 0) return 0;
			var set = new HashSet<int>(nums);
			var sorted = set.OrderBy(x => x).ToArray();
			int li = 0, hi = 1, res = 0;
			while (hi < sorted.Length)
			{
				if (sorted[hi] != sorted[hi - 1] + 1)
				{
					res = Math.Max(res, hi - li);
					li = hi;
				}
				hi++;
			}
			res = Math.Max(res, hi - li);
			return res;
		}
	}
}
