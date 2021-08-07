using System;

namespace CheckIfMoveIsLegal
{
	class Program
	{
		static void Main(string[] args)
		{
			char[][] board = new[]
			{
				new[] {'.', '.', '.', '.', '.', '.', '.', '.'},
				new[] {'.', 'B', '.', '.', 'W', '.', '.', '.'},
				new[] {'.', '.', 'W', '.', '.', '.', '.', '.'},
				new[] {'.', '.', '.', 'W', 'B', '.', '.', '.'},
				new[] {'.', '.', '.', '.', '.', '.', '.', '.'},
				new[] {'.', '.', '.', '.', 'B', 'W', '.', '.'},
				new[] {'.', '.', '.', '.', '.', '.', 'W', '.'},
				new[] {'.', '.', '.', '.', '.', '.', '.', 'B'},
			};
			int rMove = 4, cMove = 4;
			char color = 'B';
			Console.WriteLine(CheckMove(board, rMove, cMove, color));
		}

		public static bool CheckMove(char[][] board, int rMove, int cMove, char color)
		{
			int[] dr = {-1, 1, 0, 0, -1, 1, -1, 1};
			int[] dc = {0, 0, -1, 1, -1, -1, 1, 1};
			board[rMove][cMove] = color;
			for (int i = 0; i < 8; i++)
			{
				int countDiff = 0, countEmpty = 0, countSame = 0;
				for (int j = 1; j < 8; j++)
				{
					int newR = rMove + dr[i] * j;
					int newC = cMove + dc[i] * j;
					if(newR < 0 || newR >= board.Length || newC < 0 || newC >= board[0].Length)
						break;
					if (board[newR][newC] == color)
					{
						countSame++;
						break;
					}
					if (board[newR][newC] == '.')
						countEmpty++;
					else
						countDiff++;
				}
				if (countDiff > 0 && countEmpty == 0 && countSame == 1)
					return true;
			}
			return false;
		}
	}
}
