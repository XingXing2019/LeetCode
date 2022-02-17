using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightProbabilityInChessboard
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 4, K = 4, r = 1, c = 2;
            Console.WriteLine(KnightProbability(N, K, r, c));
        }
        static double KnightProbability(int N, int K, int r, int c)
        {
            double[][] board = new double[N][];
            for (int i = 0; i < board.Length; i++)
                board[i] = new double[N];
            int[] dx = {-2, -1, 1, 2, 2, 1, -1, -2};
            int[] dy = {-1, -2, -2, -1, 1, 2, 2, 1};
            board[r][c] = 1;
            for (int k = 0; k < K; k++)
            {
                double[][] temBoard = new double[N][];
                for (int i = 0; i < temBoard.Length; i++)
                    temBoard[i] = new double[N];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        for (int m = 0; m < 8; m++)
                        {
                            int newX = i + dx[m];
                            int newY = j + dy[m];
                            if (newX >= 0 && newX < N && newY >= 0 && newY < N)
                                temBoard[newX][newY] += board[i][j];
                        }
                    }
                }
                board = temBoard;
            }
            double total = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    total += board[i][j];
            return total / Math.Pow(8, K);
        }
    }
}
