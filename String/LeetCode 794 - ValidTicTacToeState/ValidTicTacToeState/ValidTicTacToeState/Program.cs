using System;

namespace ValidTicTacToeState
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] board = { "OXX", "XOX", "OXO" };
			Console.WriteLine(ValidTicTacToe(board));
		}
		
		public static bool ValidTicTacToe(string[] board)
		{
			int o = 0, x = 0, xWin = 0, oWin = 0;
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board.Length; j++)
				{
					if (board[i][j] == 'X') x++;
					else if (board[i][j] == 'O') o++;
				}
			}

			for (int i = 0; i < board.Length; i++)
			{
				if (board[i] == "XXX") xWin++;
				else if (board[i] == "OOO") oWin++;
			}

			for (int j = 0; j < board[0].Length; j++)
			{
				int countX = 0, countO = 0;
				for (int i = 0; i < board.Length; i++)
				{
					if (board[i][j] == 'X') countX++;
					else if (board[i][j] == 'O') countO++;
				}
				if (countX == 3) xWin++;
				if (countO == 3) oWin++;
			}
			if (board[0][0] == 'X' && board[1][1] == 'X' && board[2][2] == 'X') xWin++;
			if (board[2][0] == 'X' && board[1][1] == 'X' && board[0][2] == 'X') xWin++;
			if (board[0][0] == 'O' && board[1][1] == 'O' && board[2][2] == 'O') oWin++;
			if (board[2][0] == 'O' && board[1][1] == 'O' && board[0][2] == 'O') oWin++;
			return (x - o == 0 && xWin == 0 || x - o == 1 && oWin == 0) && (xWin * oWin == 0 || xWin == 1 && oWin == 0 || xWin == 0 && oWin == 1);
		}
	}
}
