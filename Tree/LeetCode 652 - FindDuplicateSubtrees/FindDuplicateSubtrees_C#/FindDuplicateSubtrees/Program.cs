using System;
using System.Collections.Generic;

namespace FindDuplicateSubtrees
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
            var a = new TreeNode(2);
            var b = new TreeNode(1);
            var c = new TreeNode(11);
            var d = new TreeNode(11);
            var e = new TreeNode(1);

            a.left = b;
            a.right = c;
            b.left = d;
            c.left = e;

            Console.WriteLine(FindDuplicateSubtrees(a));
        }
        static IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            var dict = new Dictionary<string, List<TreeNode>>();
            DFS(root, dict);
            var res = new List<TreeNode>();
            foreach (var kv in dict)
            {
                if(kv.Value.Count >= 2)
                    res.Add(kv.Value[0]);
            }
            return res;
        }

        static string DFS(TreeNode node, Dictionary<string, List<TreeNode>> dict)
        {
            if (node == null) return "#";
            var key = node.val + "-" + DFS(node.left, dict) + "-" + DFS(node.right, dict);
            if(!dict.ContainsKey(key))
                dict[key] = new List<TreeNode>();
            dict[key].Add(node);
            return key;
        }
    }
}
