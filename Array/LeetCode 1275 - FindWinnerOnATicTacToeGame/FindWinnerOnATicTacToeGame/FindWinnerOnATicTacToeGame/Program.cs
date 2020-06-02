//先将所有move在棋盘上做标记，再遍历棋盘返回相应的结果。
using System;

namespace FindWinnerOnATicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] moves = new int[3][];
            moves[0] = new int[2] { 1, 0 };
            moves[1] = new int[2] { 2, 0 };
            moves[2] = new int[2] { 0, 1 };
            Console.WriteLine(Tictactoe(moves));
        }
        static string Tictactoe(int[][] moves)
        {
            string[,] board = new string[3, 3];
            bool isA = true;
            foreach (var move in moves)
            {
                if (isA)
                {
                    board[move[0], move[1]] = "A";
                    isA = false;
                }
                else
                {
                    board[move[0], move[1]] = "B";
                    isA = true;
                }
            }
            for (int i = 0; i < 3; i++)
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && (board[i, 0] == "A" || board[i, 0] == "B"))
                    return board[i, 0];
            for (int i = 0; i < 3; i++)
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && (board[0, i] == "A" || board[0, i] == "B"))
                    return board[0, i];
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && (board[0, 0] == "A" || board[0, 0] == "B"))
                return board[0, 0];
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && (board[0, 2] == "A" || board[0, 2] == "B"))
                return board[0, 2];
            if(moves.Length == 9)
                return "Draw";
            return "Pending";
        }
    }
}
