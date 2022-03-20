using System;
using System.Collections.Generic;

namespace TheTimeWhenTheNetworkBecomesIdle
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] edges = new int[][]
			{
				new int[] {5, 7},
				new int[] { 15, 18 },
				new int[] { 12, 6 },
				new int[] { 5, 1 },
				new int[] { 11, 17 },
				new int[] { 3, 9 },
				new int[] { 6, 11 },
				new int[] { 14, 7 },
				new int[] { 19, 13 },
				new int[] { 13, 3 },
				new int[] { 4, 12 },
				new int[] { 9, 15 },
				new int[] { 2, 10 },
				new int[] { 18, 4 },
				new int[] { 5, 14 },
				new int[] { 17, 5 },
				new int[] { 16, 2 },
				new int[] { 7, 1 },
				new int[] { 0, 16 },
				new int[] { 10, 19 },
				new int[] { 1, 8 },
			};
			int[] patience = { 0, 2, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1 };
			Console.WriteLine(NetworkBecomesIdle(edges, patience));
		}

		public static int NetworkBecomesIdle(int[][] edges, int[] patience)
		{
			var graph = new List<int>[patience.Length];
			for (int i = 0; i < graph.Length; i++)
				graph[i] = new List<int>();
			foreach (var edge in edges)
			{
				graph[edge[0]].Add(edge[1]);
				graph[edge[1]].Add(edge[0]);
			}
			var queue = new Queue<int>();
			queue.Enqueue(0);
			var visited = new HashSet<int> { 0 };
			int step = 0, res = 0;
			var responseTimes = new int[patience.Length];
			while (queue.Count != 0)
			{
				var count = queue.Count;
				for (int i = 0; i < count; i++)
				{
					var cur = queue.Dequeue();
					responseTimes[cur] = step * 2;
					foreach (var next in graph[cur])
					{
						if (visited.Add(next))
							queue.Enqueue(next);
					}
				}
				step++;
			}
			for (int i = 0; i < patience.Length; i++)
			{
				if (patience[i] >= responseTimes[i])
					res = Math.Max(res, responseTimes[i] + 1);
				else
				{
					var lastMsg = responseTimes[i] % patience[i] == 0 ? patience[i] : responseTimes[i] % patience[i];
					res = Math.Max(res, 2 * responseTimes[i] - lastMsg + 1);
				}
			}
			return res;
		}
	}
}
