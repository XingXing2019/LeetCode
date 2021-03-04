//本题思路为遍历链表，检查每个节点的val是否存在于G数组中。原先使用Array.IndexOf方法则运行速度很慢，可换成一个bool数组表示每个数字是否存在于G数组中。
//创建bool数组isInArray，长度设为10001(因为题目说明链表最大长度为10000)。遍历G数组，将isInArray中G数组中每个元素对应的位置刷为true。
//创建res记录结果，创建len记录现有的连续链表的长度。
//在head不为null的情况下遍历链表，如果当前节点的val不在数组中，而且此时len大于0，则证明再次节点之前已有连续的子节点，并在此节点处断开了。那么res加一并使len复位为0。
//如果当前节点的val在数组中则使len加一。
//遍历结束后需判断len的长度，如果不为0，则证明最后一个连续的子链表还未被记录如res，则使res加一。
using System;

namespace LinkedListComponents
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
            int[] nums = { 0, 1, 2};
            ListNode head = CreateLinkedList(nums);
            int[] G = { 1, 0 };
            Console.WriteLine(NumComponents(head, G));
        }
        static int NumComponents(ListNode head, int[] G)
        {
            if (head == null)
                return 0;
            bool[] isInArray = new bool[10001];
            foreach (var num in G)
                isInArray[num] = true;
            int res = 0;
            int len = 0;
            while (head != null)
            {
                int num = head.val;
                if (isInArray[num] == false)
                    if (len > 0)
                    {
                        res++;
                        len = 0;
                    }
                else
                    len++;
                head = head.next;
            }
            if (len != 0)
                res++;
            return res;
        }
        static ListNode CreateLinkedList(int[] nums)
        {
            ListNode head = null;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                head = new ListNode(nums[i]) { next = head };
            }
            return head;
        }
    }
}
