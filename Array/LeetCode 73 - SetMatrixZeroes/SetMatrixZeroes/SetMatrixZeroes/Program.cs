//创建列表rows和cols分别记录应该修改的行和列。
//遍历matrix数组，将等于0的元素的坐标记录入rows和cols。
//遍历rows和cols，将其中需要修改的行和列上所有元素改为0。
using System;
using System.Collections.Generic;

namespace SetMatrixZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public void SetZeroes(int[][] matrix)
        {
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }
            foreach (var row in rows)
                for (int i = 0; i < matrix[row].Length; i++)
                    matrix[row][i] = 0;
            foreach (var col in cols)
                for (int i = 0; i < matrix.Length; i++)
                    matrix[i][col] = 0;
        }
    }
}
