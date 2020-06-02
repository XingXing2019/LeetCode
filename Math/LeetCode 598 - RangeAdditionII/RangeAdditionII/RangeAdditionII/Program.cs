//思路为找到多轮操作重叠的行数和列数。先假设拥有最大数字的行数和列数分别为m和n。
//遍历ops数组，每次操作受到影响的行数和一定等于当前行数与ops[i]中行数较小的值。列数同理。最后返回剩余的行数乘以剩余的列数。
using System;

namespace RangeAdditionII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int MaxCount(int m, int n, int[][] ops)
        {
            int row = m;
            int col = n;
            for (int i = 0; i < ops.Length; i++)
            {
                row = Math.Min(row, ops[i][0]);
                col = Math.Min(col, ops[i][1]);
            }
            return row * col;
        }
    }
}
