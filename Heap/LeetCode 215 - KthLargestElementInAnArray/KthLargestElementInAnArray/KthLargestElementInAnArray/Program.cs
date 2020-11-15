//用一个列表maxHeap维护一个最大堆，maxHeap的长度总保持在k以下，这样时间复杂度为nlogk。
//将nums中第一个数字加入maxHeap。然后遍历其他数字。如果当前数字比maxHeap尾端数字大，则将其插入maxHeap中第一个比他小的数字之后。插入后如果maxHeap长度大于k，则弹出队尾数字。
//如果当前数字比队尾数字小，而且maxHeap长度还小于k，则将其加入队尾。
//遍历结束后maxHeap队尾数字即为结果。
using System;
using System.Collections.Generic;

namespace KthLargestElementInAnArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 3, 2, 1, 5, 6, 4 };
            int k = 2;
            Console.WriteLine(FindKthLargest_BinarySearch(nums, k));
        }
        static int FindKthLargest_BinarySearch(int[] nums, int k)
        {
            var maxHeap = new List<int>();
            maxHeap.Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < maxHeap[0] && maxHeap.Count == k)
                    continue;
                var index = maxHeap.BinarySearch(nums[i]);
                index = index < 0 ? -(index + 1) : index;
                if (nums[i] > maxHeap[0] || maxHeap.Count < k)
                    maxHeap.Insert(index, nums[i]);
                if (maxHeap.Count > k)
                    maxHeap.RemoveAt(0);
            }
            return maxHeap[0];
        }
        static int FindKthLargest_List(int[] nums, int k)
        {
            var maxHeap = new List<int>();
            maxHeap.Add(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > maxHeap[^1])
                {
                    var point = maxHeap.Count - 1;
                    while (point >= 0)
                    {
                        if (maxHeap[point] > nums[i])
                            break;
                        point--;
                    }
                    maxHeap.Insert(point + 1, nums[i]);
                    if (maxHeap.Count > k)
                        maxHeap.RemoveAt(maxHeap.Count - 1);
                }
                else if (maxHeap.Count < k)
                    maxHeap.Add(nums[i]);
            }
            return maxHeap[^1];
        }
        public int FindKthLargest_Sort(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[^k];
        }

        class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        static int FindKthLargest_LinkedList(int[] nums, int k)
        {
            var head = new ListNode(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] >= head.val)
                {
                    var temp = new ListNode(nums[i], head);
                    head = temp;
                }
                else
                {
                    var point = head;
                    var pre = new ListNode(0, head);
                    while (point != null && point.val > nums[i])
                    {
                        point = point.next;
                        pre = pre.next;
                    }
                    var temp = new ListNode(nums[i], point);
                    pre.next = temp;

                }
            }
            for (int i = 1; i < k; i++)
                head = head.next;
            return head.val;
        }
    }
}
