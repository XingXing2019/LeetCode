//贪心算法，遍历A的每一行，如果第一个数字为0，则翻转该行。遍历A的每一列，统计1的个数，如果1的个数小于0的个数，则翻转该列。
//最后计算A的分数。
using System;

namespace ScoreAfterFlippingMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] A = new int[3][];
            A[0] = new int[] { 0, 0, 1, 1 };
            A[1] = new int[] { 1, 0, 1, 0 };
            A[2] = new int[] { 1, 1, 0, 0 };
            Console.WriteLine(MatrixScore(A));
        }
        static int MatrixScore(int[][] A)
        {
            int row = A.Length;
            int col = A[0].Length;
            for (int r = 0; r < row; r++)
            {
                if (A[r][0] == 0)
                    for (int c = 0; c < col; c++)
                        A[r][c] = A[r][c] == 0 ? 1 : 0;
            }
            for (int c = 0; c < col; c++)
            {
                int countOne = 0;
                for (int r = 0; r < row; r++)
                    if (A[r][c] == 1)
                        countOne++;
                if (countOne < row - countOne)
                    for (int r = 0; r < row; r++)
                        A[r][c] = A[r][c] == 0 ? 1 : 0;
            }
            int res = 0;
            for (int r = 0; r < row; r++)
            {
                int tem = A[r][0];
                for (int c = 1; c < col; c++)
                    tem = tem * 2 + A[r][c];
                res += tem;
            }
            return res;
        }
    }
}
