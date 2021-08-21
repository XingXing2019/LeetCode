using System;

namespace SudokuSolver
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public void SolveSudoku(char[][] board)
		{
			var rowUsed = new bool[9][];
			var colUsed = new bool[9][];
			var sqrtUsed = new bool[9][];
			for (int i = 0; i < 9; i++)
			{
				rowUsed[i] = new bool[9];
				colUsed[i] = new bool[9];
				sqrtUsed[i] = new bool[9];
			}
			for (int r = 0; r < 9; r++)
			{
				for (int c = 0; c < 9; c++)
				{
					if(board[r][c] == '.') continue;
					int num = board[r][c] - '1';
					int index = r / 3 * 3 + c / 3;
					rowUsed[r][num] = true;
					colUsed[c][num] = true;
					sqrtUsed[index][num] = true;
				}
			}
			DFS(board, rowUsed, colUsed, sqrtUsed);
		}

		private bool DFS(char[][] board, bool[][] rowUsed, bool[][] colUsed, bool[][] sqrtUsed)
		{
			for (int r = 0; r < 9; r++)
			{
				for (int c = 0; c < 9; c++)
				{
					if(board[r][c]  != '.') continue;
					for (int i = 0; i < 9; i++)
					{
						int index = r / 3 * 3 + c / 3;
						if (rowUsed[r][i] || colUsed[c][i] || sqrtUsed[index][i]) continue;
						rowUsed[r][i] = true;
						colUsed[c][i] = true;
						sqrtUsed[index][i] = true;
						board[r][c] = (char) (i + '1');
						if (DFS(board, rowUsed, colUsed, sqrtUsed))
							return true;
						rowUsed[r][i] = false;
						colUsed[c][i] = false;
						sqrtUsed[index][i] = false;
						board[r][c] = '.';
					}
					return false;
				}
			}
			return true;
		}
	}
}
