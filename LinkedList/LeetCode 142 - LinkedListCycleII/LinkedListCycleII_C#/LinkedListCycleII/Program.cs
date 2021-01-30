using System;

namespace LinkedListCycleII
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
        static public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            ListNode meet = null;
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast != null)
                {
                    fast = fast.next;
                    if(fast == slow)
                    {
                        meet = fast;
                        break;
                    }
                }
                else
                    return null;    
            }
            if (meet == null)
                return null;
            while (true)
            {
                if (head == meet)
                {
                    return head;
                }
                head = head.next;
                meet = meet.next;
            }
        }
    }
}
