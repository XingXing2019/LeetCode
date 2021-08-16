using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

namespace ZumaGame
{
	class Program
	{
		static void Main(string[] args)
		{
			string board = "RRYGGYYRRYYGGYRR", hand = "GGBBB";
			Console.WriteLine(FindMinStep(board, hand));
		}
		public static int FindMinStep(string board, string hand)
		{
			var balls = hand.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
			var left = -1;
			DFS(board, balls, new HashSet<char>(hand), new HashSet<string>(), ref left);
			return left == -1 ? -1 : hand.Length - left;
		}

		public static void DFS(string board, Dictionary<char, int> balls, HashSet<char> colors, HashSet<string> visited, ref int left)
		{
			if(!visited.Add(board)) return;
			board = Trim(board);
			if (board.Length == 0)
			{
				left = Math.Max(left, balls.Sum(x => x.Value));
				return;
			}
			for (int i = 0; i < board.Length; i++)
			{
				foreach (var color in colors)
				{
					if (balls[color] <= 0) continue;
					balls[color]--;
					DFS(board.Substring(0, i + 1) + color + board.Substring(i + 1), balls, colors, visited, ref left);
					balls[color]++;
				}
			}
		}

		public static string Trim(string board)
		{
			var res = "";
			int li = 0, hi = 0, count = 0;
			while (hi < board.Length && board[li] == board[hi])
			{
				while (hi < board.Length && board[li] == board[hi])
				{
					count++;
					hi++;
				}
				if (count >= 3)
					res = Trim(board.Substring(0, li) + board.Substring(hi));
				else
				{
					count = 0;
					li = hi;
					res = board;
				}
			}
			return res;
		}
	}
}
