//深度优先，前序遍历。
//广度优先，用count辅助记录什么时候要换行。
using System;
using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversal
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
            var a = new TreeNode(3);
            var b = new TreeNode(9);
            var c = new TreeNode(20);
            var d = new TreeNode(15);
            var e = new TreeNode(7);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            Console.WriteLine(LevelOrder_DFS(a));
        }
        static IList<IList<int>> LevelOrder_DFS(TreeNode root)
        {
            var res = new List<IList<int>>();
            DFS(root, 0, res);
            return res;
        }
        static void DFS(TreeNode node, int level, List<IList<int>> res)
        {
            if (node == null) return;
            if (res.Count <= level)
                res.Add(new List<int> { node.val });
            else
                res[level].Add(node.val);
            DFS(node.left, level + 1, res);
            DFS(node.right, level + 1, res);
        }

        static IList<IList<int>> LevelOrder_BFS(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int count = queue.Count;
                var temp = new List<int>();
                while (count != 0)
                {
                    var current = queue.Dequeue();                    
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                    temp.Add(current.val);
                    count--;
                }
                res.Add(temp);
            }
            return res;
        }
    }
}
