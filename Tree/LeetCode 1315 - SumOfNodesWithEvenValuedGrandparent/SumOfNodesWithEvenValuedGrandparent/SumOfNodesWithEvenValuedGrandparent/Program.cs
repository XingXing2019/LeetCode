//只要某个节点是偶数，如果他有孙子，就把他的孙子加到结果里，然后在递归找左子树和右子树。
using System;

namespace SumOfNodesWithEvenValuedGrandparent
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
            TreeNode a = new TreeNode(6);
            TreeNode b = new TreeNode(7);
            TreeNode c = new TreeNode(8);
            TreeNode d = new TreeNode(2);
            TreeNode e = new TreeNode(7);
            TreeNode f = new TreeNode(1);
            TreeNode g = new TreeNode(3);
            TreeNode h = new TreeNode(9);
            TreeNode i = new TreeNode(1);
            TreeNode j = new TreeNode(4);
            TreeNode k = new TreeNode(5);

            a.left = b;
            a.right = c;
            b.left = d;
            b.right = e;
            c.left = f;
            c.right = g;
            d.left = h;
            e.left = i;
            e.right = j;
            g.right = k;

            Console.WriteLine(SumEvenGrandparent(a));
        }

        private int res;
        public int SumEvenGrandparent(TreeNode root)
        {
            GetGrandson(root);
            return res;
        }

        private void GetGrandson(TreeNode node)
        {
            if(node == null)
                return;
            if (node.val % 2 == 0)
            {
                if (node.left != null)
                {
                    res += node.left.left?.val ?? 0;
                    res += node.left.right?.val ?? 0;
                }

                if (node.right != null)
                {
                    res += node.right.left?.val ?? 0;
                    res += node.right.right?.val ?? 0;
                }
            }
            GetGrandson(node.left);
            GetGrandson(node.right);
        }
    }
}
