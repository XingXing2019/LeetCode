using System;
using System.Collections.Generic;

namespace BusRoutes
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] routes = new[]
			{
				new[] {1, 2, 7},
				new[] {3, 6, 7},
			};
			int source = 1, target = 6;
			Console.WriteLine(NumBusesToDestination(routes, source, target));
		}
		public static int NumBusesToDestination(int[][] routes, int source, int target)
		{
			if (source == target) return 0;
			var stops = new HashSet<int>[routes.Length];
			var buses = new Dictionary<int, List<int>>();
			for (int i = 0; i < routes.Length; i++)
			{
				stops[i] = new HashSet<int>(routes[i]);
				foreach (var stop in routes[i])
				{
					if (!buses.ContainsKey(stop))
						buses[stop] = new List<int>();
					buses[stop].Add(i);
				}
			}
			var queue = new Queue<int[]>();
			var takenBuses = new HashSet<int>();
			foreach (var bus in buses[source])
			{
				queue.Enqueue(new []{bus, 1});
				takenBuses.Add(bus);
			}
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				if (stops[cur[0]].Contains(target))
					return cur[1];
				foreach (var stop in routes[cur[0]])
				{
					foreach (var bus in buses[stop])
					{
						if(takenBuses.Add(bus))
							queue.Enqueue(new []{bus, cur[1] + 1});
					}
				}
			}
			return -1;
		}
	}
}
