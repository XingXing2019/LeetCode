using System;
using System.Collections.Generic;

namespace LargestBSTSubtree
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
			var a = new TreeNode(1);
			var b = new TreeNode(2);
			var c = new TreeNode(7);
			var d = new TreeNode(2);
			var e = new TreeNode(3);
			var f = new TreeNode(5);
			var g = new TreeNode(2);
			var h = new TreeNode(1);

			a.left = b;
			//a.right = c;
			//b.left = d;
			//b.right = e;
			//c.left = f;
			//d.left = g;
			//g.left = h;

			Console.WriteLine(LargestBSTSubtree(a));
		}
		public static int LargestBSTSubtree(TreeNode root)
		{
			var bst = new HashSet<TreeNode>();
			GetBST(root, bst);
			var res = 0;
			foreach (var tree in bst)
				GetNodes(tree, ref res);
			return res;
		}

		public static void GetBST(TreeNode node, HashSet<TreeNode> bst)
		{
			if(node == null) return;
			if (IsBST(node)) bst.Add(node);
			GetBST(node.left, bst);
			GetBST(node.right, bst);
		}

		public static bool IsBST(TreeNode node, int min = int.MinValue, int max = int.MaxValue)
		{
			if (node == null) return true;
			if (node.val <= min || node.val >= max) return false;
			return IsBST(node.left, min, node.val) && IsBST(node.right, node.val, max);
		}

		public static int GetNodes(TreeNode root, ref int max)
		{
			if (root == null) return 0;
			int nodes = 1 + GetNodes(root.left, ref max) + GetNodes(root.right, ref max);
			max = Math.Max(max, nodes);
			return nodes;
		}
	}
}
