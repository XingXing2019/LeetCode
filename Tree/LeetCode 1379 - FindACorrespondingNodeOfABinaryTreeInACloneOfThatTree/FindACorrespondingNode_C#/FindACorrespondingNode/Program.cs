using System;
using System.Collections.Generic;

namespace FindACorrespondingNode
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
        private TreeNode res;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public TreeNode GetTargetCopy_DFS(TreeNode original, TreeNode cloned, TreeNode target)
        {
            SearchTarget(cloned, target);
            return res;
        }
        void SearchTarget(TreeNode node, TreeNode target)
        {
            if (node == null)
                return;
            if (node.val == target.val)
                res = node;
            SearchTarget(node.left, target);
            SearchTarget(node.right, target);
        }
        public TreeNode GetTargetCopy_BFS(TreeNode original, TreeNode cloned, TreeNode target)
        {
            var originalQueue = new Queue<TreeNode>();
            var clonedQueue = new Queue<TreeNode>();
            originalQueue.Enqueue(original);
            clonedQueue.Enqueue(cloned);
            while (originalQueue.Count != 0)
            {
                var originalCur = originalQueue.Dequeue();
                var clonedCur = clonedQueue.Dequeue();
                if (originalCur == target) return clonedCur;
                if (originalCur.left != null)
                {
                    originalQueue.Enqueue(originalCur.left);
                    clonedQueue.Enqueue(clonedCur.left);
                }
                if (originalCur.right != null)
                {
                    originalQueue.Enqueue(originalCur.right);
                    clonedQueue.Enqueue(clonedCur.right);
                }
            }
            return null;
        }
    }
}
