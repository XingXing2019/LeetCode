//创建二维数组dp，大小和matrix相同。dp[i,j]代表以该点为右下角，原点为左上角构成的区域内，最大正方形的边长。
//如果matrix在该坐标位置为0，则说明以该坐标为右下角不能构成区域，则改坐标在dp中设为0.
//先将dp第一行和第一列设为去matrix相同。
//遍历dp，如果当前坐标在matrix中不为0，则将dp中改坐标设为其左，上和左上角位置最小值加一。同时用maxLen记录dp中的最大值。
//最后返回maxLen的平方。
using System;

namespace MaximalSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] matrix = new char[4][]
            {
                new char[]{'1', '0', '1', '0', '0'}, 
                new char[]{'1', '0', '1', '1', '1'}, 
                new char[]{'1', '1', '1', '1', '1'}, 
                new char[]{'1', '0', '0', '1', '0'}
            };

            Console.WriteLine(MaximalSquare(matrix));
        }
        static int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
                return 0;
            int row = matrix.Length, col = matrix[0].Length;
            int maxLen = 0;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (r != 0 && c != 0 && matrix[r][c] != '0')
                        matrix[r][c] = (char)(Math.Min(matrix[r - 1][c - 1], Math.Min(matrix[r - 1][c], matrix[r][c - 1])) + 1);
                    maxLen = Math.Max(maxLen, matrix[r][c] - '0');
                }
            }
            return maxLen * maxLen;
        }
    }
}
