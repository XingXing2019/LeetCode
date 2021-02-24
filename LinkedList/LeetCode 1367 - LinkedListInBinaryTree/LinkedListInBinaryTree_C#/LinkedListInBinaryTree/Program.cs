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
