//如果两个数字对同一个数字K取余数的结果相同，则两个数字的差可以被K整除。
//创建一个字典记录对K相同余数的个数。
//遍历数组，计算当前数字到数组头的总和sum。令sum对K取余数(model)，如果model存在字典中，则令结果加上字典中与model的个数，并令字典中model的个数加一。
//如果字典中没有model，则将model加入字典。
using System;
using System.Collections.Generic;

namespace SubarraySumsDivisibleByK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { -1, 2, 9 };
            int K = 2;
            Console.WriteLine(SubarraysDivByK1(A, K));
        }
        static int SubarraysDivByK1(int[] A, int K)
        {
            var modelFrequency = new Dictionary<int, int>();
            modelFrequency[0 % K] = 1;
            int sum = 0;
            int res = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                int model = sum % K;
                model = model < 0 ? model + K : model;
                if (modelFrequency.ContainsKey(model))
                {
                    res += modelFrequency[model];
                    modelFrequency[model]++;
                }
                else
                    modelFrequency[model] = 1;
            }
            return res;
        }

        static int SubarraysDivByK2(int[] A, int K)
        {
            int[] sumRecord = new int[A.Length];
            sumRecord[0] = A[0];
            for (int i = 1; i < A.Length; i++)
                sumRecord[i] = sumRecord[i - 1] + A[i];
            int res = 0;
            for (int i = 0; i < sumRecord.Length; i++)
            {
                if (sumRecord[i] % K == 0)
                    res++;
                for (int j = 0; j < i; j++)
                    if ((sumRecord[i] - sumRecord[j]) % K == 0)
                        res++;
            }
            return res;
        }
    }
}
