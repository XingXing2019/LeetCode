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
        static int HIndex2(int[] citations)
        {
            if (citations.Length == 0)
                return 0;
            int li = 0;
            int hi = citations.Length - 1;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (citations.Length - mid == citations[mid])
                    return citations.Length - mid;
                else if (citations.Length - mid > citations[mid])
                    li = mid + 1;
                else
                    hi = mid - 1;
            }
            return citations.Length - li;
        }
    }
}
