using System;
using System.Collections.Generic;

namespace MergeKSortedLists
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
            ListNode[] lists =
            {
                Generate(new[] {1, 2, 2}),
                Generate(new[] {1, 1, 2}),
            };
            Console.WriteLine(MergeKLists(lists));
        }
        static ListNode MergeKLists(ListNode[] lists)
        {
            var list = new SortedList<int, List<ListNode>>();
            foreach (var listNode in lists)
            {
                if(listNode == null) continue;
                if (!list.ContainsKey(listNode.val))
                    list[listNode.val] = new List<ListNode>();
                list[listNode.val].Add(listNode);
            }
            var res = new ListNode();
            var point = res;
            while (list.Count != 0)
            {
                point.next = list[list.Keys[0]][^1];
                var temp = list[list.Keys[0]][^1];
                list[list.Keys[0]].RemoveAt(list[list.Keys[0]].Count - 1);
                if (temp.next != null)
                {
                    if (!list.ContainsKey(temp.next.val))
                        list[temp.next.val] = new List<ListNode>();
                    list[temp.next.val].Add(temp.next);
                }
                if (list[list.Keys[0]].Count == 0)
                    list.Remove(list.Keys[0]);
                point = point.next;
            }
            return res.next;
        }

        static ListNode Generate(int[] nums)
        {
            ListNode res = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                res = new ListNode(nums[i], res);
            return res;
        }
    }
}
