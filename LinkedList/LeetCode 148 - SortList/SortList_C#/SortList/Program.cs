using System;
using System.Collections.Generic;
using System.Linq;

namespace SortList
{
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
            Console.WriteLine("Hello World!");
        }
        public ListNode SortList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode point = head;
            while (point.next != null)
            {
                if (point.val <= point.next.val)
                    point = point.next;
                else
                {
                    ListNode q = dummy;
                    ListNode tem = point.next;
                    point.next = point.next.next;
                    while (q.next.val < tem.val)
                        q = q.next;
                    tem.next = q.next;
                    q.next = tem;
                }
            }
            return dummy.next;
        }
        public ListNode SortList_Linq(ListNode head)
        {
            if (head == null) return null;
            var nodes = new List<ListNode>();
            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }
            nodes = nodes.OrderBy(x => x.val).ToList();
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].next = i == nodes.Count - 1 ? null : nodes[i + 1];
            return nodes[0];
        }
    }
}
