//创建字典记录数组中每个数字到数组头总和，和总和相同位置的个数。将字典中0的位置设为1，因为第一个数字之前的数字之和为0，所以初始情况总和为零的位置有1个。
//创建sum计算总和。遍历数组，将当前数字加入sum。如果sum-S在字典中，证明当前数字之前有某些位置能与当前位置构成符合条件的数组。则将符合条件的位置的个数加入res。
//如果sum存在于字典中，则令其位置个数加一，否则将其存入字典。
using System;
using System.Collections.Generic;

namespace BinarySubarraysWithSum
{
    class Program
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
