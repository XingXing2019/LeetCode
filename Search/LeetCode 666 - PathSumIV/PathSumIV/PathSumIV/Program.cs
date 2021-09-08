using System;

namespace PathSumIV
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { 113, 229, 330, 466 };
			Console.WriteLine(PathSum(nums));
		}
		
		public static int PathSum(int[] nums)
		{
			var matrix = new int[5][];
			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new int[16];
				Array.Fill(matrix[i], -1);
			}
			foreach (var num in nums)
				matrix[num / 100 - 1][num % 100 / 10 - 1] = num % 100 % 10;
			int res = 0;
			DFS(matrix, 0, 0, 0, ref res);
			return res;
		}

		public static void DFS(int[][] matrix, int depth, int pos, int sum, ref int res)
		{
			if (depth >= matrix.Length || matrix[depth][pos] == -1)
				return;
			if (matrix[depth + 1][pos * 2] == -1 && matrix[depth + 1][pos * 2 + 1] == -1) 
				res += sum + matrix[depth][pos];
			DFS(matrix, depth + 1, pos * 2, sum + matrix[depth][pos], ref res);
			DFS(matrix, depth + 1, pos * 2 + 1, sum + matrix[depth][pos], ref res);
		}
	}
}
