using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumJumpsToReachHome
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] forbidden = {1};
			int a = 29, b = 43, x = 30;
			Console.WriteLine(MinimumJumps(forbidden, a, b, x));
		}
		public static int MinimumJumps(int[] forbidden, int a, int b, int x)
		{
			var queue = new Queue<int[]>();
			var set = new HashSet<int>(forbidden);
			var forwardVisited = new HashSet<int>();
			var backwardVisited = new HashSet<int>();
			int maxForbidden = forbidden.Max();
			int max = Math.Max(x, maxForbidden) + b + a;
			queue.Enqueue(new []{0, 0, 1});
			while (queue.Count != 0)
			{
				var cur = queue.Dequeue();
				if (cur[0] == x) return cur[1];
				int forward = cur[0] + a, backward = cur[0] - b;
				if (!set.Contains(forward) && forward <= max && forwardVisited.Add(forward))
					queue.Enqueue(new []{forward, cur[1] + 1, 1});
				if (cur[2] != -1 && !set.Contains(backward) && backward >= 0 && backwardVisited.Add(backward))
					queue.Enqueue(new []{backward, cur[1] + 1, -1});
			}
			return -1;
		}
	}
}
