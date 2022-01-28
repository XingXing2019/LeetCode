using System;
using System.Collections.Generic;
using System.Linq;

namespace TheNumberOfWeakCharactersInTheGame
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] properties = new int[][]
			{
				new int[] {7, 9},
				new int[] {10, 7},
				new int[] {6, 9},
				new int[] {10 ,4},
				new int[] {7, 5},
				new int[] {7, 10},
			};
			Console.WriteLine(NumberOfWeakCharacters(properties));
		}

		public static int NumberOfWeakCharacters(int[][] properties)
		{
			var dict = properties.GroupBy(x => x[0]).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Select(y => y[1]).ToArray());
			var groups = new List<int[]>();
			foreach (var item in dict)
				groups.Add(new[] { item.Key, item.Value.Max() });
			int max = groups[^1][1];
			for (int i = groups.Count - 1; i >= 0; i--)
			{
				int temp = groups[i][1];
				groups[i][1] = max;
				max = Math.Max(max, temp);
			}
			var res = 0;
			for (int i = 0; i < groups.Count - 1; i++)
			{
				var characters = dict[groups[i][0]];
				var rightMax = groups[i][1];
				res += characters.Count(x => x < rightMax);
			}
			return res;
		}
	}
}
