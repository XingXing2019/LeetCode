using System;

namespace ReverseLinkedList
{
    class Node
    {
        public int val;
        public Node next;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node list = CreateList(new int[] { 1, 2, 3, 4, 5 });
            Node res = ReverseLinkedList(list);
            PrintList(list);
            Console.WriteLine("");
            PrintList(res);
        }
        static Node CreateList(int[] nums)
        {
            Node head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                head = new Node() { val = nums[i], next = head }; 
            }
            return head;
        }
        static void PrintList(Node nodeHead)
        {
            while (nodeHead != null)
            {
                Console.Write(nodeHead.val + "->");
                nodeHead = nodeHead.next;
            }
        }
        static Node ReverseLinkedList(Node list)
        {
            Node res = null;
            while (list != null)
            {
                res = new Node() { val = list.val, next = res };
                list = list.next;
            }
            return res;
        }
    }
}
