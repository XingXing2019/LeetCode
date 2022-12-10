using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace MaximumProductOfSplittedBinaryTree
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

		
		public int MaxProduct(TreeNode root)
		{
			var dict = new Dictionary<TreeNode, long>();
			var total = GetSum(root, dict);
			long res = 0, mod = 1_000_000_000 + 7;
			DFS(root, total, dict, ref res);
			return (int) (res % mod);
		}

		public void DFS(TreeNode node, long total, Dictionary<TreeNode, long> dict, ref long res)
		{
			if (node == null) return;
			long sum = dict[node];
			res = Math.Max(res, sum * (total - sum));
			DFS(node.left, total, dict, ref res);
			DFS(node.right, total, dict, ref res);
		}

		public long GetSum(TreeNode node, Dictionary<TreeNode, long> dict)
		{
			if (node == null) return 0;
			long res = node.val;
			res += GetSum(node.left, dict);
			res += GetSum(node.right, dict);
			dict[node] = res;
			return res;
		}
	}
}
