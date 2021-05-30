using System;
using System.Collections.Generic;

namespace ConvertBinarySearchTree
{
	public class Node
	{
		public int val;
		public Node left;
		public Node right;

		public Node() { }

		public Node(int _val)
		{
			val = _val;
			left = null;
			right = null;
		}

		public Node(int _val, Node _left, Node _right)
		{
			val = _val;
			left = _left;
			right = _right;
		}
	}
    class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public static Node TreeToDoublyList(Node root)
		{
			if (root == null) return null;
			var nodes = new List<Node>();
			DFS(root, nodes);
			for (int i = 0; i < nodes.Count; i++)
			{
				nodes[i].left = i == 0 ? nodes[^1] : nodes[i - 1];
				nodes[i].right = i == nodes.Count - 1 ? nodes[0] : nodes[i + 1];
			}
			return nodes[0];
		}

		public static void DFS(Node node, List<Node> nodes)
		{
			if (node == null) return;
			DFS(node.left, nodes);
			nodes.Add(node);
			DFS(node.right, nodes);
		}
	}
}
