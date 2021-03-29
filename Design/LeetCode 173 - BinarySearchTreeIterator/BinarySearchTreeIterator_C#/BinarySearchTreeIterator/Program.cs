using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace BinarySearchTreeIterator
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new TreeNode(7);
            var b = new TreeNode(3);
            var c = new TreeNode(15);
            var d = new TreeNode(9);
            var e = new TreeNode(20);

            a.left = b;
            a.right = c;
            c.left = d;
            c.right = e;

            var iterator = new BSTIterator_Queue(a);
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.HasNext());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.HasNext());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.HasNext());
            Console.WriteLine(iterator.Next());
            Console.WriteLine(iterator.HasNext());
        }
    }
    public class BSTIterator_LinkedList
    {
        private ListNode head;
        private ListNode point = new ListNode(0);
        public BSTIterator(TreeNode root)
        {
            head = point;
            Generate(root);
            head = head.next;
        }

        private void Generate(TreeNode root)
        {
            if (root == null) return;
            Generate(root.left);
            point.next = new ListNode(root.val);
            point = point.next;
            Generate(root.right);
        }

        /** @return the next smallest number */
        public int Next()
        {
            var res = head.val;
            head = head.next;
            return res;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return head != null;
        }
    }
    public class BSTIterator_Queue
    {
        private Queue<int> queue;
        public BSTIterator(TreeNode root)
        {
            queue = new Queue<int>();
            Generate(root);
        }

        private void Generate(TreeNode root)
        {
            if(root == null) return;
            Generate(root.left);
            queue.Enqueue(root.val);
            Generate(root.right);
        }
        /** @return the next smallest number */
        public int Next()
        {
            return queue.Dequeue();
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return queue.Count != 0;
        }
    }
}
