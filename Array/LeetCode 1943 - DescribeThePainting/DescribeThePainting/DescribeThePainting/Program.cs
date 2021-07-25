using System;
using System.Collections.Generic;
using System.Linq;

namespace DescribeThePainting
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] segments = new[]
			{
				new[] {4, 16, 12},
				new[] {18, 19, 13},
				new[] {13, 16, 6},
			};
			Console.WriteLine(SplitPainting(segments));
		}
		public static IList<IList<long>> SplitPainting(int[][] segments)
		{
			var dict = new Dictionary<int, long>();
			foreach (var segment in segments)
			{
				if (!dict.ContainsKey(segment[0]))
					dict[segment[0]] = 0;
				dict[segment[0]] += segment[2];
				if (!dict.ContainsKey(segment[1]))
					dict[segment[1]] = 0;
				dict[segment[1]] -= segment[2];
			}
			dict = dict.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
			var res = new List<IList<long>>();
			long sum = 0, start = -1;
			var first = true;
			foreach (var record in dict)
			{
				if (!first && sum != 0) 
					res.Add(new List<long> { start, record.Key, sum });
				start = record.Key;
				sum += record.Value;
				first = false;
			}
			return res;
		}
	}
}
