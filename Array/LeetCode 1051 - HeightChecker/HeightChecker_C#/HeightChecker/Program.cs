//创建record数组记录heights，对heights排序。比较record和heights中位置相同但数字不同的个数。
using System;

namespace HeightChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] heights = { 1, 1, 4, 2, 1, 3 };
            Console.WriteLine(HeightChecker(heights));
        }
        static int HeightChecker(int[] heights)
        {
            int[] record = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++)
                record[i] = heights[i];
            Array.Sort(heights);
            int res = 0;
            for (int i = 0; i < record.Length; i++)
                if (record[i] != heights[i])
                    res++;
            return res;
        }
    }
}
