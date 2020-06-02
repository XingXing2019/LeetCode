using System;
using System.Dynamic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ConvertSortedListToBinarySearchTree
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
            int[] nums = {-10, -3, 0, 5, 9};
            var head = Generate(nums);
        }
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null) return null;
            int len = GetLen(head);
            int index = len / 2;
            var info = GetInfo(head, index);
            var root = new TreeNode(info[0].val);
            root.left = SortedListToBST(info[2]);
            root.right = SortedListToBST(info[1]);
            return root;
        }

        private int GetLen(ListNode head)
        {
            var len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }

        private ListNode[] GetInfo(ListNode head, int index)
        {
            if (index == 0)
                return new ListNode[] {head, null, null};
            var res = new ListNode[3];
            var dummy = head;
            for (int i = 0; i < index - 1; i++)
            {
                head = head.next;
            }
            res[0] = head.next;
            res[1] = head.next?.next;
            head.next = null;
            res[2] = dummy;
            return res;
        }
        
    

        static ListNode Generate(int[] nums)
        {
            ListNode head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                head = new ListNode(nums[i]) { next = head }; 
            return head;
        }
    }
}
