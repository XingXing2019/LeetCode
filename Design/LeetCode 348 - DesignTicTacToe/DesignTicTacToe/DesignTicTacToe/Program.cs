using System;

namespace DesignTicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new TicTacToe(3);
            Console.WriteLine(obj.Move(0, 0, 1));
            Console.WriteLine(obj.Move(0, 2, 2));
            Console.WriteLine(obj.Move(2, 2, 1));
            Console.WriteLine(obj.Move(1, 1, 2));
            Console.WriteLine(obj.Move(2, 0, 1));
            Console.WriteLine(obj.Move(1, 0, 2));
            Console.WriteLine(obj.Move(2, 1, 1));
        }
    }
    public class TicTacToe
    {
        private readonly int[][] board;
        public TicTacToe(int n)
        {
            board = new int[n][];
            for (int i = 0; i < board.Length; i++)
                board[i] = new int[n];
        }
        public int Move(int row, int col, int player)
        {
            board[row][col] = player;
            int[] dr = { -1, 1, 0, 0, -1, 1, -1, 1 };
            int[] dc = { 0, 0, -1, 1, -1, 1, 1, -1 };
            var record = new int[8];
            for (int i = 0; i < 8; i++)
            {
                int count = 0;
                for (int j = 1; j < board.Length; j++)
                {
                    int newRow = row + dr[i] * j;
                    int newCol = col + dc[i] * j;
                    if (newRow < 0 || newRow >= board.Length || newCol < 0 || newCol >= board.Length || board[newRow][newCol] != player)
                        break;
                    if (board[newRow][newCol] == player)
                        count++;
                }
                record[i] = count;
            }
            for (int i = 0; i < record.Length - 1; i += 2)
            {
                if (record[i] + record[i + 1] == board.Length - 1)
                    return player;
            }
            return 0;
        }
    }
}
