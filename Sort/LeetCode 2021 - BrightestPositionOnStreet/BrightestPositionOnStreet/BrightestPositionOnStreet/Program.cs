using System;
using System.Collections.Generic;
using System.Linq;

namespace BrightestPositionOnStreet
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int BrightestPosition(int[][] lights)
		{
			var dict = new Dictionary<int, int>();
			int res = 0, light = 0, brightest = 0;
			foreach (var lamp in lights)
			{
				if (!dict.ContainsKey(lamp[0] - lamp[1]))
					dict[lamp[0] - lamp[1]] = 0;
				dict[lamp[0] - lamp[1]]++;
				if (!dict.ContainsKey(lamp[0] + lamp[1] + 1))
					dict[lamp[0] + lamp[1] + 1] = 0;
				dict[lamp[0] + lamp[1] + 1]--;
			}
			dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
			foreach (var item in dict)
			{
				light += item.Value;
				if (light > brightest)
				{
					brightest = light;
					res = item.Key;
				}
			}
			return res;
		}
	}
}
