//利用二分搜索找出数组中与x最接近的值。但需要检查其前一个值是否与x更接近，如果是则取其前一个值。
//将与x最接近的值存入res，并令k减一，再创建两个指针分别指向最接近值的前一个和后一个值。
//在两个指针都不越界，并且k不等于0的条件下循环。判断哪个指针所指数字更接近x，将其存入res，并令指针左相应移动，同时使k减一。
//循环结束后如果k仍不等于0，则根据没越界的指针的条件将相应数字存入res。
using System;
using System.Collections.Generic;

namespace FindKClosestElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int k = 4;
            int x = -1;
            Console.WriteLine(FindClosestElements(arr, k, x));
        }
        static IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int li = 0;
            int hi = arr.Length - 1;
            while (li != hi)
            {
                int mid = li + (hi - li) / 2;
                if (arr[mid] == x)
                {
                    li = mid;
                    break;
                }
                else if (arr[mid] < x)
                    li = mid + 1;
                else
                    hi = mid;
            }
            if (li != 0 && Math.Abs(arr[li] - x) > Math.Abs(arr[li - 1] - x))
                li--;
            int pLow = li - 1;
            int pHigh = li + 1;
            List<int> res = new List<int>() { arr[li] };
            k--;
            while (pLow >= 0 && pHigh < arr.Length && k != 0)
            {
                if (Math.Abs(arr[pLow] - x) <= Math.Abs(arr[pHigh] - x))
                    res.Insert(0, arr[pLow--]);
                else
                    res.Insert(res.Count, arr[pHigh++]);
                k--;
            }
            if (k != 0 && pLow < 0)
            {
                while (k != 0)
                {
                    res.Add(arr[pHigh++]);
                    k--;
                }
            }
            else if (k != 0 && pHigh >= arr.Length)
            {
                while (k != 0)
                {
                    res.Insert(0, arr[pLow--]);
                    k--;
                }
            }
            return res;
        }

        public IList<int> FindClosestElements_Heap(int[] arr, int k, int x)
        {
            var heap = new PriorityQueue<int, ComparableInt>();
            foreach (var num in arr)
            {
                heap.Enqueue(num, new ComparableInt(num, x));
                if (heap.Count > k)
                    heap.Dequeue();
            }
            var res = new List<int>();
            while (heap.Count != 0)
                res.Add(heap.Dequeue());
            res.Sort();
            return res;
        }

        class ComparableInt : IComparable
        {
            private int num;
            private int x;
            public ComparableInt(int num, int x)
            {
                this.num = num;
                this.x = x;
            }

            public int CompareTo(object obj)
            {
                var that = obj as ComparableInt;
                if (Math.Abs(this.num - x) < Math.Abs(that.num - x)) 
                    return 1;
                else if (Math.Abs(this.num - x) > Math.Abs(that.num - x))
                    return -1;
                return this.num < that.num ? 1 : -1;
            }
        }
    }
}
