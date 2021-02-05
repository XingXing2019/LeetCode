//思路与LeetCode 274完全一样，甚至更简单，因为数组已经是排好序的。
using System;

namespace H_IndexII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] citation = { 0, 1, 3, 5, 6 };
            Console.WriteLine(HIndex(citation));
        }
        static int HIndex(int[] citations)
        {
            int res = 0;
            for (int i = 0; i < citations.Length; i++)
            {
                if(citations.Length - i <= citations[i])
                {
                    res = citations.Length - i;
                    break;
                }
            }
            return res;
        }
        static int HIndex_BinarySearch(int[] citations)
        {
            if (citations.Length < 1) return citations.Length;
            int li = 0, hi = citations.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (citations[mid] == citations.Length - mid)
                    return citations[mid];
                if (citations[mid] > citations.Length - mid)
                    hi = mid - 1;
                else
                    li = mid + 1;
            }
            return citations.Length - li;
        }
    }
}
