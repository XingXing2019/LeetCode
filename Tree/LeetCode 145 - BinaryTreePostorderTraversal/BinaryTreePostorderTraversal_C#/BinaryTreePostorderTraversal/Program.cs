using System;
using System.Collections.Generic;

namespace BinaryTreePostorderTraversal
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

        public IList<int> PostorderTraversal_DFS(TreeNode root)
        {
            var res = new List<int>();
            DFS(root, res);
            return res;
        }

        private void DFS(TreeNode node, List<int> res)
        {
            if(node == null) return;
            DFS(node.left, res);
            DFS(node.right, res);
            res.Add(node.val);
        }
    }
}
