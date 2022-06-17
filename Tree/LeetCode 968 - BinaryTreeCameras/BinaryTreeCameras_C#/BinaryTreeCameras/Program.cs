using System;
using System.Collections.Generic;

namespace BinaryTreeCameras
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
		public int MinCameraCover(TreeNode root)
		{
			var set = new HashSet<TreeNode>() { null };
			int res = 0;
			DFS(root, null, set, ref res);
			return res;
		}

		public void DFS(TreeNode node, TreeNode parent, HashSet<TreeNode> covered, ref int res)
		{
			if (node == null) return;
			DFS(node.left, node, covered, ref res);
			DFS(node.right, node, covered, ref res);
			if (parent == null && !covered.Contains(node) || !covered.Contains(node.left) || !covered.Contains(node.right))
			{
				res++;
				covered.Add(node);
				covered.Add(parent);
				covered.Add(node.left);
				covered.Add(node.right);
			}
		}
	}
}
