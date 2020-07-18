using System;

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
        public void PrintLinkedListInReverse(ImmutableListNode head)
        {
            if (head == null) return;
            PrintLinkedListInReverse(head.GetNext());
            head.PrintValue();
        }
    }
}
