//创建row代表当前所在行，初始值设为0。创建col代表当前所在列，初始值设为最后一列。
//在行和列都不越界的条件下遍历数组。如果当前坐标数字等于target则返回true。如果当前坐标数字小于target，则向下移动一行。如果当前坐标数字大于target，则向左移动一列。
//遍历结束后如仍未返回true，则返回false。
using System;

namespace SearchA2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[1][];
            matrix[0] = new int[] { 1 };
            int target = 0;
            Console.WriteLine(SearchMatrix1(matrix, target));
        }
        static bool SearchMatrix1(int[][] matrix, int target)
        {
            if (matrix.Length == 0)
                return false;
            int row = 0;
            int col = matrix[0].Length - 1;
            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == target)
                    return true;
                else if (matrix[row][col] < target)
                    row++;
                else if (matrix[row][col] > target)
                    col--;
            }
            return false;
        }
        static bool SearchMatrix2(int[][] matrix, int target)
        {
            int row = matrix.Length;
            if (row == 0)
                return false;
            int col = matrix[0].Length;
            if (col == 0)
                return false;
            int rowIndex = 0;
            while (rowIndex < row)
            {
                if (matrix[rowIndex][col - 1] < target)
                    rowIndex++;
                else
                    break;
            }
            if (rowIndex >= row)
                return false;
            for (int colIndex = 0; colIndex < col; colIndex++)
                if (matrix[rowIndex][colIndex] == target)
                    return true;
            return false;
        }
    }
}
