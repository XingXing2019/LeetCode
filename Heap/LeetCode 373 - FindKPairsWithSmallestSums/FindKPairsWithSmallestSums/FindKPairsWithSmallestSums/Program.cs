using System;
using System.Collections.Generic;

namespace FindKPairsWithSmallestSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 7, 11 };
            int[] nums2 = { 2, 4, 6 };
            int k = 3;
            Console.WriteLine(KSmallestPairs(nums1, nums2, k));
        }
        static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            var list = new List<IList<int>>();
            k = Math.Min(k, nums1.Length * nums2.Length);
            int[] idx = new int[Math.Min(k, nums1.Length)];
            while (list.Count < k)
            {
                int minPairIndex = -1;
                for (int i = 0; i < idx.Length; i++)
                {
                    if (idx[i] < nums2.Length)
                    {
                        if (minPairIndex == -1 || nums1[i] + nums2[idx[i]] < nums1[minPairIndex] + nums2[idx[minPairIndex]])
                            minPairIndex = i;
                    }
                }
                list.Add(new int[] { nums1[minPairIndex], nums2[idx[minPairIndex]] });
                idx[minPairIndex]++;
            }
            return list;
        }
    }
}
