using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumPathQualityOfAGraph
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] values = {0, 32, 10, 43};
			int[][] edges = new[]
			{
				new[] {0, 1, 10},
				new[] {1, 2, 15},
				new[] {0, 3, 10},
			};
			int maxTime = 49;
			Console.WriteLine(MaximalPathQuality(values, edges, maxTime));
		}

		class Node
		{
			public int node;
			public int time;
			public HashSet<int> path;

			public Node(int node, int time, HashSet<int> path)
			{
				this.node = node;
				this.time = time;
				this.path = path;
			}
		}

		public static int MaximalPathQuality(int[] values, int[][] edges, int maxTime)
		{
			var graph = new List<int[]>[values.Length];
			for (int i = 0; i < graph.Length; i++)
				graph[i] = new List<int[]>();
			foreach (var edge in edges)
			{
				graph[edge[0]].Add(new []{ edge[1] , edge[2]});
				graph[edge[1]].Add(new []{ edge[0] , edge[2]});
			}
			var queue = new Queue<Node>();
			queue.Enqueue(new Node(0, 0, new HashSet<int>{0}));
			int res = 0;
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				if (cur.node == 0)
					res = Math.Max(res, cur.path.Sum(x => values[x]));
				foreach (var next in graph[cur.node])
				{
					if (cur.time + next[1] > maxTime) continue;
					var path = new HashSet<int>(cur.path);
					path.Add(next[0]);
					queue.Enqueue(new Node(next[0], cur.time + next[1], path));
				}
			}
			return res;
		}
	}
}
