//创建row和col数组记录每一行每一列被改变的次数。遍历indices，将改变的次数记入row和col。
//统计被改变奇数次行和列的个数。结果就是被改变奇数次行的个数乘以被改变偶数次列的个数加上被改变奇数次列的个数乘以被改变偶数次行的个数。
using System;

namespace CellsWithOddValuesInAMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2, m = 2;
            int[][] indices = new int[2][];
            indices[0] = new int[] { 1, 1 };
            indices[1] = new int[] { 0, 0 };
            Console.WriteLine(OddCells(n, m, indices));
        }
        static int OddCells(int n, int m, int[][] indices)
        {
            int[] row = new int[n];
            int[] col = new int[m];
            for (int i = 0; i < indices.Length; i++)
            {
                row[indices[i][0]]++;
                col[indices[i][1]]++;
            }
            int oddRow = 0;
            for (int i = 0; i < row.Length; i++)
                if (row[i] % 2 != 0)
                    oddRow++;
            int oddCol = 0;
            for (int i = 0; i < col.Length; i++)
                if (col[i] % 2 != 0)
                    oddCol++;
            int res = oddRow * (m - oddCol) + oddCol * (n - oddRow);
            return res;
        }
    }
}
