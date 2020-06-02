//functionFromIndex代表以某个元素开始的function所能得到的结果。
//functionFromIndex = functionFromIndex - sum + A.Length * A[i - 1]相当于先将每个元素的个数减一，再将当前元素之前的元素个数加上数组长度个。
using System;

namespace RotateFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxRotateFunction(int[] A)
        {
            int sum = 0;
            int functionFromIndex = 0;
            for (int i = 0; i < A.Length; i++)
            {
                sum += A[i];
                functionFromIndex += i * A[i];
            }
            int max = functionFromIndex;
            for (int i = 1; i < A.Length; i++)
            {
                functionFromIndex = functionFromIndex - sum + A.Length * A[i - 1];
                max = Math.Max(max, functionFromIndex);
            }
            return max;
        }
    }
}
