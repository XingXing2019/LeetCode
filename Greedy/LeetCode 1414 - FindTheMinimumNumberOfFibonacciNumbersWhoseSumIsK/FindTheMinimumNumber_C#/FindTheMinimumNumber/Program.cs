using System;
using System.Collections.Generic;

namespace FindTheMinimumNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 17;
            Console.WriteLine(FindMinFibonacciNumbers_BinarySearch2(k));
        }
        static int FindMinFibonacciNumbers(int k)
        {
            var fib = new List<int>();
            int pre = 1, cur = 1;
            fib.Add(pre);
            fib.Add(cur);
            while (cur <= k)
            {
                int tem = pre;
                pre = cur;
                cur += tem;
                fib.Add(cur);
            }
            int index = fib.Count - 1;
            int count = 0;
            while (k != 0)
            {
                while (fib[index] > k)
                    index--;
                k -= fib[index];
                count++;
            }
            return count;
        }
        public int FindMinFibonacciNumbers_BinarySearch(int k)
        {
            var fib = new List<int> {1};
            int cur = 1, res = 0;
            while (cur <= k)
            {
                fib.Add(cur);
                cur += fib[^2];
            }
            while (k > 0)
            {
                var index = fib.BinarySearch(k);
                k -= index >= 0 ? fib[index] : fib[~index - 1];
                res++;
            }
            return res;
        }

        static int FindMinFibonacciNumbers_BinarySearch2(int k)
        {
            var fib = new List<int> { 1 };
            int cur = 1, res = 0;
            while (cur <= k)
            {
                fib.Add(cur);
                cur += fib[^2];
            }
            var index = fib.Count - 1;
            while (k > 0)
            {
                index = BinarySearch(fib, index, k);
                k -= fib[index];
                res++;
            }
            return res;
        }

        static int BinarySearch(List<int> arr, int lastIndex, int item)
        {
            int li = 0, hi = lastIndex;
            while (li <= hi)
            {
                int mid = li + (hi - li) / 2;
                if (arr[mid] == item) return mid;
                if (arr[mid] > item) hi = mid - 1;
                else li = mid + 1;
            }
            return hi;
        }
    }
}
