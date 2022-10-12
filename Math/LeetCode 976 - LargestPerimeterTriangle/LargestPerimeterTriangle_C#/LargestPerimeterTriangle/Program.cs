//先将数组排序，然后倒着遍历，如果当前数字小于其前两个数字之和，则将三个数字之和记入res并终止遍历。
//需注意只要遍历到第三个数字即可，以防越界。
using System;

namespace LargestPerimeterTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 2, 1 };
            Console.WriteLine(LargestPerimeter(A));
        }
        static int LargestPerimeter(int[] A)
        {
            Array.Sort(A);
            int res = 0;
            for (int i = A.Length - 1; i >= 2; i--)
            {
                if(A[i] < A[i - 1] + A[i - 2])
                {
                    res = A[i] + A[i - 1] + A[i - 2];
                    break;
                }
            }
            return res;
        }
    }
}
