using System;

namespace AvailableCapturesForRook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int NumRookCaptures(char[][] board)
        {
            int rookX = -1, rookY = -1;
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[0].Length; c++)
                {
                    if (board[r][c] == 'R')
                    {
                        rookX = r;
                        rookY = c;
                        break;
                    }
                }
            }
            int count = 0;
            int[] dx = {1, -1, 0, 0};
            int[] dy = {0, 0, 1, -1};
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int newX = rookX + dx[i] * j;
                    int newY = rookY + dy[i] * j;
                    if (newX < 0 || newX >= 8 || newY < 0 || newY >= 8 || board[newX][newY] == 'B')
                        break;
                    if (board[newX][newY] == 'p')
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }
    }
}
