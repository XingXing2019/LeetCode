//两棵树都是二叉搜索数，则可以保证，任意节点左边的所有节点都小于该节点。
//可利用这一特性，对树进行中序遍历，在遍历完所有左子树节点后将根节点加入列表，在遍历该节点右边所有节点。
//分别遍历两棵树后可以得到两个升序排列的列表，再用两个指针将两个列表合并。
using System;
using System.Collections.Generic;

namespace AllElementsInTwoBinarySearchTrees
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
            TreeNode a = new TreeNode(2);
            TreeNode b = new TreeNode(1);
            TreeNode c = new TreeNode(4);

            TreeNode d = new TreeNode(1);
            TreeNode e = new TreeNode(0);
            TreeNode f = new TreeNode(3);

            a.left = b;
            a.right = c;

            d.left = e;
            d.right = f;
            Console.WriteLine(GetAllElements(a, d));
        }
        static IList<int> GetAllElements(TreeNode root1, TreeNode root2)
        {
            List<int> res = new List<int>();
            List<int> r1 = new List<int>();
            List<int> r2 = new List<int>();
            GetNodes(root1, r1);
            GetNodes(root2, r2);
            int p1 = 0, p2 = 0;
            while (p1 < r1.Count && p2 < r2.Count)
            {
                if (r1[p1] < r2[p2])
                    res.Add(r1[p1++]);
                else
                    res.Add(r2[p2++]);
            }
            if (p1 < r1.Count)
                while (p1 < r1.Count)
                    res.Add(r1[p1++]);
            else if (p2 < r2.Count)
                while (p2 < r2.Count)
                    res.Add(r2[p2++]);
            return res;
        }
        static void GetNodes(TreeNode node, List<int> record)
        {
            if (node == null)
                return;
            GetNodes(node.left, record);
            record.Add(node.val);
            GetNodes(node.right, record);
        }
    }
}
