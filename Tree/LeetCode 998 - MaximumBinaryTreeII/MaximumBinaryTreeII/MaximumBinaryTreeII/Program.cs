using System;
using System.Collections.Generic;

namespace MaximumBinaryTreeII
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
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(4);
            var b = new TreeNode(1);
            var c = new TreeNode(3);
            var d = new TreeNode(2);

            a.left = b;
            a.right = c;
            c.left = d;

            var val = 5;
            Console.WriteLine(InsertIntoMaxTree(a, val));
        }

        public static TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            var nodes = GetNodes(root);
            nodes.Add(val);
            return ConstructTree(nodes, 0, nodes.Count - 1);
        }

        public static List<int> GetNodes(TreeNode node)
        {
            if (node == null) return new List<int>();
            var left = GetNodes(node.left);
            var right = GetNodes(node.right);
            left.Add(node.val);
            left.AddRange(right);
            return left;
        }

        public static TreeNode ConstructTree(List<int> nodes, int li, int hi)
        {
            if (li > hi) return null;
            var index = GetMaxIndex(nodes, li, hi);
            var root = new TreeNode(nodes[index]);
            root.left = ConstructTree(nodes, li, index - 1);
            root.right = ConstructTree(nodes, index + 1, hi);
            return root;
        }

        public static int GetMaxIndex(List<int> nodes, int li, int hi)
        {
            int res = 0, max = 0;
            for (int i = li; i <= hi; i++)
            {
                if (nodes[i] < max) continue;
                max = nodes[i];
                res = i;
            }
            return res;
        }
    }
}
