//可以利用Array.BinarySearch函数，找不到就返回负数的特点，对第一行的每个数字在所有行中进行二分搜索。
//如果在每一行都能返回正数，则证明找到答案。
using System;

namespace FindSmallestCommonElementInAllRows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int SmallestCommonElement(int[][] mat)
        {
            foreach (var num in mat[0])
            {
                bool isCommon = true;
                for (int i = 0; i < mat.Length; i++)
                {
                    if (Array.BinarySearch(mat[i], num) < 0)
                    {
                        isCommon = false;
                        break;
                    }
                }
                if (isCommon)
                    return num;
            }
            return -1;
        }
    }
}
