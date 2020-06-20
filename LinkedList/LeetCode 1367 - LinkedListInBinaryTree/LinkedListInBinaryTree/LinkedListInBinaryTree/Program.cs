using System;
using System.Collections.Generic;

namespace LinkedListInBinaryTree
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

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
            int[] nums = {4, 2, 8};
            var head = Generate(nums);

            var a = new TreeNode(1);
            var b = new TreeNode(4);
            var c = new TreeNode(4);
            var d = new TreeNode(2);
            var e = new TreeNode(2);
            var f = new TreeNode(1);
            var g = new TreeNode(6);
            var h = new TreeNode(8);
            var i = new TreeNode(1);
            var j = new TreeNode(3);

            a.left = b;
            a.right = c;
            b.right = d;
            d.left = f;
            c.left = e;
            e.left = g;
            e.right = h;
            h.left = i;
            h.right = j;

            Console.WriteLine(IsSubPath(head, a));

        }
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            if (head == null) return true;
            if (root == null) return false;
            return DFS(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right);
        }

        private bool DFS(ListNode head, TreeNode root)
        {
            if (head == null) return true;
            if (root == null) return false;
            return head.val == root.val && (DFS(head.next, root.left) || DFS(head.next, root.right));
        }
    }
}
