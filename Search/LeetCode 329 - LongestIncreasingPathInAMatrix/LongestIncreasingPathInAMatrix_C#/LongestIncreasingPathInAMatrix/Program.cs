using System;

namespace LongestIncreasingPathInAMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] matirx =
			{
				new[] {9, 9, 4},
				new[] {6, 6, 8},
				new[] {2, 1, 1}
			};
			Console.WriteLine(LongestIncreasingPath(matirx));
		}
		public static int LongestIncreasingPath(int[][] matrix)
		{
			var path = new int[matrix.Length][];
			var visited = new bool[matrix.Length][];
			int res = 0;
			for (int i = 0; i < path.Length; i++)
			{
				path[i] = new int[matrix[0].Length];
				Array.Fill(path[i], 1);
				visited[i] = new bool[matrix[0].Length];
			}
			int[] dir = {0, 1, 0, -1, 0};
			for (int x = 0; x < matrix.Length; x++)
			{
				for (int y = 0; y < matrix[0].Length; y++)
				{
					DFS(matrix, path, visited, dir, x, y, long.MaxValue);
					res = Math.Max(res, path[x][y]);
				}
			}
			return res;
		}

		public static int DFS(int[][] matrix, int[][] path, bool[][] visited, int[] dir, int x, int y, long num)
		{
			if (x < 0 || x >= matrix.Length || y < 0 || y >= matrix[0].Length || matrix[x][y] >= num)
				return 0;
			if (visited[x][y])
				return path[x][y];
			visited[x][y] = true;
			int temp = 0;
			for (int i = 0; i < 4; i++)
			{
				int newX = x + dir[i];
				int newY = y + dir[i + 1];
				temp = Math.Max(temp, DFS(matrix, path, visited, dir, newX, newY, matrix[x][y]));
			}
			path[x][y] += temp;
			return path[x][y];
		}
	}
}
