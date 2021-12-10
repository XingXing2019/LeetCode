using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkDelayTime
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] times = new[]
			{
				new[] {4, 2, 76},
				new[] {1, 3, 79},
				new[] {3, 1, 81},
				new[] {1, 5, 61},
				new[] {1, 4, 99},
				new[] {3, 4, 68},
				new[] {3, 5, 46},
				new[] {4, 1, 6},
				new[] {5, 4, 7},
				new[] {5, 3, 44},
			};
			int N = 5, K = 3;
			Console.WriteLine(NetworkDelayTime(times, N, K));
		}
		public static int NetworkDelayTime(int[][] times, int n, int k)
		{
			var graph = new List<int[]>[n + 1];
			for (int i = 0; i < graph.Length; i++)
				graph[i] = new List<int[]>();
			foreach (var time in times)
				graph[time[0]].Add(new[] { time[1], time[2] });
			var record = new int[n + 1];
			for (int i = 0; i < record.Length; i++)
				record[i] = i == 0 || i == k ? 0 : int.MaxValue;
			var queue = new Queue<int[]>();
			queue.Enqueue(new []{k, 0});
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				foreach (var next in graph[cur[0]])
				{
					if (record[next[0]] <= next[1] + cur[1]) continue;
					queue.Enqueue(new []{next[0], next[1] + cur[1]});
					record[next[0]] = next[1] + cur[1];
				}
			}
			return record.Any(x => x == int.MaxValue) ? -1 : record.Max();
		}
	}
}
