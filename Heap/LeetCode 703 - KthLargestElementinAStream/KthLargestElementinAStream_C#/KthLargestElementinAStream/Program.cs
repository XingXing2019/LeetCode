using System;
using System.Collections.Generic;

namespace KthLargestElementinAStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class KthLargest
    {
        private List<int> maxHeap;
        private int count;
        public KthLargest(int k, int[] nums)
        {
            count = k;
            maxHeap = new List<int>();
            foreach (var num in nums)
                SetMaxHeap(num);
        }

        public int Add(int val)
        {
            SetMaxHeap(val);
            return maxHeap[0];
        }

        private void SetMaxHeap(int num)
        {
            var index = maxHeap.BinarySearch(num);
            index = index < 0 ? -(index + 1) : index;
            maxHeap.Insert(index, num);
            if (maxHeap.Count > count)
                maxHeap.RemoveAt(0);
        }
    }
}
