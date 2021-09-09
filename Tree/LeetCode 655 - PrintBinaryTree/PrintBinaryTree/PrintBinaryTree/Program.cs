
using System;
using System.Collections.Generic;

namespace PrintBinaryTree
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
			var c = new TreeNode(3);
			var d = new TreeNode(4);

			a.left = b;
			b.left = c;
			c.left = d;
			Console.WriteLine(PrintTree(a));
		}

		public static IList<IList<string>> PrintTree(TreeNode root)
		{
			var height = GetHeight(root);
			var width = (int) Math.Pow(2, height) - 1;
			var matrix = new string[height][];
			for (int i = 0; i < height; i++)
			{
				matrix[i] = new string[width];
				Array.Fill(matrix[i], "");
			}
			DFS(root, matrix, 0, 0, width - 1);
			return matrix;
		}

		public static int GetHeight(TreeNode node)
		{
			if (node == null) return 0;
			return Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
		}

		public static void DFS(TreeNode node, string[][] matrix, int height, int li, int hi)
		{
			if(height == matrix.Length || node == null)
				return;
			int index = li + (hi - li) / 2;
			matrix[height][index] = node.val.ToString();
			DFS(node.left, matrix, height + 1, li, index - 1);
			DFS(node.right, matrix, height + 1, index + 1, hi);
		}
	}
}
