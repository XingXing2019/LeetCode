//和LeetCode_102思路一致，多加一个level计算层数。偶数层需要翻转一下。
using System;
using System.Collections.Generic;

namespace BinaryTreeZigzagLevelOrderTraversal
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

            Console.WriteLine(ZigzagLevelOrder_DFS(a));
        }
        static IList<IList<int>> ZigzagLevelOrder_BFS(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            var level = 0;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var temp = new List<int>();
                var count = queue.Count;
                while (count != 0)
                {
                    var current = queue.Dequeue();
                    temp.Add(current.val);
                    if (current.left != null) queue.Enqueue(current.left);
                    if (current.right != null) queue.Enqueue(current.right);
                    count--;
                }
                level++;
                if (level % 2 == 0)
                    temp.Reverse();
                res.Add(temp);
            }
            return res;
        }

        static IList<IList<int>> ZigzagLevelOrder_DFS(TreeNode root)
        {
            var res = new List<IList<int>>();
            DFS(root, 0, res);
            return res;
        }

        static void DFS(TreeNode node, int level, List<IList<int>> res)
        {
            if (node == null) return;
            if(res.Count <= level)
                res.Add(new List<int>());
            DFS(node.left, level + 1, res);
            DFS(node.right, level + 1, res);
            if(level % 2 == 0)
                res[level].Add(node.val);
            else
                res[level].Insert(0, node.val);
        }
    }
}
