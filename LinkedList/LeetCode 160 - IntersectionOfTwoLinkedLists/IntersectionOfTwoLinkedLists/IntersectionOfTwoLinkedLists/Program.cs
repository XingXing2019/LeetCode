using System;

namespace IntersectionOfTwoLinkedLists
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ListNode a1 = new ListNode(4);
            ListNode a2 = new ListNode(1);
            ListNode a3 = new ListNode(8);
            ListNode a4 = new ListNode(4);
            ListNode a5 = new ListNode(5);
            a1.next = a2;
            a2.next = a3;
            a3.next = a4;
            a4.next = a5;

            ListNode b1 = new ListNode(5);
            ListNode b2 = new ListNode(0);
            ListNode b3 = new ListNode(1);
            ListNode b4 = new ListNode(8);
            ListNode b5 = new ListNode(4);
            ListNode b6 = new ListNode(5);
            b1.next = b2;
            b2.next = b3;
            b3.next = b4;
            b4.next = b5;
            b5.next = b6;

            ListNode res = GetIntersectionNode(a1, b2);
            PrintList(res);
        }

        static void PrintList(ListNode list)
        {
            while (list != null)
            {
                Console.Write(list.val + "->");
                list = list.next;
            }
            Console.Write("null");
        }
        static int GetLen(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }
        static ListNode CutList(ListNode head, int lenLong, int lenShort)
        {
            for (int i = 0; i < lenLong - lenShort; i++)
            {
                head = head.next;
            }
            return head;
        }
        static public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            int LenA = GetLen(headA);
            int LenB = GetLen(headB);
            if (LenA >= LenB)
                headA = CutList(headA, LenA, LenB);
            else
                headB = CutList(headB, LenB, LenA);
            while (headA != null && headB != null && headA != headB)
            {
                headA = headA.next;
                headB = headB.next;
            }
            return headA;
        }

        public ListNode GetIntersectionNode_HashSet(ListNode headA, ListNode headB)
        {
            var set = new HashSet<ListNode>();
            while (headA != null)
            {
                set.Add(headA);
                headA = headA.next;
            }
            while (headB != null)
            {
                if (set.Contains(headB))
                    return headB;
                headB = headB.next;
            }
            return null;
        }
    }
}
