using System;
using System.Collections.Generic;

namespace MinimizeTheDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinimizeTheDifference(int[][] mat, int target)
		{
			int res = int.MaxValue;
			var visited = new HashSet<int>[mat.Length];
			for (int i = 0; i < visited.Length; i++)
				visited[i] = new HashSet<int>();
			DFS(mat, 0, target, 0, visited, ref res);
			return res;
		}

		public void DFS(int[][] mat, int row, int target, int sum, HashSet<int>[] visited, ref int res)
		{
			if (row == mat.Length)
			{
				res = Math.Min(res, Math.Abs(sum - target));
				return;
			}
			if (!visited[row].Add(sum) || sum - target > res)
				return;
			foreach (var num in mat[row])
			{
				DFS(mat, row + 1, target, sum + num, visited, ref res);
			}
		}
	}
}
