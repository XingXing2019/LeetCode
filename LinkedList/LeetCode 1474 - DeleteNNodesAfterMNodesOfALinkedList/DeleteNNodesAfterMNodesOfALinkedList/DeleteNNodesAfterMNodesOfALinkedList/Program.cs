//用两个指针，一个负责遍历留下的节点，一个用于跳过该删除的节点。
using System;

namespace DeleteNNodesAfterMNodesOfALinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
            var head = Build(nums);
            int m = 2, n = 3;
            Console.WriteLine(DeleteNodes(head, m, n));
        }
        static ListNode DeleteNodes(ListNode head, int m, int n)
        {
            ListNode res = new ListNode(0) {next = head};
            ListNode pointer = res;
            while (pointer != null)
            {
                for (int i = 0; i < m && pointer != null; i++)
                    pointer = pointer.next;
                var delete = pointer;
                for (int i = 0; i < n + 1 && delete != null; i++)
                    delete = delete.next;
                if(pointer == null) break;
                pointer.next = delete;
            }
            return res.next;
        }

        static ListNode Build(int[] nums)
        {
            ListNode res = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                res = new ListNode(nums[i]) {next = res};
            return res;
        }
    }
}
