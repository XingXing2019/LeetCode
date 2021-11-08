using System;
using System.Collections.Generic;

namespace UniqueBinarySearchTreesII
{
	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
		{
			this.val = val;
			this.left = left;
			this.right = right;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public IList<TreeNode> GenerateTrees(int n)
		{
			return DFS(1, n);
		}

		public List<TreeNode> DFS(int start, int end)
		{
			if (start > end) return new List<TreeNode> {null};
			if (start == end) return new List<TreeNode> {new TreeNode(start)};
			var res = new List<TreeNode>();
			for (int i = start; i <= end; i++)
			{
				var leftTrees = DFS(start, i - 1);
				var rightTress = DFS(i + 1, end);
				foreach (var leftTree in leftTrees)
				{
					foreach (var rightTree in rightTress)
					{
						res.Add(new TreeNode(i, leftTree, rightTree));
					}
				}
			}
			return res;
		}
	}
}
