//创建一个record复制board，再统计每个E周围有几个雷，如果不为0，则将E替换为雷数。
//再深搜board，如果当前点为数字，则返回。 否则深搜八个相邻格子中未被访问过，且为E的格子，将其替换为B。对于record中为数字的格子，则用该数字替换board中相应位置的原有字母。
//最后还要将click点换成record中相应位置的数字。如果该位置不是数字，则换为B。
using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[4][];
            board[0] = new char[] { 'E', 'E', 'E', 'E', 'E' };
            board[1] = new char[] { 'E', 'E', 'M', 'E', 'E' };
            board[2] = new char[] { 'E', 'E', 'E', 'E', 'E' };
            board[3] = new char[] { 'E', 'E', 'E', 'E', 'E' };
            int[] click = {3, 0};
            Console.WriteLine(UpdateBoard(board, click));
        }
        static char[][] UpdateBoard(char[][] board, int[] click)
        {
            char[][] record = new char[board.Length][];
            GenerateRecord(board, record);
            int x = click[0], y = click[1];
            int[][] mark = new int[board.Length][];
            for (int i = 0; i < mark.Length; i++)
                mark[i] = new int[board[0].Length];
            if (record[x][y] == 'M')
            {
                board[x][y] = 'X';
                return board;
            }
            DFS(x, y, mark, board, record);
            board[x][y] = char.IsDigit(record[x][y]) ? record[x][y] : 'B';
            return board;
        }

        static void DFS(int x, int y, int[][] mark, char[][] board, char[][] record)
        {
            mark[x][y] = 1;
            if (record[x][y] - '0' >= 1 && record[x][y] - '0' <= 8)
                return;
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int i = 0; i < 8; i++)
            {
                int newX = x + dx[i];
                int newY = y + dy[i];
                if (newX < 0 || newX >= record.Length || newY < 0 || newY >= record[0].Length)
                    continue;
                if (mark[newX][newY] == 0 && record[newX][newY] == 'E')
                {
                    board[newX][newY] = 'B';
                    DFS(newX, newY, mark, board, record);
                }
                else if (mark[newX][newY] == 0 && char.IsDigit(record[newX][newY]))
                    board[newX][newY] = record[newX][newY];
            }
        }
        static void GenerateRecord(char[][] board, char[][] record)
        {
            for (int i = 0; i < record.Length; i++)
            {
                record[i] = new char[board[0].Length];
                for (int j = 0; j < record[i].Length; j++)
                    record[i][j] = board[i][j];
            }
            int[] dx = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dy = { -1, 0, 1, -1, 1, -1, 0, 1 };
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    if (board[r][c] != 'E')
                        continue;
                    int count = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        int newX = dx[i] + r;
                        int newY = dy[i] + c;
                        if (newX >= 0 && newX < board.Length && newY >= 0 && newY < board[0].Length && board[newX][newY] == 'M')
                            count++;
                    }
                    if (count != 0)
                        record[r][c] = (char)(count + '0');
                }
            }
        }

    }
}
