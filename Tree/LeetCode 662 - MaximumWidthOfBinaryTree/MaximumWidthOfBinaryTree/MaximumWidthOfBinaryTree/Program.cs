//对于每个节点，如果他的index是x，那么他的左子树节点index就是2 * x，右子树节点index是2 * x + 1。
//可以用滚动列表代替队列实现层级遍历。用keyValuePair记录每个节点的指针和index。
using System;
using System.Collections.Generic;

namespace MaximumWidthOfBinaryTree
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
            var b = new TreeNode(3);
            var c = new TreeNode(2);
            var d = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;

            Console.WriteLine(WidthOfBinaryTree_List(a));
        }

        static int WidthOfBinaryTree_List(TreeNode root)
        {
            if (root == null) return 0;
            var curLayer = new List<KeyValuePair<TreeNode, int>>();
            curLayer.Add(new KeyValuePair<TreeNode, int>(root, 1));
            int maxWidth = 0;
            while (curLayer.Count != 0)
            {
                maxWidth = Math.Max(maxWidth, curLayer[^1].Value - curLayer[0].Value + 1);
                var nextLayer = new List<KeyValuePair<TreeNode, int>>();
                foreach (var node in curLayer)
                {
                    if(node.Key.left != null)
                        nextLayer.Add(new KeyValuePair<TreeNode, int>(node.Key.left, 2 * node.Value));
                    if (node.Key.right != null)
                        nextLayer.Add(new KeyValuePair<TreeNode, int>(node.Key.right, 2 * node.Value + 1));
                }
                curLayer = nextLayer;
            }
            return maxWidth;
        }

        public class MyNode : TreeNode
        {
            public MyNode(TreeNode node, int index) : base(node.val)
            {
                this.left = node.left;
                this.right = node.right;
                this.index = index;
            }
            public int index;
        }
        static int WidthOfBinaryTree(TreeNode root)
        {
            var maxWidth = 0;
            var queue = new Queue<MyNode>();
            queue.Enqueue(new MyNode(root, 1));
            while (queue.Count > 0)
            {
                var count = queue.Count;
                var left = 0;
                var width = 0;
                for (var i = 0; i < count; i++)
                {
                    var node = queue.Dequeue();
                    if (left == 0)
                    {
                        left = node.index;
                        width = 1;
                    }
                    else
                        width = node.index - left + 1;
                    if (node.left != null) queue.Enqueue(new MyNode(node.left, node.index * 2));
                    if (node.right != null) queue.Enqueue(new MyNode(node.right, node.index * 2 + 1));
                }
                maxWidth = Math.Max(maxWidth, width);
            }
            return maxWidth;
        }
    }
}
