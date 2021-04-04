using System;
using System.Collections.Generic;
using System.Linq;

namespace FindingTheUsersActiveMinutes
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
		public int[] FindingUsersActiveMinutes(int[][] logs, int k)
		{
			var dict = new Dictionary<int, HashSet<int>>();
			foreach (var log in logs)
			{
				if (!dict.ContainsKey(log[0]))
					dict[log[0]] = new HashSet<int>();
				dict[log[0]].Add(log[1]);
			}
			var count = dict.GroupBy(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Count());
			var res = new int[k];
			for (int i = 0; i < k; i++)
				res[i] = count.ContainsKey(i + 1) ? count[i + 1] : 0;
			return res;
		}
	}
}
