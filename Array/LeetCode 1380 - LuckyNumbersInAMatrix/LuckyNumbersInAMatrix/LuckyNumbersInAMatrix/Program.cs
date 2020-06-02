using System;
using System.Collections.Generic;

namespace LuckyNumbersInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] {3, 7, 8};
            matrix[1] = new int[] {9, 11, 13};
            matrix[2] = new int[] {15, 16, 17};
            Console.WriteLine(LuckyNumbers(matrix));
        }
        static IList<int> LuckyNumbers(int[][] matrix)
        {
             var record = new Dictionary<int, int>();
             var res = new List<int>();
             for (int i = 0; i < matrix.Length; i++)
             {
                 var min = int.MaxValue;
                 var pos = -1;
                 for (int j = 0; j < matrix[0].Length; j++)
                 {
                     if (min > matrix[i][j])
                     {
                         min = matrix[i][j];
                         pos = i * 100 + j;
                     }
                 }
                 if (!record.ContainsKey(pos))
                     record[pos] = 1;
             }

             for (int j = 0; j < matrix[0].Length; j++)
             {
                 var max = int.MinValue;
                 var pos = -1;
                 for (int i = 0; i < matrix.Length; i++)
                 {
                     if (max < matrix[i][j])
                     {
                         max = matrix[i][j];
                         pos = i * 100 + j;
                     }
                 }
                 if (record.ContainsKey(pos))
                     res.Add(matrix[pos / 100][pos - (pos / 100) * 100]);
             }
             return res;
        }
    }
}
