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
			var a = new TreeNode(3);
			var b = new TreeNode(9);
			var c = new TreeNode(20);
			var d = new TreeNode(15);
			var e = new TreeNode(7);

			a.left = b;
			a.right = c;
			c.left = d;
			c.right = e;

			var codec = new Codec();
			var data = codec.serialize(a);
			Console.WriteLine(data);
			Console.WriteLine(codec.deserialize(data));
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
			var root = new TreeNode(int.Parse(first)) {left = Build(data), right = Build(data)};
			return root;
		}
	}
}
