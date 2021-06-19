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

		public int[] FindPeakGrid_BinarySearch(int[][] mat)
		{
			int li = 0, hi = mat.Length - 1;
			while (li <= hi)
			{
				int mid = li + (hi - li) / 2;
				int index = 0;
				for (int i = 0; i < mat[0].Length; i++)
				{
					if (mat[mid][i] > mat[mid][index])
						index = i;
				}
				int up = mid == 0 ? -1 : mat[mid - 1][index];
				int down = mid == mat.Length - 1 ? -1 : mat[mid + 1][index];
				if (mat[mid][index] > up && mat[mid][index] > down) return new[] {mid, index};
				if (mat[mid][index] < up) hi = mid - 1;
				else li = mid + 1;
			}
			return null;
		}
	}
}
