//创建DFS方法辅助深度优先遍历。在board的四条边界上调用DFS，将与边界相连通的O暂时替换为*。
//遍历board将所有剩下的O替换成X，将所有*替换成O。
using System;

namespace SurroundedRegions
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[5][];
            board[0] = new char[5] { 'O', 'X', 'X', 'O', 'X' };
            board[1] = new char[5] { 'X', 'O', 'O', 'X', 'O' };
            board[2] = new char[5] { 'X', 'O', 'X', 'O', 'X' };
            board[3] = new char[5] { 'O', 'X', 'O', 'O', 'O' };
            board[4] = new char[5] { 'X', 'X', 'O', 'X', 'O' };
            Solve(board);
        }
        static void Solve(char[][] board)
        {
            int row = board.Length;
            if (row == 0)
                return;
            int col = board[0].Length;
            if (col == 0)
                return;
            int[][] mark = new int[row][];
            for (int i = 0; i < row; i++)
                mark[i] = new int[col];
            for (int i = 0; i < row; i++)
            {
                if (board[i][0] == 'O' && mark[i][0] == 0)
                    DFS(board, mark, i, 0);
                if (board[i][col - 1] == 'O' && mark[i][col - 1] == 0)
                    DFS(board, mark, i, col - 1);
            }
            for (int i = 0; i < col; i++)
            {
                if (board[0][i] == 'O' && mark[0][i] == 0)
                    DFS(board, mark, 0, i);
                if (board[row - 1][i] == 'O' && mark[row - 1][i] == 0)
                    DFS(board, mark, row - 1, i);
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    else if (board[i][j] == '*')
                        board[i][j] = 'O';
                }
            }
        }
        static void DFS(char[][] board, int[][] mark, int x, int y)
        {
            mark[x][y] = 1;
            board[x][y] = '*';
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            for (int i = 0; i < 4; i++)
            {
                int newX = dx[i] + x;
                int newY = dy[i] + y;
                if (newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length)
                    continue;
                if (board[newX][newY] == 'O' && mark[newX][newY] == 0)
                    DFS(board, mark, newX, newY);
            }
        }
    }
}
