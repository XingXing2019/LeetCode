using System;

namespace SpiralMatrixIII
{
	class Program
	{
		static void Main(string[] args)
		{
			int rows = 2, cols = 2, rstart = 0, cStart = 0;
			Console.WriteLine(SpiralMatrixIII(rows, cols, rstart, cStart));
		}

		public static int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
		{
			var res = new int[rows * cols][];
			res[0] = new[] {rStart, cStart};
			int x = rStart, y = cStart;
			int step = 1, index = 1, point = 0;
			int[] dx = {0, 1, 0, -1};
			int[] dy = {1, 0, -1, 0};
			while (index < rows * cols)
			{
				for (int i = 0; i < 2; i++)
				{
					for (int j = 0; j < step; j++)
					{
						int newX = x + dx[point % 4];
						int newY = y + dy[point % 4];
						if (newX >= 0 && newX < rows && newY >= 0 && newY < cols)
							res[index++] = new[] {newX, newY};
						x = newX;
						y = newY;
					}
					point++;
				}
				step++;
			}
			return res;
		}
	}
}
