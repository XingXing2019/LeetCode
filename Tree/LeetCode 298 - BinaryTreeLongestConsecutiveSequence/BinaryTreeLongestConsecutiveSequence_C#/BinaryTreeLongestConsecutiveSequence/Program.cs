using System;

namespace BinaryTreeLongestConsecutiveSequence
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

		private int max;
		public int LongestConsecutive(TreeNode root)
		{
			DFS(root, null, 0);
			return max;
		}

		public void DFS(TreeNode node, TreeNode parent, int len)
		{
			if (node == null) return;
			len = parent != null && node.val - parent.val == 1 ? len + 1 : 1;
			max = Math.Max(max, len);
			DFS(node.left, node, len);
			DFS(node.right, node, len);
		}
	}
}
