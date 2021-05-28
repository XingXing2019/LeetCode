using System;
using System.Collections.Generic;
using System.Linq;

namespace AnalyzeUserWebsiteVisitPattern
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] username = { "h", "eiy", "cq", "h", "cq", "txldsscx", "cq", "txldsscx", "h", "cq", "cq" };
			int[] timestamp = { 527896567, 334462937, 517687281, 134127993, 859112386, 159548699, 51100299, 444082139, 926837079, 317455832, 411747930 };
			string[] website = { "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "hibympufi", "yljmntrclw", "hibympufi", "yljmntrclw" };
			Console.WriteLine(MostVisitedPattern(username, timestamp, website));
		}

		class User
		{
			public string Name { get; set; }
			public int Time { get; set; }
			public string Website { get; set; }
			public User(string name, int time, string website)
			{
				Name = name;
				Time = time;
				Website = website;
			}
		}
		public static IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
		{
			var users = new List<User>();
			for (int i = 0; i < username.Length; i++)
				users.Add(new User(username[i], timestamp[i], website[i]));
			var dict = users.GroupBy(x => x.Name).ToDictionary(x => x.Key, x => x.OrderBy(y => y.Time).Select(y => y.Website).ToList());
			var freq = new Dictionary<string, int>();
			foreach (var item in dict)
			{
				if (item.Value.Count < 3) continue;
				var webs = item.Value;
				var sequences = GetSequences(webs);
				foreach (var sequence in sequences)
				{
					if (!freq.ContainsKey(sequence))
						freq[sequence] = 0;
					freq[sequence]++;
				}
			}
			return freq.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => x.Key).First().Split(":");
		}

		public static HashSet<string> GetSequences(List<string> webs)
		{
			var res = new HashSet<string>();
			for (int i = 0; i < webs.Count; i++)
			{
				for (int j = i + 1; j < webs.Count; j++)
				{
					for (int k = j + 1; k < webs.Count; k++)
					{
						res.Add($"{webs[i]}:{webs[j]}:{webs[k]}");
					}
				}
			}
			return res;
		}
	}
}
