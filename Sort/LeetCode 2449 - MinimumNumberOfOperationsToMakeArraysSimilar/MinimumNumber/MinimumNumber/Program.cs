using System;
using System.Collections.Generic;

namespace MinimumNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public long MakeSimilar(int[] nums, int[] target)
        {
            Array.Sort(nums);
            Array.Sort(target);
            long diff = 0;
            var odd = new Queue<int>();
            var even = new Queue<int>();
            foreach (var num in nums)
            {
                if (num % 2 != 0)
                    odd.Enqueue(num);
                else
                    even.Enqueue(num);
            }
            foreach (var num in target)
                diff += num % 2 != 0 ? Math.Abs(odd.Dequeue() - num) : Math.Abs(even.Dequeue() - num);
            return diff / 4;
        }
    }
}
