using System;
using System.Collections.Generic;

namespace SwappingNodesInALinkedList
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
            Console.WriteLine("Hello World!");
        }
        public ListNode SwapNodes(ListNode head, int k)
        {
            var nodes = new List<ListNode>();
            while (head != null)
            {
                nodes.Add(head);
                head = head.next;
            }
            var temp = nodes[^k];
            nodes[^k] = nodes[k - 1];
            nodes[k - 1] = temp;
            for (int i = 0; i < nodes.Count; i++)
                nodes[i].next = i == nodes.Count - 1 ? null : nodes[i + 1];
            return nodes[0];
        }
    }
}
