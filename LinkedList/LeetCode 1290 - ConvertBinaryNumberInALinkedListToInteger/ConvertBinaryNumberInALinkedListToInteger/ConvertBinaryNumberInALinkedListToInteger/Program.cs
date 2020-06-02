//从head开始往后遍历。每次将res成等于2，再将每个节点的val加入res。
using System;

namespace ConvertBinaryNumberInALinkedListToInteger
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
            
        }
        static int GetDecimalValue(ListNode head)
        {
            int res = 0;
            while (head != null)
            {
                res *= 2;
                res += head.val;
                head = head.next;
            }
            return res;
        }
    }
}
