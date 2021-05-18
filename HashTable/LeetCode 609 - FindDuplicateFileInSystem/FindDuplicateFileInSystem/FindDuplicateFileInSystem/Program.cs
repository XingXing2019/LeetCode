using System;
using System.Collections.Generic;

namespace FindDuplicateFileInSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}

		public IList<IList<string>> FindDuplicate(string[] paths)
		{
			var res = new List<IList<string>>();
			var dict = new Dictionary<string, List<string>>();
			foreach (var path in paths)
				GetContent(path, dict);
			foreach (var item in dict)
			{
				if (item.Value.Count == 1) continue;
				res.Add(item.Value);
			}
			return res;
		}

		public void GetContent(string path, Dictionary<string, List<string>> dict)
		{
			var parts = path.Split(" ");
			if (parts.Length < 2) return;
			for (int i = 1; i < parts.Length; i++)
			{
				var file = parts[i];
				var left = file.IndexOf('(');
				var content = file.Substring(left);
				var dir = file.Substring(0, left);
				if (!dict.ContainsKey(content))
					dict[content] = new List<string>();
				dict[content].Add($"{parts[0]}/{dir}");
			}
		}
	}
}
