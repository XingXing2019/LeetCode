using System;
using System.Collections.Generic;
using System.Linq;

namespace ParallelCoursesIII
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = 5;
			int[][] relations = new[]
			{
				new[] {1, 5},
				new[] {2, 5},
				new[] {3, 5},
				new[] {3, 4},
				new[] {4, 5},
			};
			int[] time = {1, 2, 3, 4, 5};
			Console.WriteLine(MinimumTime(n, relations, time));
		}

		public static int MinimumTime(int n, int[][] relations, int[] time)
		{
			var graph = new List<int>[n + 1];
			var inDegree = new int[n + 1];
			for (int i = 0; i < n + 1; i++)
				graph[i] = new List<int>();
			foreach (var relation in relations)
			{
				graph[relation[0]].Add(relation[1]);
				inDegree[relation[1]]++;
			}
			var path = new int[n + 1];
			var queue = new Queue<int>();
			for (int i = 1; i < inDegree.Length; i++)
			{
				if (inDegree[i] != 0) continue;
				queue.Enqueue(i);
				path[i] = time[i - 1];
			}
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				foreach (var next in graph[cur])
				{
					path[next] = Math.Max(path[next], path[cur] + time[next - 1]);
					if (--inDegree[next] == 0)
						queue.Enqueue(next);
				}
			}
			return path.Max();
		}

		public static int MinimumTime_DFS(int n, int[][] relations, int[] time)
		{
			var graph = new List<int>[n + 1];
			var indegree = new int[n + 1];
			var res = 0;
			for (int i = 0; i < n + 1; i++)
				graph[i] = new List<int>();
			foreach (var relation in relations)
			{
				graph[relation[0]].Add(relation[1]);
				indegree[relation[1]]++;
			}
			for (int i = 1; i < indegree.Length; i++)
			{
				if (indegree[i] == 0)
					res = Math.Max(res, DFS(i, graph, time));
			}
			return res;
		}

		public static int DFS(int cur, List<int>[] graph, int[] time)
		{
			int max = 0;
			foreach (var next in graph[cur])
				max = Math.Max(max, DFS(next, graph, time));
			return time[cur - 1] + max;
		}
	}
}
