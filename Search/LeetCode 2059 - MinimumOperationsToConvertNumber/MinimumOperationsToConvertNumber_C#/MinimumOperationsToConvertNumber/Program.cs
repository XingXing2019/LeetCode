using System;
using System.Collections.Generic;

namespace MinimumOperationsToConvertNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int MinimumOperations(int[] nums, int start, int goal)
		{
			var queue = new Queue<int>();
			queue.Enqueue(start);
			var visited = new HashSet<int>();
			var res = 0;
			while (queue.Count != 0)
			{
				var count = queue.Count;
				for (int i = 0; i < count; i++)
				{
					var cur = queue.Dequeue();
					if (cur == goal) return res;
					if (cur < 0 || cur > 1000 || !visited.Add(cur)) continue;
					foreach (var num in nums)
					{
						queue.Enqueue(cur + num);
						queue.Enqueue(cur - num);
						queue.Enqueue(cur ^ num);
					}
				}
				res++;
			}
			return -1;
		}
	}
}
