using System;
using System.Collections.Generic;

namespace FindIfPathExistsInGraph
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public bool ValidPath(int n, int[][] edges, int start, int end)
		{
			var graph = new List<int>[n];
			for (int i = 0; i < n; i++)
				graph[i] = new List<int>();
			foreach (var edge in edges)
			{
				graph[edge[0]].Add(edge[1]);
				graph[edge[1]].Add(edge[0]);
			}
			var queue = new Queue<int>();
			var visited = new HashSet<int> {start};
			queue.Enqueue(start);
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				if (cur == end) return true;
				foreach (var next in graph[cur])
				{
					if(visited.Add(next))
						queue.Enqueue(next);
				}
			}
			return false;
		}
	}
}
