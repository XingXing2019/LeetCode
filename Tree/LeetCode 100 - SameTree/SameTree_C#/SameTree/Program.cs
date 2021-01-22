//如果p，q一方为空，则返回是否双方都为空。
//如果p，q值不同，返回false。
//递归返回p和q的左右子树是否都相同。

//将每个节点的值分别存入两个列表，如果为null，则将null存入列表。
//对比两个列表是否完全相同。
using System;
using System.Collections.Generic;

namespace SameTree
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
            Console.WriteLine("Hello World!");
        }
        static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null) return p == null && q == null;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
        static bool IsSameTree2(TreeNode p, TreeNode q)
        {
            var r1 = new List<string>();
            var r2 = new List<string>();
            Preorder(p, r1);
            Preorder(q, r2);
            if (r1.Count != r2.Count)
                return false;
            for (int i = 0; i < r1.Count; i++)
                if (r1[i] != r2[i])
                    return false;
            return true;
        }
        static void Preorder(TreeNode node, List<string> record)
        {
            if (node == null)
            {
                record.Add("null");
                return;
            }
            record.Add(node.val.ToString());
            Preorder(node.left, record);
            Preorder(node.right, record);
        }
       
    }
}
