//遍历每一行，如果是0开头则无需特殊操作，如果是1开头就每个元素取反。然后将其转换成string存入字典。
//最后统计字典中哪个string出现的次数最多。
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlipColumnsForMaximumNumberOfEqualRows
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxEqualRowsAfterFlips(int[][] matrix)
        {
            var dictionary = new Dictionary<string, int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 1)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                        matrix[i][j] = matrix[i][j] == 0 ? 1 : 0;
                }
                string tem = string.Join(' ', matrix[i]);
                if (!dictionary.ContainsKey(tem))
                    dictionary[tem] = 1;
                else
                    dictionary[tem]++;
            }
            return dictionary.Max(d => d.Value);
        }
    }
}
