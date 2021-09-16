using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PathInZigzagLabelledBinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			int label = 8;
			Console.WriteLine(PathInZigZagTree(label));
		}

		public static IList<int> PathInZigZagTree(int label)
		{
			int size = 1, level = 1, li = 1, hi = 1, count = 2;
			while (size < label)
			{
				size += count;
				count *= 2;
				level++;
			}
			var tree = new int[size + 1];
			for (int i = 0; i < tree.Length; i++)
				tree[i] = i;
			count = 2;
			for (int i = 1; i <= level; i++)
			{
				if (i % 2 == 0) Reverse(tree, li, hi);
				li = hi + 1;
				hi += count;
				count *= 2;
			}
			var index = Array.IndexOf(tree, label);
			var res = new List<int>();
			while (index != 0)
			{
				res.Add(tree[index]);
				index /= 2;
			}
			res.Reverse();
			return res;
		}

		public static void Reverse(int[] tree, int li, int hi)
		{
			while (li < hi)
			{
				int temp = tree[li];
				tree[li++] = tree[hi];
				tree[hi--] = temp;
			}
		}
	}
}
