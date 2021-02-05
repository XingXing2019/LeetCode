//与LeetCode_102思路一样，将最后结果翻转即可。
using System;
using System.Collections.Generic;

namespace BinaryTreeLevelOrderTraversalII
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

        }

        public IList<IList<int>> LevelOrderBottom_DFS(TreeNode root)
        {
            var res = new List<IList<int>>();
            DFS(root, 0, res);
            res.Reverse();
            return res;
        }

        private void DFS(TreeNode node, int level, List<IList<int>> res)
        {
            if (node == null) return;
            if(res.Count <= level)
                res.Add(new List<int>());
            res[level].Add(node.val);
            DFS(node.left, level + 1, res);            
            DFS(node.right, level + 1, res);      
        }

        public IList<IList<int>> LevelOrderBottom_BFS(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var count = queue.Count;
                var layer = new List<int>();
                while (count != 0)
                {
                    var cur = queue.Dequeue();
                    layer.Add(cur.val);
                    if(cur.left != null) queue.Enqueue(cur.left);
                    if(cur.right != null) queue.Enqueue(cur.right);
                    count--;
                }
                res.Add(layer);
            }
            res.Reverse();
            return res;
        }
    }
}
