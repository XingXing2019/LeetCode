//创建GetValues方法将链表中的元素存入数组。然后利用栈来存储数组中数字的下标，从而通过栈操作找到下一个更大的数字。
//思路与LeetCode.503相似，但操作更简单。
using System;
using System.Collections;

namespace NextGreaterNodeInLinkedList
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
            Console.WriteLine("Hello World!");
        }
        static int GetLength(ListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }
            return len;
        }
        static int[] GetValues(ListNode head)
        {
            int len = GetLength(head);
            int[] values = new int[len];
            for (int i = 0; i < len; i++)
            {
                values[i] = head.val;
                head = head.next;
            }
            return values;
        }
        static int[] NextLargerNodes(ListNode head)
        {
            int len = GetLength(head);
            int[] values = GetValues(head);
            int[] res = new int[len];
            Stack indexStack = new Stack();
            indexStack.Push(0);
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] > values[(int)indexStack.Peek()])
                {
                    while (indexStack.Count != 0 && values[i] > values[(int)indexStack.Peek()])
                    {
                        res[(int)indexStack.Pop()] = values[i];
                    }
                    indexStack.Push(i);
                }
                else
                    indexStack.Push(i);
            }
            return res;
        }
    }
}
