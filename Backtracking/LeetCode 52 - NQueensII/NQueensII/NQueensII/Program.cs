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
            var board = new int[n][];
            for (int i = 0; i < board.Length; i++)
                board[i] = new int[n];
            var res = 0;
            DFS(0, n, board, ref res);
            return res;
        }

        static void UpdateBoard(int r, int c, int n, int[][] board)
        {
            int[] dr = { -1, 1, 0, 0, -1, 1, -1, 1 };
            int[] dc = { 0, 0, -1, 1, -1, -1, 1, 1 };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int newR = r + dr[j] * i;
                    int newC = c + dc[j] * i;
                    if (newR < 0 || newR >= n || newC < 0 || newC >= n) continue;
                    board[newR][newC] = 1;
                }
            }
        }

        static void DFS(int r, int n, int[][] board, ref int res)
        {
            if (r == n)
            {
                res++;
                return;
            }
            for (int c = 0; c < n; c++)
            {
                if (board[r][c] == 1) continue;
                var record = new int[n][];
                for (int i = 0; i < record.Length; i++)
                {
                    record[i] = new int[n];
                    Array.Copy(board[i], record[i], n);
                }
                UpdateBoard(r, c, n, board);
                DFS(r + 1, n, board, ref res);
                board = record;
            }
        }
    }
}
