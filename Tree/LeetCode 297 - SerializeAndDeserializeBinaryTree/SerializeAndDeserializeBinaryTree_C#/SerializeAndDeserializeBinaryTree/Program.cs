using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializeAndDeserializeBinaryTree
{
	class Program
	{
		static void Main(string[] args)
		{
			var nodes = "1,null,2,3,null,null,null";
			var root = Build(nodes.Split(","));
			var codec = new Codec();
			var data = codec.serialize(root);
			Console.WriteLine(data);
			Console.WriteLine(codec.deserialize(data));
		}

		static int index = 0;
		private static TreeNode Build(string[] nodes)
		{
			var first = nodes[index++];
			if (first == "null") return null;
			var root = new TreeNode(int.Parse(first)) {left = Build(nodes), right = Build(nodes)};
			return root;
		}
	}

	public class TreeNode
	{
		public int val;
		public TreeNode left;
		public TreeNode right;
		public TreeNode(int x) { val = x; }
	}

	public class Codec
	{
		private int index;
		public string serialize(TreeNode root)
		{
			var preOrder = new StringBuilder();
			PreOrder(root, preOrder);
			return preOrder.ToString();
		}

		public TreeNode deserialize(string data)
		{
			return Build(data.Split(","));
		}
		private void PreOrder(TreeNode root, StringBuilder nodes)
		{
			if (root == null)
			{
				nodes.Append("#,");
				return;
			}
			nodes.Append($"{root.val.ToString()},");
			PreOrder(root.left, nodes);
			PreOrder(root.right, nodes);
		}

		private TreeNode Build(string[] data)
		{
			string first = data[index++];
			if (first == "#") return null;
			var root = new TreeNode(int.Parse(first)) { left = Build(data), right = Build(data) };
			return root;
		}
	}
}
