using System;

namespace LinkedListCycle
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
        static public bool HasCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;
            //set a meet point, if there is a meet point, then it is a cycle list, otherwise not.
            ListNode meet = null;
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
                if (fast == null)
                    return false;
                fast = fast.next;
                if(fast == slow)
                {
                    meet = fast;
                    break;
                }
            }
            if (meet == null)
                return false;
            else
                return true;
        }
    }
}
