using System;

namespace FindAPeakElementII
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int[] FindPeakGrid(int[][] mat)
		{
			for (int i = 0; i < mat.Length; i++)
			{
				for (int j = 0; j < mat[0].Length; j++)
				{
					int count = 0;
					if (i == 0 || mat[i - 1][j] < mat[i][j])
						count++;
					if (j == 0 || mat[i][j - 1] < mat[i][j])
						count++;
					if (i == mat.Length - 1 || mat[i + 1][j] < mat[i][j])
						count++;
					if (j == mat[0].Length - 1 || mat[i][j + 1] < mat[i][j])
						count++;
					if (count == 4)
						return new[] {i, j};
				}
			}
			return null;
		}
	}
}
