using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckCompletenessOfABinaryTree
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

            Console.WriteLine(IsCompleteTree(a));
        }
        static bool IsCompleteTree(TreeNode root)
        {
            var nodes = new List<List<TreeNode>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var temp = new List<TreeNode>();
                for (int i = 0; i < count; i++)
                {
                    var cur = queue.Dequeue();
                    if (cur == null) continue;
                    queue.Enqueue(cur.left);
                    queue.Enqueue(cur.right);
                    temp.Add(cur.left);
                    temp.Add(cur.right);
                }
                if(temp.All(x => x == null)) break;
                nodes.Add(temp);
            }
            var level = 2;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Count(x => x != null) == level)
                {
                    level <<= 1;
                    continue;
                }
                if (i != nodes.Count - 1) return false;
                var foundLastNode = false;
                for (int j = nodes[i].Count - 1; j >= 0; j--)
                {
                    if (nodes[i][j] != null)
                        foundLastNode = true;
                    else if (nodes[i][j] == null && foundLastNode)
                        return false;
                }
            }
            return true;
        }
    }
}
