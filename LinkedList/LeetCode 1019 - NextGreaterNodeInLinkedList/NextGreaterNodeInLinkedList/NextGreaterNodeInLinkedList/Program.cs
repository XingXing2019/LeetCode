//创建GetValues方法将链表中的元素存入数组。然后利用栈来存储数组中数字的下标，从而通过栈操作找到下一个更大的数字。
//思路与LeetCode.503相似，但操作更简单。
using System;
using System.Collections;
using System.Collections.Generic;

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

        static int[] NextLargerNodes(ListNode head)
        {
            var nums = new List<int>();
            while (head != null)
            {
                nums.Add(head.val);
                head = head.next;
            }
            var res = new int[nums.Count];
            var stack = new Stack<int>();
            for (int i = 0; i < res.Length; i++)
            {
                while (stack.Count != 0 && nums[stack.Peek()] < nums[i])
                    res[stack.Pop()] = nums[i];
                stack.Push(i);
            }
            return res;
        }
    }
}
