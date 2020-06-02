//遍历行，列个九宫格，按照要求检查是否有重复的数字出现，查出重复数字返回false，否则遍历结束后返回true。
using System;

namespace ValidSudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            char[][] board = new char[9][];
            board[0] = new char[9] { '8', '3', '.', '.', '7', '.', '.', '.', '.' };
            board[1] = new char[9] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
            board[2] = new char[9] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
            board[3] = new char[9] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
            board[4] = new char[9] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
            board[5] = new char[9] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
            board[6] = new char[9] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
            board[7] = new char[9] { '.', '.', '.', '4', '1', '9', '.', '.', '.' };
            board[8] = new char[9] { '.', '.', '.', '.', '.', '8', '.', '7', '9' };
            Console.WriteLine(IsValidSudoku(board));
        }
        static bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                int[] recordRow = new int[10];
                int[] recordCol = new int[10];
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        recordRow[board[i][j] - '0']++;
                        if (recordRow[board[i][j] - '0'] > 1)
                            return false;
                    }                        
                    if (board[j][i] != '.')
                    {
                        recordCol[board[j][i] - '0']++;
                        if (recordCol[board[j][i] - '0'] > 1)
                            return false;
                    }
                }
            }
            for (int i = 0; i < 9; i+=3)
            {
                for (int j = 0; j < 9; j+=3)
                {
                    int[] record = new int[10];
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (board[x + i][y + j] != '.')
                            {
                                record[board[x + i][y + j] - '0']++;
                                if (record[board[x + i][y + j] - '0'] > 1)
                                    return false;
                            }                               
                        }
                    }
                }
            }
            return true;
        }
    }
}
