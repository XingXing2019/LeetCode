using System;
using System.Collections.Generic;

namespace FindAllTheLonelyNodes
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
        static IList<int> GetLonelyNodes(TreeNode root)
        {
            var res = new List<int>();
            DFS(root, res);
            return res;
        }

        static void DFS(TreeNode node, List<int> res)
        {
            if(node == null) return;
            if(node.left == null && node.right != null)
                res.Add(node.right.val);
            else if(node.left != null && node.right == null)
                res.Add(node.left.val);
            DFS(node.left, res);
            DFS(node.right, res);
        }
    }
}
