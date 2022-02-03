using System;
using System.Collections.Generic;

namespace _4SumII
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {0};
            int[] B = {0};
            int[] C = {0};
            int[] D = {0};
            Console.WriteLine(FourSumCount(A, B, C, D));
        }
        static int FourSumCount(int[] A, int[] B, int[] C, int[] D)
        {
            var d1 = new Dictionary<int, int>();
            var d2 = new Dictionary<int, int>();
            var l1 = new List<int>();
            var l2 = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    int tem1 = A[i] + B[j];
                    int tem2 = C[i] + D[j];
                    if (!d1.ContainsKey(tem1))
                    {
                        d1[tem1] = 1;
                        l1.Add(tem1);
                    }
                    else
                        d1[tem1]++;
                    if (!d2.ContainsKey(tem2))
                    {
                        d2[tem2] = 1;
                        l2.Add(tem2);
                    }
                    else
                        d2[tem2]++;
                }
            }
            l1.Sort();
            l2.Sort();
            int res = 0;
            for (int i = 0; i < l1.Count; i++)
            {
                bool found = false;
                int li = 0, hi = l2.Count - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (l1[i] + l2[mid] == 0)
                    {
                        res += d1[l1[i]] * d2[l2[mid]];
                        found = true;
                        break;
                    }
                    else if (l1[i] + l2[mid] > 0)
                        hi = mid;
                    else
                        li = mid + 1;
                }
                if(!found && l1[i] + l2[li] == 0)
                    res += d1[l1[i]] * d2[l2[li]];
            }
            return res;
        }
    }
}
