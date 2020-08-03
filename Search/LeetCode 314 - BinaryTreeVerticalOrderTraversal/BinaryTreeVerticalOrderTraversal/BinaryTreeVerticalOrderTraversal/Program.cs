using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeVerticalOrderTraversal
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

            Console.WriteLine(VerticalOrder(a));
        }

        static IList<IList<int>> VerticalOrder(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            var dict = new Dictionary<TreeNode, int>();
            var queue = new Queue<TreeNode>();
            var index = new Dictionary<int, List<int>>();
            queue.Enqueue(root);
            dict[root] = 0;
            index[0] = new List<int> {root.val};
            while (queue.Count != 0 )
            {
                var count = queue.Count;
                while (count != 0)
                {
                    var cur = queue.Dequeue();
                    if (cur.left != null)
                    {
                        dict[cur.left] = dict[cur] - 1;
                        queue.Enqueue(cur.left);
                        if(!index.ContainsKey(dict[cur] - 1))
                            index[dict[cur] - 1] = new List<int>();
                        index[dict[cur] - 1].Add(cur.left.val);
                    }
                    if (cur.right != null)
                    {
                        dict[cur.right] = dict[cur] + 1;
                        queue.Enqueue(cur.right);
                        if (!index.ContainsKey(dict[cur] + 1))
                            index[dict[cur] + 1] = new List<int>();
                        index[dict[cur] + 1].Add(cur.right.val);
                    }
                    count--;
                }
            }
            int min = index.Min(x => x.Key);
            var res = new List<int>[index.Count];
            foreach (var kv in index)
                res[kv.Key - min] = kv.Value;
            return res;
        }
    }
}
