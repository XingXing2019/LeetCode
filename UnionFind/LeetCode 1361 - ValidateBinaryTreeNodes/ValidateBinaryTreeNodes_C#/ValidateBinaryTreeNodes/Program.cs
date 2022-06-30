using System;
using System.Collections.Generic;

namespace ValidateBinaryTreeNodes
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		private int[] parents;
		private int[] rank;
		public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
		{
			parents = new int[n];
			for (int i = 0; i < n; i++)
				parents[i] = i;
			rank = new int[n];
			var edges = new List<int[]>();
			var seen = new HashSet<int>();
			for (int i = 0; i < n; i++)
			{
				if (leftChild[i] != -1 && !seen.Add(leftChild[i]) || rightChild[i] != -1 && !seen.Add(rightChild[i]))
					return false;
				if (leftChild[i] != -1)
					edges.Add(new[] { i, leftChild[i] });
				if (rightChild[i] != -1)
					edges.Add(new[] { i, rightChild[i] });
			}
			foreach (var edge in edges)
			{
				if (!Merge(edge[0], edge[1]))
					return false;
				n--;
			}
			return n == 1;
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
	}
}
