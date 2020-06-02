//创建与board大小相同的二维数组onesAround，用于记录每个格周围1的个数。
//遍历board数组，如果当前元素为1，则将周围8个格数字加一。但是需要注意检查坐标不要越界。如果当前格在边或者角上，则应相应减少需要加一格子的数量。
//得到onesAround数组后，遍历board数组，根据题目要求和onesAround中记录的数据，最遍历到的坐标做出相应的修改。
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] borad = new int[4][];
            borad[0] = new int[] { 0, 1, 0 };
            borad[1] = new int[] { 0, 0, 1 };
            borad[2] = new int[] { 1, 1, 1 };
            borad[3] = new int[] { 0, 0, 0 };
            GameOfLife(borad);
        }
        static void GameOfLife(int[][] board)
        {
            int row = board.Length;
            if (row == 0)
                return;
            int col = board[0].Length;
            int[,] onesAround = new int[row, col];
            for (int r = 0; r < row; r++)
                for (int c = 0; c < col; c++)
                    if (board[r][c] == 1)
                    {
                        if (r > 0)
                        {
                            if (c > 0)
                                onesAround[r - 1, c - 1]++;
                            if (c < col - 1)
                                onesAround[r - 1, c + 1]++;
                            onesAround[r - 1, c]++;
                        }
                        if (r < row - 1)
                        {
                            if (c > 0)
                                onesAround[r + 1, c - 1]++;
                            if (c < col - 1)
                                onesAround[r + 1, c + 1]++;
                            onesAround[r + 1, c]++;
                        }
                        if (c > 0)
                            onesAround[r, c - 1]++;
                        if (c < col - 1)
                            onesAround[r, c + 1]++;
                    }
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (board[r][c] == 1)
                    {
                        if (onesAround[r, c] < 2)
                            board[r][c] = 0;
                        else if (onesAround[r, c] > 3)
                            board[r][c] = 0;
                    }
                    else
                    {
                        if (onesAround[r, c] == 3)
                            board[r][c] = 1;
                    }
                }
            }
        }
    }
}
