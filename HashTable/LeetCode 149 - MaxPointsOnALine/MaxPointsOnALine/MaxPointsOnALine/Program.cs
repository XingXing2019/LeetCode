using System;
using System.Collections.Generic;

namespace MaxPointsOnALine
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] point = new int[][]
			{
				new[] {1, 1},
				new[] {3, 2},
				new[] {5, 3},
				new[] {4, 1},
				new[] {2, 3},
				new[] {1, 4}
			};
			Console.WriteLine(MaxPoints(point));
		}
		public static int MaxPoints(int[][] points)
		{
			var record = new Dictionary<double, int>[points.Length];
			int max = 0;
			for (int i = 0; i < points.Length; i++)
			{
				record[i] = new Dictionary<double, int>();
				for (int j = 0; j < points.Length; j++)
				{
					if (i == j) continue;
					var slope = (double) (points[i][0] - points[j][0]) / (points[i][1] - points[j][1]);
					if (!record[i].ContainsKey(slope))
						record[i][slope] = 0;
					record[i][slope]++;
					max = Math.Max(max, record[i][slope]);
				}
			}
			return max + 1;
		}
	}
}
