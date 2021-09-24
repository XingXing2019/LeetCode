using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageHeightOfBuildingsInEachSegment
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] buildings = new int[2][]
			{
				new[] {1, 5, 2},
				new[] {3, 10, 4}
			};
			Console.WriteLine(AverageHeightOfBuildings(buildings));
		}
		public static int[][] AverageHeightOfBuildings(int[][] buildings)
		{
			var dict = new Dictionary<int, int[]>();
			foreach (var building in buildings)
			{
				if (!dict.ContainsKey(building[0]))
					dict[building[0]] = new int[2];
				if (!dict.ContainsKey(building[1]))
					dict[building[1]] = new int[2];
				dict[building[0]][0] += building[2];
				dict[building[0]][1]++;
				dict[building[1]][0] -= building[2];
				dict[building[1]][1]--;
			}
			dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
			int start = 0, height = 0, count = 0;
			var isFirst = true;
			var res = new List<int[]>();
			foreach (var item in dict)
			{
				if (isFirst)
					isFirst = false;
				else if (count != 0)
				{
					if (res.Count == 0 || res[^1][2] != height / count || start > res[^1][1])
						res.Add(new[] { start, item.Key, height / count });
					else
						res[^1][1] = item.Key;
				}
				start = item.Key;
				height += item.Value[0];
				count += item.Value[1];
			}
			return res.ToArray();
		}
	}
}
