using System;
using System.Collections.Generic;
using System.Linq;

namespace DetectSquares
{
	class Program
	{
		static void Main(string[] args)
		{
			var ds = new DetectSquares();
			ds.Add(new[] { 5, 10 });
			ds.Add(new[] { 10, 5 });
			ds.Add(new[] { 10, 10 });
			ds.Add(new[] { 3, 0 });
			ds.Add(new[] { 8, 0 });
			ds.Add(new[] { 8, 5 });
			ds.Add(new[] { 9, 0 });
			ds.Add(new[] { 9, 8 });
			ds.Add(new[] { 1, 8 });
			ds.Add(new[] { 0, 0 });
			ds.Add(new[] { 8, 0 });
			ds.Add(new[] { 8, 8 });
			Console.WriteLine(ds.Count(new[] { 0, 8 }));
		}
	}

	public class DetectSquares
	{
		private Dictionary<int, List<int[]>> xDict;
		private Dictionary<int, List<int[]>> yDict;
		public DetectSquares()
		{
			xDict = new Dictionary<int, List<int[]>>();
			yDict = new Dictionary<int, List<int[]>>();
		}

		public void Add(int[] point)
		{
			int x = point[0], y = point[1];
			if (!xDict.ContainsKey(x))
				xDict[x] = new List<int[]>();
			xDict[x].Add(point);
			if (!yDict.ContainsKey(y))
				yDict[y] = new List<int[]>();
			yDict[y].Add(point);
		}

		public int Count(int[] point)
		{
			int res = 0;
			if (!yDict.ContainsKey(point[1])) return 0;
			var sameRow = yDict[point[1]];
			foreach (var p in sameRow)
			{
				int len = Math.Abs(p[0] - point[0]);
				if (len == 0) continue;
				var cols = new List<int> { p[1] + len, p[1] - len };
				foreach (var col in cols)
				{
					if (!yDict.ContainsKey(col)) continue;
					res += yDict[col].Count(x => x[0] == p[0]) * yDict[col].Count(x => x[0] == point[0]);
				}
			}
			return res;
		}
	}
}
