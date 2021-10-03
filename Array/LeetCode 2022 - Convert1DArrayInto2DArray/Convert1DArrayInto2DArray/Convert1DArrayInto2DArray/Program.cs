using System;

namespace Convert1DArrayInto2DArray
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public int[][] Construct2DArray(int[] original, int m, int n)
		{
			if (original.Length != m * n)
				return new int[0][];
			var res = new int[m][];
			int index = 0;
			for (int i = 0; i < m; i++)
			{
				res[i] = new int[n];
				for (int j = 0; j < n; j++)
					res[i][j] = original[index++];
			}
			return res;
		}
	}
}
