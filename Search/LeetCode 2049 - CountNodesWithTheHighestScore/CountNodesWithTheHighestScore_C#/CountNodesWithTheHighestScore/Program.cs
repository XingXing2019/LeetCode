using System;
using System.Collections.Generic;

namespace CountNodesWithTheHighestScore
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] parents = { -1, 2, 0, 2, 0 };
			Console.WriteLine(CountHighestScoreNodes(parents));
		}

		public static int CountHighestScoreNodes(int[] parents)
		{
			long max = 0;
			var graph = new List<int>[parents.Length];
			for (int i = 0; i < graph.Length; i++)
				graph[i] = new List<int>();
			for (int i = 1; i < parents.Length; i++)
				graph[parents[i]].Add(i);
			Dictionary<long, int> dict = new Dictionary<long, int>(), record = new Dictionary<long, int>();
			DFS(graph, 0, dict);
			for (int i = 0; i < parents.Length; i++)
			{
				long score = Math.Max(1, dict[0] - dict[i]);
				foreach (var child in graph[i])
					score *= dict[child];
				max = Math.Max(max, score);
				if (!record.ContainsKey(score))
					record[score] = 0;
				record[score]++;
			}
			return record[max];
		}

		public static int DFS(List<int>[] graph, int cur, Dictionary<long, int> dict)
		{
			int res = 1;
			foreach (var next in graph[cur])
				res += DFS(graph, next, dict);
			dict[cur] = res;
			return res;
		}
	}
}
