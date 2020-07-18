using System;
using System.Collections.Generic;

namespace PrintImmutableLinkedListInReverse
{
    class ImmutableListNode
    {
        public void PrintValue(); // print the value of this node.
        public ImmutableListNode GetNext(); // return the next node.
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public void PrintLinkedListInReverse_Recursion(ImmutableListNode head)
        {
            if (head == null) return;
            PrintLinkedListInReverse_Recursion(head.GetNext());
            head.PrintValue();
        }
        public void PrintLinkedListInReverse_List(ImmutableListNode head)
        {
            var list = new List<ImmutableListNode>();
            while (head != null)
            {
                list.Add(head);
                head = head.GetNext();
            }
            for (int i = list.Count - 1; i >= 0; i--)
                list[i].PrintValue();
        }
    }
}
