//设置方法获取链表长度len，创建eachLen代表每一段链表的长度，如果len小于k，则eachLen为1，否则为len / k。创建record用来记录eachLen(因为eachLen会在之后变动)。
//创建extra记录当每一段长度不同时，较长链表的数量。创建链表数组res记录结果。创建tem节点用来辅助断开链表。
//遍历res将每段链表存入res。总是使tem指向root的前一阶段，用于将当前root存入数组后断开链表。
//创建times用于计数，当extra大于0的时候times为-1，代表要多遍历一个节点。否则times为0。
//遍历链表，截取相应的长度，再将头结点在下一次遍历res的时候存入res。
using System;
using System.Runtime.InteropServices;

namespace SplitLinkedListInParts
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
            int[] nums = {1, 2, 3};
            var root = Generate(nums);
            int k = 5;
            Console.WriteLine(SplitListToParts(root, k));
        }
        static int GetLength(ListNode root)
        {
            int len = 0;
            while (root != null)
            {
                len++;
                root = root.next;
            }
            return len;
        }
        static ListNode[] SplitListToParts(ListNode root, int k)
        {
            int len = GetLength(root);
            int eachLen = len / k;
            int left = len - eachLen * k;
            var res = new ListNode[k];
            var pre = new ListNode(0) {next = root};
            var point = root;
            for (int i = 0; i < k && point != null; i++)
            {
                var head = pre;
                int times = left > 0 ? eachLen + 1 : eachLen;
                for (int j = 0; j < times; j++)
                {
                    pre = pre.next;
                    point = point.next;
                }
                left--;
                var temp = new ListNode(0){next = pre.next};
                pre.next = null;
                pre = temp;
                res[i] = head.next;
            }
            return res;
        }

        static ListNode Generate(int[] nums)
        {
            ListNode root = null;
            for (int i = nums.Length - 1; i >= 0; i--)
                root = new ListNode(nums[i]){next = root};
            return root;
        }
    }
}
