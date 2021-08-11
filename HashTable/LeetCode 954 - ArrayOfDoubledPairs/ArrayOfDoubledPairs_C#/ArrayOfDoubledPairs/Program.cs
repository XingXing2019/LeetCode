//先将A中的负数转换成正数，在排序。
//然后找出是否每个数字都能找到其两倍的数字，并且两两匹配后没有多余数字。
using System;
using System.Collections.Generic;

namespace ArrayOfDoubledPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 4, -2, 2, -4 };
            Console.WriteLine(CanReorderDoubled(A));
        }      
        static bool CanReorderDoubled(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
                A[i] = A[i] > 0 ? A[i] : -A[i];
            Array.Sort(A);
            var record = new Dictionary<double, int>();
            foreach (var num in A)
            {
                double tem = (double)num / 2;
                if (!record.ContainsKey(tem))
                {
                    if (!record.ContainsKey(num))
                        record[num] = 1;
                    else
                        record[num]++;
                }
                else
                {
                    record[tem]--;
                    if (record[tem] == 0)
                        record.Remove(tem);
                }
            }
            return record.Count == 0;
        }
    }
}
