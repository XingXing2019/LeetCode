using System;
using System.Collections.Generic;

namespace CyclicallyRotatingAGrid
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = new int[][]
			{
				new []{1, 2, 3, 4},
				new []{5, 6, 7, 8},
				new []{9, 10, 11, 12},
				new []{13, 14, 15, 16},
			};
			int k = 2;
			RotateGrid(grid, k);
		}
		public static int[][] RotateGrid(int[][] grid, int k)
		{
			int x = 0, y = 0, h = grid.Length, w = grid[0].Length;
			int up = 0, down = h - 1, left = 0, right = w - 1;
			for (int i = 0; i < Math.Min(grid.Length, grid[0].Length) / 2; i++)
			{
				Rotate(grid, x, y, w, h, k, up, down, left, right);
				x++;
				y++;
				w -= 2;
				h -= 2;
				up++;
				down--;
				left++;
				right--;
			}
			return grid;
		}

		private static void Rotate(int[][] grid, int x, int y, int w, int h, int k, int up, int down, int left, int right)
		{
			int total = w * 2 + (h - 2) * 2, index = 0;
			k = total - k % total;
			var record = new int[total];
			int[] dx = { 0, 1, 0, -1 };
			int[] dy = { 1, 0, -1, 0 };
			for (int i = 0; i < record.Length; i++)
			{
				record[i] = grid[x][y];
				var next = GetNext(x, y, up, down, left, right, dx, dy, ref index);
				x = next[0];
				y = next[1];
			}
			index = 0;
			for (int i = 0; i < k; i++)
			{
				var next = GetNext(x, y, up, down, left, right, dx, dy, ref index);
				x = next[0];
				y = next[1];
			}
			for (int i = 0; i < record.Length; i++)
			{
				grid[x][y] = record[i];
				var next = GetNext(x, y, up, down, left, right, dx, dy, ref index);
				x = next[0];
				y = next[1];
			}
		}

		private static int[] GetNext(int x, int y, int up, int down, int left, int right, int[] dx, int[] dy, ref int index)
		{
			int newX = x + dx[index % 4];
			int newY = y + dy[index % 4];
			if (newX < up || newX > down || newY < left || newY > right)
			{
				index++;
				newX = x + dx[index % 4];
				newY = y + dy[index % 4];
			}
			return new[] { newX, newY };
		}
	}
}
