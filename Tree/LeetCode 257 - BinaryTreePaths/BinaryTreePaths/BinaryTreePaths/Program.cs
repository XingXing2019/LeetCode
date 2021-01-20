using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTreePaths
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(1);
            TreeNode b = new TreeNode(2);
            TreeNode c = new TreeNode(3);
            TreeNode d = new TreeNode(4);

            a.left = b;
            a.right = c;
            b.right = d;

            BinaryTreePaths(a);
        }
        static IList<string> BinaryTreePaths(TreeNode root)
        {
            var res = new List<string>();
            DFS(root, "", res);
            return res;
        }
        static void DFS(TreeNode node, string path, List<string> res)
        {
            if(node == null) return;
            if(node.left == node.right)
                res.Add($"{path}{node.val}");
            DFS(node.left, path + $"{node.val}->", res);
            DFS(node.right, path + $"{node.val}->", res);
        }
    }
}
