using System;
using System.Collections.Generic;

namespace SlidingPuzzle
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] board = new[]
			{
				new[] {1, 2, 3},
				new[] {4, 0, 5},
			};
			Console.WriteLine(SlidingPuzzle(board));
		}
		public static int SlidingPuzzle(int[][] board)
		{
			int target = 123450;
			var queue = new Queue<int[]>();
			var visited = new HashSet<int>();
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					if (board[i][j] != 0) continue;
					var code = Encode(board);
					queue.Enqueue(new []{code, i, j, 0});
					visited.Add(code);
				}
			}
			int[] dir = {1, 0, -1, 0, 1};
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				if (cur[0] == target) return cur[^1];
				for (int i = 0; i < 4; i++)
				{
					int newX = cur[1] + dir[i];
					int newY = cur[2] + dir[i + 1];
					if(newX < 0 || newX >= board.Length || newY < 0 || newY >= board[0].Length)
						continue;
					board = Decode(cur[0]);
					int temp = board[newX][newY];
					board[newX][newY] = 0;
					board[cur[1]][cur[2]] = temp;
					var code = Encode(board);
					if(visited.Add(code))
						queue.Enqueue(new []{ code, newX, newY, cur[^1] + 1 });
				}
			}
			return -1;
		}

		private static int Encode(int[][] board)
		{
			int res = 0, times = 100_000;
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					res += board[i][j] * times;
					times /= 10;
				}
			}
			return res;
		}

		private static int[][] Decode(int code)
		{
			var res = new int[2][];
			int times = 100_000;
			for (int i = 0; i < res.Length; i++)
				res[i] = new int[3];
			for (int i = 0; i < res.Length; i++)
			{
				for (int j = 0; j < res[0].Length; j++)
				{
					res[i][j] = code / times;
					code %= times;
					times /= 10;
				}
			}
			return res;
		}
	}
}
