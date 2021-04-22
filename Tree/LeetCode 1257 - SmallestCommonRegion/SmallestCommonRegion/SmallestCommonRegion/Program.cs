using System;
using System.Collections.Generic;

namespace SmallestCommonRegion
{
	class Program
	{
		static void Main(string[] args)
		{
			var regions = new List<IList<string>>
			{
				new List<string> {"Earth", "North America", "South America"},
				new List<string> {"North America", "United States", "Canada"},
				new List<string> {"United States", "New York", "Boston"},
				new List<string> {"Canada", "Ontario", "Quebec"},
				new List<string> {"South America", "Brazil"},
			};
			string region1 = "Quebec", region2 = "Brazil";
			Console.WriteLine(FindSmallestRegion(regions, region1, region2));
		}
		public static string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
		{
			var dict = new Dictionary<string, string>();
			foreach (var region in regions)
			{
				if(region.Count < 2) continue;
				for (int i = 1; i < region.Count; i++)
					dict[region[i]] = region[0];
			}
			Queue<string> queue1 = new Queue<string>(), queue2 = new Queue<string>();
			while (dict.ContainsKey(region1))
			{
				queue1.Enqueue(region1);
				region1 = dict[region1];
			}
			queue1.Enqueue(region1);
			while (dict.ContainsKey(region2))
			{
				queue2.Enqueue(region2);
				region2 = dict[region2];
			}
			queue2.Enqueue(region2);
			while (queue1.Count > queue2.Count)
				queue1.Dequeue();
			while (queue2.Count > queue1.Count)
				queue2.Dequeue();
			while (queue1.Peek() != queue2.Peek())
			{
				queue1.Dequeue();
				queue2.Dequeue();
			}
			return queue1.Peek();
		}
	}
}
