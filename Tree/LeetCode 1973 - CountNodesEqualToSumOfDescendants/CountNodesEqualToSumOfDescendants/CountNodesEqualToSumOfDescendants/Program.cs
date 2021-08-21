using System;

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
			DFS(root, ref res);
			return res;
		}

		public static int DFS(TreeNode node, ref int res)
		{
			if (node == null) return 0;
			int left = DFS(node.left, ref res);
			int right = DFS(node.right, ref res);
			if (node.val == left + right)
				res++;
			return node.val + left + right;
		}
	}
}
