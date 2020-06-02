//先将数字转换成2进制，存入数组record。遍历record找到1之间最大的距离。
using System;
using System.Collections.Generic;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 6;
            Console.WriteLine(BinaryGap(N));
        }
        static int BinaryGap(int N)
        {
            var record = new List<int>();
            while (N != 0)
            {
                record.Add(N % 2);
                N /= 2;
            }
            int max = 0;
            bool start = false;
            int tem = 0;
            for (int i = 0; i < record.Count; i++)
            {
                if (record[i] == 1)
                {
                    if (!start)
                        start = true;
                    else
                        max = Math.Max(max, i - tem);
                    tem = i;
                }
            }
            return max;
        }
    }
}
