using System;

namespace EqualTreePartition
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
			var c = new TreeNode(2);
			//var d = new TreeNode(2);
			//var e = new TreeNode(3);

			a.right = b;
			b.left = c;
			//a.right = c;
			//c.left = d;
			//c.right = e;

			Console.WriteLine(CheckEqualTree(a));
		}
		public static bool CheckEqualTree(TreeNode root)
		{
			DFS(root);
			return Check(root, root.val);
		}

		public static bool Check(TreeNode root, int rootVal)
		{
			if (root == null) return false;
			if (root.left != null && rootVal == 2 * root.left.val || root.right != null && rootVal == 2 * root.right.val)
				return true;
			return Check(root.left, rootVal) || Check(root.right, rootVal);
		}

		public static int DFS(TreeNode node)
		{
			if (node == null) return 0;
			node.val += DFS(node.left);
			node.val += DFS(node.right);
			return node.val;
		}
	}
}
