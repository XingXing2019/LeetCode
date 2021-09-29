using System;
using System.Linq;

namespace CheckIfWordCanBePlacedInCrossword
{
	class Program
	{
		static void Main(string[] args)
		{
			char[][] board = new[]
			{
				new[] {' ', '#', 'a'},
				new[] {' ', '#', 'c'},
				new[] {' ', '#', 'a'},
			};
			var word = "ac";

			Console.WriteLine(PlaceWordInCrossword(board, word));
		}

		public static bool PlaceWordInCrossword(char[][] board, string word)
		{
			var reversed = string.Join("", word.Reverse());
			for (int x = 0; x < board.Length; x++)
			{
				for (int y = 0; y < board[0].Length; y++)
				{
					var canPlace = CheckVertical(board, x, y, word) || CheckVertical(board, x, y, reversed) ||
								   CheckHorizontal(board, x, y, word) || CheckHorizontal(board, x, y, reversed);
					if (canPlace)
						return true;
				}
			}
			return false;
		}

		public static bool CheckVertical(char[][] board, int x, int y, string word)
		{
			if (x + word.Length > board.Length)
				return false;
			if (x != 0 && (char.IsLetter(board[x - 1][y]) || board[x - 1][y] == ' '))
				return false;
			if (x + word.Length < board.Length && (char.IsLetter(board[x + word.Length][y]) || board[x + word.Length][y] == ' '))
				return false;
			for (int i = 0; i < word.Length; i++)
			{
				if (board[x + i][y] != ' ' && board[x + i][y] != word[i])
					return false;
			}
			return true;
		}

		public static bool CheckHorizontal(char[][] board, int x, int y, string word)
		{
			if (y + word.Length > board[0].Length)
				return false;
			if (y != 0 && (char.IsLetter(board[x][y - 1]) || board[x][y - 1] == ' '))
				return false;
			if (y + word.Length < board[0].Length && (char.IsLetter(board[x][y + word.Length]) || board[x][y + word.Length] == ' '))
				return false;
			for (int i = 0; i < word.Length; i++)
			{
				if (board[x][y + i] != ' ' && board[x][y + i] != word[i])
					return false;
			}
			return true;
		}
	}
}
