//创建长度为n的res数组。将第一位设为0。从第二位开始遍历到倒数第四位，相邻的两位设为相反数。
//再根据n的奇偶性手动设置最后三位。
using System;

namespace FindNUniqueIntegersSumUpToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            Console.WriteLine(SumZero(n));
        }
        static int[] SumZero(int n)
        {
            if(n == 1)
                return new int[]{0};
            if(n == 2)
                return new int[]{1, -1};
            int[] res = new int[n];
            res[0] = 0;
            int i = 1;
            for (; i < res.Length-3; i++)
            {
                if (i % 2 != 0)
                    res[i] = i;
                else
                    res[i] = -res[i - 1];
            }
            if (n % 2 == 0)
            {
                res[n - 3] = i;
                res[n - 2] = i + 1;
                res[n - 1] = -2 * i - 1;
            }
            else
            {
                res[n - 3] = 1 - i;
                res[n - 2] = i + 1;
                res[n - 1] = -i - 1;
            }
            return res;
        }
    }
}
