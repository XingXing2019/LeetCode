using System;
using System.Collections.Generic;

namespace BinarySubarraysWithSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 0, 1, 0, 1 };
            int S = 2;
            Console.WriteLine(NumSubarraysWithSum(A, S));
        }
        static int NumSubarraysWithSum(int[] A, int S)
        {
            var sumFrequency = new Dictionary<int, int>();
            sumFrequency[0] = 1;
            int sum = 0;
            int res = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                if (sumFrequency.ContainsKey(sum - S))
                    res += sumFrequency[sum - S];
                if (sumFrequency.ContainsKey(sum))
                    sumFrequency[sum]++;
                else
                    sumFrequency[sum] = 1;
            }
            return res;
        }
    }
}
