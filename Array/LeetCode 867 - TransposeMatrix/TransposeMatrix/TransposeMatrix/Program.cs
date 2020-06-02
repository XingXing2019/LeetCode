//创建row和col记录A的行数和列数，创建res数组记录结果，行数为col列数为row。
//创建r，c指针用于给res中元素定位。遍历A数组，将结果记录如r和c的位置，接着让r下移一行。 当r到最后一行后，让c右移一列，并将r归零。
using System;

namespace TransposeMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A = new int[3][];
            A[0] = new int[] { 1, 2, 3, 5 };
            A[1] = new int[] { 4, 5, 6, 7 };
            A[2] = new int[] { 7, 8, 9, 10 };
            Console.WriteLine(Transpose(A));
        }
        static int[][] Transpose(int[][] A)
        {
            int row = A.Length;
            int col = A[0].Length;
            int[][] res = new int[col][];
            for (int i = 0; i < col; i++)
                res[i] = new int[row];
            int r = 0, c = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    res[r][c] = A[i][j];
                    r++;
                    if (r == col)
                    {
                        c++;
                        r = 0;
                    }
                }
            }
            return res;
        }
    }
}
