using System;
using System.Collections.Generic;

namespace SmallestStringStartingFromLeaf
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
            var a = new TreeNode(25);
            var b = new TreeNode(1);
            var c = new TreeNode(3);
            var d = new TreeNode(1);
            var e = new TreeNode(3);
            var f = new TreeNode(0);
            var g = new TreeNode(2);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = g;

            Console.WriteLine(SmallestFromLeaf(a));
        }
        static string SmallestFromLeaf(TreeNode root)
        {
            var res = "";
            DFS(root, new List<char>(), ref res);
            return res;
        }

        static void DFS(TreeNode node, List<char> path, ref string res)
        {
            if(node == null) return;
            path.Add((char)(node.val + 'a'));
            if (node.left == node.right)
            {
                var temp = new List<char>(path);
                temp.Reverse();
                var word = string.Join("", temp);
                if (res == "" || word.CompareTo(res) < 0)
                    res = word;
            }
            DFS(node.left, path, ref res);
            DFS(node.right, path, ref res);
            path.RemoveAt(path.Count - 1);
        }

    }
}
