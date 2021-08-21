using System;
using System.Collections.Generic;

namespace CountNodesEqualToSumOfDescendants
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
			var a = new TreeNode(10);
			var b = new TreeNode(3);
			var c = new TreeNode(4);
			var d = new TreeNode(2);
			var e = new TreeNode(1);

			a.left = b;
			a.right = c;
			b.left = d;
			b.right = e;

			Console.WriteLine(EqualToDescendants(a));
		}

		public static int EqualToDescendants(TreeNode root)
		{
			int res = 0;
			DFS(root, new Dictionary<TreeNode, int>(), ref res);
			return res;
		}

		public static int DFS(TreeNode node, Dictionary<TreeNode, int> record, ref int res)
		{
			if (node == null) return 0;
			if (record.ContainsKey(node)) return record[node];
			int left = DFS(node.left, record, ref res);
			int right = DFS(node.right, record, ref res);
			if (node.val == left + right)
				res++;
			record[node] = left + right;
			return node.val + left + right;
		}
	}
}
