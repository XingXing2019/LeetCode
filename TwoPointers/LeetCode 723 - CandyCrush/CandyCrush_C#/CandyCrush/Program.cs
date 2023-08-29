using System;

namespace CandyCrush
{
	class Program
	{
		static void Main(string[] args)
		{
			var board = new int[][]
			{
				new[] {110, 5, 112, 113, 114},
				new[] {210, 211, 5, 213, 214},
				new[] {310, 311, 3, 313, 314},
				new[] {410, 411, 412, 5, 414},
				new[] {5, 1, 512, 3, 3},
				new[] {610, 4, 1, 613, 614},
				new[] {710, 1, 2, 713, 714},
				new[] {810, 1, 2, 1, 1},
				new[] {1, 1, 2, 2, 2},
				new[] {4, 1, 4, 4, 1014},
			};
			Console.WriteLine(CandyCrush(board));
		}
		public static int[][] CandyCrush(int[][] board)
		{
			FlagRow(board);
			FlagCol(board);
			var todoMore = false;
			for (int c = 0; c < board[0].Length; c++)
			{
				int hi = board.Length -1, li = board.Length - 1;
				while (li >= 0)
				{
					if (board[li][c] < 0)
					{
						li--;
						continue;
					}
					board[hi--][c] = board[li--][c];
				}
				while (hi >= 0)
				{
					todoMore = true;
					board[hi--][c] = 0;
				}
			}
			return todoMore ? CandyCrush(board) : board;
		}

		public static void FlagRow(int[][] board)
		{
			for (int r = 0; r < board.Length; r++)
			{
				int li = 0, hi = 0, count = 0;
				while (hi < board[r].Length)
				{
					if (Math.Abs(board[r][hi]) == Math.Abs(board[r][li]))
						count++;
					else
					{
						if (count >= 3)
						{
							while (li != hi)
								board[r][li] = -Math.Abs(board[r][li++]);
						}
						else
							li = hi;
						count = 1;
					}
					hi++;
				}
				if (count < 3) continue;
				while (li != hi)
					board[r][li] = -Math.Abs(board[r][li++]);
			}
		}

		public static void FlagCol(int[][] board)
		{
			for (int c = 0; c < board[0].Length; c++)
			{
				int li = 0, hi = 0, count = 0;
				while (hi < board.Length)
				{
					if (Math.Abs(board[hi][c]) == Math.Abs(board[li][c]))
						count++;
					else
					{
						if (count >= 3)
						{
							while (li != hi)
								board[li][c] = -Math.Abs(board[li++][c]);
						}
						else
							li = hi;
						count = 1;
					}
					hi++;
				}
				if (count < 3) continue;
				while (li != hi)
					board[li][c] = -Math.Abs(board[li++][c]);
			}
		}
	}
}
