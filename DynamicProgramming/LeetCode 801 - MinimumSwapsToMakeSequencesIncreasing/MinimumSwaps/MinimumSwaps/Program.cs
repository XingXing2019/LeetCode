using System;

namespace MinimumSwaps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinSwap(int[] nums1, int[] nums2)
        {
            var keep = new int[nums1.Length];
            var swap = new int[nums1.Length];
            Array.Fill(keep, int.MaxValue);
            Array.Fill(swap, int.MaxValue);
            keep[0] = 0;
            swap[0] = 1;
            for (int i = 1; i < nums1.Length; i++)
            {
                if (nums1[i] > nums1[i - 1] && nums2[i] > nums2[i - 1])
                {
                    keep[i] = keep[i - 1];
                    swap[i] = swap[i - 1] + 1;
                }
                if (nums1[i] > nums2[i - 1] && nums2[i] > nums1[i - 1])
                {
                    keep[i] = Math.Min(keep[i], swap[i - 1]);
                    swap[i] = Math.Min(swap[i], keep[i - 1] + 1);
                }
            }
            return Math.Min(keep[^1], swap[^1]);
        }
    }
}
