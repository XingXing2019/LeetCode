﻿//创建row和col记录数组的行数和列数。创建r和c指针分别指向第一行和最后一列。
//在r和c都不越界的条件下遍历数组。如果r和c指向的数字等于target则返回true。如果大于则使c左移一列。如果小于，则使r下移一行。
//遍历结束后仍未返回true，则返回false。
using System;

namespace SearchA2DMatrixII
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }
        static bool SearchMatrix_TwoPointers(int[][] matrix, int target)
        {
            int row = 0, col = matrix[0].Length - 1;
            while (row < matrix.Length && col >= 0)
            {
                if (matrix[row][col] == target) return true;
                if (matrix[row][col] > target) col--;
                else row++;
            }
            return false;
        }
        static bool SearchMatrix_BinarySearch(int[][] matrix, int target)
        {
            foreach (var row in matrix)
            {
                if (row[0] > target) break;
                if (Array.BinarySearch(row, target) >= 0)
                    return true;
            }
            return false;
        }
        static bool SearchMatrix_DivideAndConquer(int[][] matrix, int target)
        {
            if (matrix.Length == 1) return Array.BinarySearch(matrix[0], target) >= 0;
            return DivideAndConquer(matrix, 0, matrix[0].Length - 1, target);
        }
        static bool DivideAndConquer(int[][] matrix, int x, int y, int target)
        {
            if (x >= matrix.Length || y < 0) return false;
            if (matrix[x][y] == target) return true;
            var newY = Array.BinarySearch(matrix[x], 0, y + 1, target);
            if (newY >= 0) return true;
            newY = -(1 + newY) - 1;
            int li = x, hi = matrix.Length;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                if (matrix[mid][y] == target) return true;
                if (matrix[mid][y] > target) hi = mid;
                else li = mid + 1;
            }
            if (y == 0) return li < matrix.Length && matrix[li][y] == target;
            return DivideAndConquer(matrix, li, newY, target);
        }

        static bool SearchMatrix2(int[,] matrix, int target)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            if (row == 0 || col == 0)
                return false;
            int rowLi = 0, colLi = 0;
            int rowHi = row - 1;
            int colHi = col - 1;
            while (rowLi < rowHi)
            {
                int rowMid = rowLi + (rowHi - rowLi) / 2;
                if (matrix[rowMid, 0] > target)
                    rowHi = rowMid;
                else if (matrix[rowMid, 0] < target)
                    rowLi = rowMid + 1;
                else
                    return true;
            }
            while (colLi < colHi)
            {
                int colMid = colLi + (colHi - colLi) / 2;
                if (matrix[0, colMid] > target)
                    colHi = colMid;
                else if (matrix[0, colMid] < target)
                    colLi = colMid + 1;
                else
                    return true;
            }
            for (int r = 0; r <= rowLi; r++)
                for (int c = 0; c <= colLi; c++)
                    if (matrix[r, c] == target)
                        return true;
            return false;
        }
    }
}
