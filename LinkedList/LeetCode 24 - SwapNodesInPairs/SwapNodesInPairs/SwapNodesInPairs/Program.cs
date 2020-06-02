//先判断如果链表为空，或只有一个节点，则直接返回链表头。
//创建dummy节点，创建pre节点，指向dummy节点。创建pointer节点，指向head节点。
//在point不为null的条件下遍历链表。创建tem节点，指向pointer的下一节点。如果tem节点为空则证明链表有奇数个节点，此时pointer已经到链表尾，则终止遍历。
//将pointer的下一节点设为tem的下一节点相连。再将tem的下一节点设为pointer，再将pre的下一节点设为tem。此时完成一次交换。
//将pre向前移动两位，将pointer向前移动一位(交换过程中pointer已经显现前移动过一位)。
//最后返回dummy.next
using System;

namespace SwapNodesInPairs
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
            Console.WriteLine("Hello World!");
        }
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode dummy = new ListNode(0);
            ListNode pre = dummy;
            ListNode pointer = head;
            while (pointer != null)
            {
                ListNode tem = pointer.next;
                if (tem == null)
                    break;
                pointer.next = tem.next;
                tem.next = pointer;
                pre.next = tem;
                pre = pre.next.next;
                pointer = pointer.next;
            }
            return dummy.next;
        }
    }
}
