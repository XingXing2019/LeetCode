// ++: (1i + 2i + i) - (1j + 2j + j)    arr1[i] + arr2[i] + i
// +-: (1i - 2i + i) - (1j - 2j + j)    arr1[i] + arr2[i] - i
// --: (1j + 2j - j) - (1i + i2 - i)    arr1[i] - arr2[i] - i
// -+: (1j - 2j - j) - (1i - 2i - i)    arr1[i] - arr2[i] + i

// 遍历数组，找到这四种情况的最大值和最小值分别是什么，存入max和min
using System;

namespace MaximumOfAbsoluteValueExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxAbsValExpr(int[] arr1, int[] arr2)
        {
            int[] max = {int.MinValue, int.MinValue, int.MinValue, int.MinValue};
            int[] min = {int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue};
            int[] sign = {1, 1, -1, -1, 1};
            var res = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    max[j] = Math.Max(max[j], arr1[i] + sign[j] * arr2[i] + sign[j + 1] * i);
                    min[j] = Math.Min(min[j], arr1[i] + sign[j] * arr2[i] + sign[j + 1] * i);
                    res = Math.Max(res, max[j] - min[j]);
                }
            }
            return res;
        }
    }
}
