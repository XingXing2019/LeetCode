using System;
using System.Collections.Generic;
using System.Linq;

namespace VerticalOrderTraversalOfABinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(0);
            var b = new TreeNode(2);
            var c = new TreeNode(1);
            var d = new TreeNode(3);
            var e = new TreeNode(4);
            var f = new TreeNode(5);
            var g = new TreeNode(7);
            var h = new TreeNode(10);
            var i = new TreeNode(8);
            var j = new TreeNode(6);
            var k = new TreeNode(11);
            var l = new TreeNode(9);

            a.left = b;
            a.right = c;
            b.left = d;
            d.left = e;
            d.right = f;
            e.right = g;
            f.left = j;
            g.left = h;
            g.right = i;
            j.left = k;
            j.right = l;

            Console.WriteLine(VerticalTraversal(a));
        }
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
        static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            var dict = new Dictionary<TreeNode, int[]>();
            var queue = new Queue<TreeNode>();
            var index = new Dictionary<int, List<TreeNode>>();
            queue.Enqueue(root);
            int level = 0;
            dict[root] = new []{0, level};
            index[0] = new List<TreeNode> { root };
            while (queue.Count != 0)
            {
                var count = queue.Count;
                level++;
                while (count != 0)
                {
                    var cur = queue.Dequeue();
                    if (cur.left != null)
                    {
                        dict[cur.left] = new[] {dict[cur][0] - 1, level};
                        queue.Enqueue(cur.left);
                        if (!index.ContainsKey(dict[cur][0] - 1))
                            index[dict[cur][0] - 1] = new List<TreeNode>();
                        index[dict[cur][0] - 1].Add(cur.left);
                    }
                    if (cur.right != null)
                    {
                        dict[cur.right] = new[] {dict[cur][0] + 1, level};
                        queue.Enqueue(cur.right);
                        if (!index.ContainsKey(dict[cur][0] + 1))
                            index[dict[cur][0] + 1] = new List<TreeNode>();
                        index[dict[cur][0] + 1].Add(cur.right);
                    }
                    count--;
                }
            }
            int min = index.Min(x => x.Key);
            var res = new List<int>[index.Count];
            foreach (var kv in index)
            {
                var nodes = kv.Value.OrderBy(x => dict[x][1]).ThenBy(x => x.val).ToList();
                res[kv.Key - min] = nodes.Select(x => x.val).ToList();
            }
            return res;
        }
    }
}
