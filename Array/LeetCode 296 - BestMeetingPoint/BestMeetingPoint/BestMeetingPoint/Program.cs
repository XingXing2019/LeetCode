using System;
using System.Collections.Generic;
using System.Linq;

namespace BestMeetingPoint
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] grid = { new[] { 1 }, new[] { 1 } };
			Console.WriteLine(MinTotalDistance(grid));
		}
		public static int MinTotalDistance(int[][] grid)
		{
			var coordinateX = new List<int>();
			var coordinateY = new List<int>();
			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					if (grid[x][y] == 1)
					{
						coordinateX.Add(x);
						coordinateY.Add(y);
					}
				}
			}
			int minX = coordinateX.Min(), maxX = coordinateX.Max();
			int minY = coordinateY.Min(), maxY = coordinateY.Max();
			int res = int.MaxValue;
			for (int i = 0; i < 2; i++)
			{
				int sumY = coordinateY.Sum(c => Math.Abs(c - (minY + maxY) / 2 - i));
				for (int x = minX; x <= maxX; x++)
					res = Math.Min(res, sumY + coordinateX.Sum(c => Math.Abs(c - x)));
			}
			for (int i = 0; i < 2; i++)
			{
				int sumX = coordinateX.Sum(c => Math.Abs(c - (minX + maxX) / 2 - i));
				for (int y = minY; y <= maxY; y++)
					res = Math.Min(res, sumX + coordinateY.Sum(c => Math.Abs(c - y)));
			}
			return res;
		}

		public static int MinTotalDistance_Sort(int[][] grid)
		{
			var coordinateX = new List<int>();
			var coordinateY = new List<int>();
			for (int x = 0; x < grid.Length; x++)
			{
				for (int y = 0; y < grid[0].Length; y++)
				{
					if (grid[x][y] == 1)
					{
						coordinateX.Add(x);
						coordinateY.Add(y);
					}
				}
			}
			coordinateX.Sort();
			coordinateY.Sort();
			int res = int.MaxValue;
			int midX = coordinateX[coordinateX.Count / 2], midY = coordinateY[coordinateY.Count / 2];
			int sumY = coordinateY.Sum(c => Math.Abs(c - midY));
			foreach (var x in coordinateX)
				res = Math.Min(res, sumY + coordinateX.Sum(c => Math.Abs(c - x)));
			int sumX = coordinateX.Sum(c => Math.Abs(c - midX));
			foreach (var y in coordinateY)
				res = Math.Min(res, sumX + coordinateY.Sum(c => Math.Abs(c - y)));
			return res;
		}
	}
}
