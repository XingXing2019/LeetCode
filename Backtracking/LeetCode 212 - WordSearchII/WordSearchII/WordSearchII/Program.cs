using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSearchII
{
	class Program
	{
		static void Main(string[] args)
		{
			char[][] board = new char[][]
			{
				new char[] {'o', 'a', 'a', 'n'},
				new char[] {'e', 't', 'a', 'e'},
				new char[] {'i', 'h', 'k', 'r'},
				new char[] {'i', 'f', 'l', 'v'},
			};
			string[] words = {"oath", "pea", "eat", "rain"};
			Console.WriteLine(FindWords(board, words));
		}

		public static IList<string> FindWords(char[][] board, string[] words)
		{
			var set = new HashSet<string>(words);
			var len = words.Max(x => x.Length);
			var res = new HashSet<string>();
			for (int x = 0; x < board.Length; x++)
			{
				for (int y = 0; y < board[0].Length; y++)
				{
					var visited = new bool[board.Length][];
					for (int i = 0; i < visited.Length; i++)
						visited[i] = new bool[board[0].Length];
					DFS(board, x, y, len, visited, "", set, res);
				}
			}
			return res.ToList();
		}

		public static void DFS(char[][] board, int x, int y, int len, bool[][] visited, string word, HashSet<string> words, HashSet<string> res)
		{
			if(x < 0 || x >= board.Length || y < 0 || y >= board[0].Length || visited[x][y] || word.Length + 1 > len)
				return;
			word += board[x][y];
			if(words.Contains(word))
				res.Add(word);
			visited[x][y] = true;
			DFS(board, x + 1, y, len, visited, word, words, res);
			DFS(board, x - 1, y, len, visited, word, words, res);
			DFS(board, x, y + 1, len, visited, word, words, res);
			DFS(board, x, y - 1, len, visited, word, words, res);
			visited[x][y] = false;
		}
	}
}
