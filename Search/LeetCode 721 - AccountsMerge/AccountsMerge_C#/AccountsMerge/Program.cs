using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountsMerge
{
	class Program
	{
		static void Main(string[] args)
		{
			var accounts = new List<IList<string>>
			{
				new List<string> {"David","David0@m.co","David1@m.co"},
				new List<string> {"David","David3@m.co","David4@m.co"},
				new List<string> {"David","David4@m.co","David5@m.co"},
				new List<string> {"David","David2@m.co","David3@m.co"},
				new List<string> {"David","David1@m.co","David2@m.co"},
			};
			Console.WriteLine(AccountsMerge(accounts));
		}
		public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
		{
			var graph = new Dictionary<string, List<string>>();
			var dict = new Dictionary<string, string>();
			var res = new List<IList<string>>();
			foreach (var account in accounts)
			{
				for (int i = 1; i < account.Count; i++)
				{
					dict[account[i]] = account[0];
					if (!graph.ContainsKey(account[i]))
						graph[account[i]] = new List<string>();
					graph[account[i]].AddRange(account);
					graph[account[i]].Remove(account[0]);
				}
			}
			var visited = new HashSet<string>();
			foreach (var email in graph)
			{
				if (visited.Contains(email.Key)) continue;
				var emails = new HashSet<string>();
				var queue = new Queue<string>();
				queue.Enqueue(email.Key);
				emails.Add(email.Key);
				visited.Add(email.Key);
				while (queue.Count != 0)
				{
					var cur = queue.Dequeue();
					foreach (var next in graph[cur])
					{
						if (emails.Add(next) && visited.Add(next))
							queue.Enqueue(next);
					}
				}
				var temp = new List<string>{dict[email.Key]};
				temp.AddRange(emails);
				temp.Sort(1, temp.Count - 1, StringComparer.Ordinal);
				res.Add(temp);
			}
			return res;
		}
    }
}
