using System;
using System.Collections.Generic;

namespace RecoverBinarySearchTree
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
		public void RecoverTree(TreeNode root)
		{
			var nodes = new List<int>();
			GetNodes(root, nodes);
			nodes.Sort();
			int index = 0;
			SetNode(root, nodes, ref index);
		}

		public void GetNodes(TreeNode node, List<int> nodes)
		{
			if(node == null) return;
			GetNodes(node.left, nodes);
			nodes.Add(node.val);
			GetNodes(node.right, nodes);
		}

		public void SetNode(TreeNode node, List<int> nodes, ref int index)
		{
			if(node == null) return;
			SetNode(node.left, nodes, ref index);
			if (node.val != nodes[index])
				node.val = nodes[index];
			index++;
			SetNode(node.right, nodes, ref index);
		}
	}
}
