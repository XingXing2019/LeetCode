using System;

namespace DetermineWhetherMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool FindRotation(int[][] mat, int[][] target)
		{
			for (int i = 0; i < 4; i++)
			{
				if (Check(mat, target))
					return true;
				RotateClockwise(mat);
			}
			for (int i = 0; i < 4; i++)
			{
				if (Check(mat, target))
					return true;
				RotateAntiClockwise(mat);
			}
			return false;
		}

		private void RotateClockwise(int[][] mat)
		{
			for (int i = 0; i < mat.Length; i++)
			{
				for (int j = i; j < mat[0].Length; j++)
				{
					int temp = mat[i][j];
					mat[i][j] = mat[j][i];
					mat[j][i] = temp;
				}
			}
			for (int i = 0; i < mat.Length; i++)
			{
				for (int j = 0; j < mat[0].Length / 2; j++)
				{
					int temp = mat[i][j];
					mat[i][j] = mat[i][^(j + 1)];
					mat[i][^(j + 1)] = temp;
				}
			}
		}

		private void RotateAntiClockwise(int[][] mat)
		{
			for (int i = 0; i < mat.Length; i++)
			{
				for (int j = i; j < mat[0].Length; j++)
				{
					int temp = mat[i][j];
					mat[i][j] = mat[j][i];
					mat[j][i] = temp;
				}
			}
			for (int i = 0; i < mat.Length / 2; i++)
			{
				for (int j = 0; j < mat[0].Length; j++)
				{
					int temp = mat[i][j];
					mat[i][j] = mat[^(i + 1)][j];
					mat[^(i + 1)][j] = temp;
				}	
			}
		}

		private bool Check(int[][] mat, int[][] target)
		{
			for (int i = 0; i < mat.Length; i++)
			{
				for (int j = 0; j < mat[0].Length; j++)
				{
					if (mat[i][j] != target[i][j])
						return false;
				}
			}
			return true;
		}
	}
}
