//从上右下左四个边依次向中心旋转读取数字。
//设置height代表现有数组的高度，读取完上下边时，要使height分别减一，代表现有数组高度减小。
//设置width代表现有数组的宽度，读取完左右边时，要使width分别减一，代表数组宽度减小。
//设置startR代表读取数字时行的指针，每次读取完上边的时候，要使startR加一，代表指针下移一行。
//设置startC代表读取数字时列的指针，每次读取完左边的时候，要使startC加一，代表指针右移一列。
//读取数字时要控制好边界条件，经过调试可以得到正确的边界设置方法。尽量用大一点的数组可以更好的看清边界条件。
using System;
using System.Collections.Generic;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[][] {
                new int[]{1, 2, 3, 4, 5},
                new int[]{14, 15, 16, 17, 6},
                new int[]{13, 20, 19, 18, 7},
                new int[]{12, 11, 10, 9, 8},
            };
            Console.WriteLine(SpiralOrder(matrix));
        }
        static IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0)
                return new int[0];
            List<int> res = new List<int>();
            int height = matrix.Length;
            int width = matrix[0].Length;
            int startR = 0;
            int startC = 0;
            while (true)
            {
                if (height == 0 || width == 0) break;
                for (int i = startC; i < startC + width; i++)
                    res.Add(matrix[startR][i]);
                height--;
                startR++;

                if (height == 0 || width == 0) break;
                for (int i = startR; i < startR + height; i++)
                    res.Add(matrix[i][width + startC - 1]);
                width--;

                if (height == 0 || width == 0) break;
                for (int i = width + startC - 1; i >= startC; i--)
                    res.Add(matrix[height + startR - 1][i]);
                height--;

                if (height == 0 || width == 0) break;
                for (int i = height + startR - 1; i >= startR; i--)
                    res.Add(matrix[i][startC]);
                width--;
                startC++;
            }
            return res;
        }
    }
}
