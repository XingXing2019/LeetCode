using System;
using System.Collections.Generic;

namespace OperationsOnTree
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] parents = {-1, 0, 0, 1, 1, 2, 2};
			var tree = new LockingTree(parents);
		}
	}

	public class LockingTree
	{
		private Dictionary<int, List<int>> descendant;
		private Dictionary<int, List<int>> ancestors;
		private Dictionary<int, int> locker;
		public LockingTree(int[] parent)
		{
			descendant = new Dictionary<int, List<int>>();
			ancestors = new Dictionary<int, List<int>>();
			locker = new Dictionary<int, int>();
			for (int i = 0; i < parent.Length; i++)
			{
				descendant[i] = new List<int>();
				ancestors[i] = new List<int>();
			}
			for (int i = 1; i < parent.Length; i++)
			{
				descendant[parent[i]].Add(i);
				ancestors[i].Add(parent[i]);
			}
		}

		public bool Lock(int num, int user)
		{
			if (locker.ContainsKey(num))
				return false;
			locker[num] = user;
			return true;
		}

		public bool Unlock(int num, int user)
		{
			if (!locker.ContainsKey(num) || locker[num] != user)
				return false;
			locker.Remove(num);
			return true;
		}

		public bool Upgrade(int num, int user)
		{
			if (locker.ContainsKey(num) || !HasLock(num, descendant) || HasLock(num, ancestors))
				return false;
			UpdateDescendant(num);
			locker[num] = user;
			return true;
		}

		private bool HasLock(int cur, Dictionary<int, List<int>> dict)
		{
			if (locker.ContainsKey(cur))
				return true;
			var res = false;
			foreach (var next in dict[cur])
				res = res || HasLock(next, dict);
			return res;
		}

		private void UpdateDescendant(int cur)
		{
			if (locker.ContainsKey(cur))
				locker.Remove(cur);
			foreach (var next in descendant[cur])
				UpdateDescendant(next);
		}
	}
}
