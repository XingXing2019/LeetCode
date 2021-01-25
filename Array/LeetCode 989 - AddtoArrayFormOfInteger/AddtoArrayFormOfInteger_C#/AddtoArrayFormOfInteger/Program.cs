//从后向前按位计算。
using System;
using System.Collections.Generic;

namespace AddtoArrayFormOfInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            int K = 1;
            Console.WriteLine(AddToArrayForm(A, K));
        }
        static IList<int> AddToArrayForm(int[] A, int K)
        {
            List<int> res = new List<int>();
            int cur = 0, car = 0;
            int p1 = A.Length - 1;
            while (p1 >= 0 && K != 0)
            {
                cur = (A[p1] + K % 10 + car) % 10;
                car = (A[p1] + K % 10 + car) / 10;
                res.Insert(0, cur);
                p1--;
                K /= 10;
            }
            while(p1 >= 0)
            {
                cur = (A[p1] + car) % 10;
                car = (A[p1] + car) / 10;
                res.Insert(0, cur);
                p1--;
            }
            while (K != 0)
            {
                cur = (K % 10 + car) % 10;
                car = (K % 10 + car) / 10;
                res.Insert(0, cur);
                K /= 10;
            }
            if(car != 0)
                res.Insert(0, car);
            return res;
        }
    }
}
