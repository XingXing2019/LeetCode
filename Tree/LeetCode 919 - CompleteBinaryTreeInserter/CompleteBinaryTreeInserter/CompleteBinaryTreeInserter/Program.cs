using System;
using System.Collections;
using System.Collections.Generic;

namespace CompleteBinaryTreeInserter
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
			var e = new TreeNode(5);
			var f = new TreeNode(6);

			a.left = b;
			a.right = c;
			b.left = d;
			b.right = e;
			c.left = f;

			var inserter = new CBTInserter(a);
			inserter.Insert(7);
			inserter.Insert(8);
		}
	}

	public class CBTInserter
	{
		private TreeNode _root;
		private List<TreeNode> parents;
		private List<TreeNode> children;
		public CBTInserter(TreeNode root)
		{
			_root = root;
			var queue = new Queue<TreeNode>();
			queue.Enqueue(root);
			parents = new List<TreeNode>();
			parents.Add(root);
			while (queue.Count > 0)
			{
				int count = queue.Count;
				children = new List<TreeNode>();
				for (int i = 0; i < count; i++)
				{
					var cur = queue.Dequeue();
					if (cur.left != null)
					{
						queue.Enqueue(cur.left);
						children.Add(cur.left);
					}
					if (cur.right != null)
					{
						queue.Enqueue(cur.right);
						children.Add(cur.right);
					}
				}
				if(children.Count != count * 2)
					break;
				parents = children;
			}
		}

		public int Insert(int v)
		{
			var child = new TreeNode(v);
			children.Add(child);
			var parent = parents[(children.Count - 1) / 2];
			if (children.Count % 2 == 0)
				parent.right = child;
			else
				parent.left = child;
			if (children.Count == parents.Count * 2)
			{
				parents = children;
				children = new List<TreeNode>();
			}
			return parent.val;
		}

		public TreeNode Get_root()
		{
			return _root;
		}
	}
}
