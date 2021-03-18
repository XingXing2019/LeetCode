//创建board棋盘，除了左下和右下，初始值都设为1.
//循环N-1次，每次遍历棋盘，将每个点的值设为其能到达点的值之和，并将其存入一个新棋盘。循环结束后用新棋盘替换老棋盘。并对每个值按要求取模。
//最后统计总数，并取模返回。
using System;

namespace KnightDialer
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 5000;
            Console.WriteLine(KnightDialer(N));
        }
        static int KnightDialer(int N)
        {
            if (N == 1)
                return 10;
            long[][] board = new long[4][];
            for (int i = 0; i < 4; i++)
                board[i] = new long[] { 1, 1, 1 };
            for (int n = 0; n < N - 1; n++)
            {
                long[][] newBoard = new long[4][];
                for (int i = 0; i < 4; i++)
                    newBoard[i] = new long[3];
                newBoard[0][0] = board[2][1] + board[1][2];
                newBoard[0][1] = board[2][0] + board[2][2];
                newBoard[0][2] = board[1][0] + board[2][1];
                newBoard[1][0] = board[0][2] + board[2][2] + board[3][1];
                newBoard[1][2] = board[0][0] + board[2][0] + board[3][1];
                newBoard[2][0] = board[0][1] + board[1][2];
                newBoard[2][1] = board[0][0] + board[0][2];
                newBoard[2][2] = board[0][1] + board[1][0];
                newBoard[3][1] = board[1][0] + board[1][2];
                board = newBoard;
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 3; j++)
                        board[i][j] %= 1000000007;
            }
            long res = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    res += board[i][j];
            return (int)(res % 1000000007);
        }
    }
}
