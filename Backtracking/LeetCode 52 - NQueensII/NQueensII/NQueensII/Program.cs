//思路与LeetCode 51相同。使用回溯算法试着找出摆放皇后的所有方法。
using System;
using System.Collections.Generic;

namespace NQueensII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            Console.WriteLine(TotalNQueens(n));
        }
        static int TotalNQueens(int n)
        {
            int[] res = new int[1];
            int[][] mark = new int[n][];
            for (int i = 0; i < n; i++)
                mark[i] = new int[n];
            Generate(0, n, res, mark);
            return res[0];
        }
        static void PutDownQueen(int n, int x, int y, int[][] mark)
        {
            int[] dx = { -1, 1, 0, 0, 1, -1, 1, -1 };
            int[] dy = { 0, 0, -1, 1, 1, -1, -1, 1 };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int newX = x + dx[j] * i;
                    int newY = y + dy[j] * i;
                    if (newX >= 0 && newX < n && newY >= 0 && newY < n)
                        mark[newX][newY] = 1;
                }
            }
        }
        static void Generate(int k, int n, int[] res, int[][] mark)
        {
            if(k == n)
            {
                res[0]++;
                return;
            }
            for (int i = 0; i < n; i++)
            {
                if(mark[k][i] == 0)
                {
                    int[][] temMark = new int[n][];
                    for (int x = 0; x < n; x++)
                    {
                        temMark[x] = new int[n];
                        for (int y = 0; y < n; y++)
                            temMark[x][y] = mark[x][y];
                    }
                    PutDownQueen(n, k, i, mark);
                    Generate(k + 1, n, res, mark);
                    mark = temMark;
                }
            }
        }
    }
}
