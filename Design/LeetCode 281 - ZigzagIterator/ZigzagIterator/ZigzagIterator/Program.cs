using System;
using System.Collections.Generic;

namespace ZigzagIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class ZigzagIterator
    {
        private List<int> nums;
        private int p;
        public ZigzagIterator(IList<int> v1, IList<int> v2)
        {
            nums = new List<int>();
            p = 0;
            int p1 = 0, p2 = 0;
            while (p1 < v1.Count && p2 < v2.Count)
            {
                nums.Add(v1[p1++]);
                nums.Add(v2[p2++]);
            }
            while (p1 < v1.Count)
                nums.Add(v1[p1++]);
            while (p2 < v2.Count)
                nums.Add(v2[p2++]);
        }

        public bool HasNext()
        {
            return p < nums.Count;
        }

        public int Next()
        {
            return nums[p++];
        }
    }
}
