using System;

namespace ShortestSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            //           0  1  2  3      0  1  2
            int[] arr = {1, 2, 3};
            Console.WriteLine(FindLengthOfShortestSubarray(arr));
        }
        static int FindLengthOfShortestSubarray(int[] arr)
        {
            var res = arr.Length;
            int li = 1, hi = arr.Length - 2;
            while (li < arr.Length && arr[li] >= arr[li - 1])
                li++;
            while (hi >= 0 && arr[hi] <= arr[hi + 1])
                hi--;
            var prefix = arr[..li];
            var suffix = arr[(hi + 1)..];
            if (prefix.Length == arr.Length) return 0;
            for (int i = 0; i < prefix.Length; i++)
            {
                var index1 = Array.BinarySearch(suffix, prefix[i]);
                index1 = index1 < 0 ? -(index1 + 1) : index1;
                res = Math.Min(res, prefix.Length - i - 1 + index1);
            }
            for (int i = 0; i < suffix.Length; i++)
            {
                var index2 = Array.BinarySearch(prefix, suffix[i]);
                if(index2 >= 0)
                    res = Math.Min(res, i + prefix.Length - index2 - 1);
                else
                {
                    index2 = -(index2 + 1);
                    res = Math.Min(res, i + prefix.Length - index2);
                }
            }
            return res + arr.Length - prefix.Length - suffix.Length;
        }
    }
}
