using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DesignInMemoryFileSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			var fs = new FileSystem();
			Console.WriteLine(fs.Ls("/"));
			fs.Mkdir("/a/b/c");
			//fs.AddContentToFile("/a/b/c/d", "hello");
			Console.WriteLine(fs.Ls("/a/b"));
			//Console.WriteLine(fs.ReadContentFromFile("/a/b/c/d"));
		}
	}

	class Node
	{
		public Dictionary<string, StringBuilder> Files;
		public Dictionary<string, Node> Directories;
		public Node()
		{
			Files = new Dictionary<string, StringBuilder>();
			Directories = new Dictionary<string, Node>();
		}
	}

	public class FileSystem
	{
		private Node root;
		public FileSystem()
		{
			root = new Node();
		}

		public IList<string> Ls(string path)
		{
			var dirs = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			var point = root;
			for (int i = 0; i < dirs.Length - 1; i++)
				point = point.Directories[dirs[i]];
			if (dirs.Length != 0 && point.Files.ContainsKey(dirs[^1]))
				return new List<string> {dirs[^1]};
			if (dirs.Length != 0)
				point = point.Directories[dirs[^1]];
			var res = point.Files.Select(x => x.Key).ToList();
			res.AddRange(point.Directories.Select(x => x.Key));
			res = res.OrderBy(x => x).ToList();
			return res;
		}

		public void Mkdir(string path)
		{
			var dirs = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			var point = root;
			foreach (var dir in dirs)
			{
				if (!point.Directories.ContainsKey(dir))
					point.Directories.Add(dir, new Node());
				point = point.Directories[dir];
			}
		}

		public void AddContentToFile(string filePath, string content)
		{
			var dirs = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
			var point = root;
			for (int i = 0; i < dirs.Length - 1; i++)
				point = point.Directories[dirs[i]];
			if (!point.Files.ContainsKey(dirs[^1]))
				point.Files[dirs[^1]] = new StringBuilder();
			point.Files[dirs[^1]].Append(content);
		}

		public string ReadContentFromFile(string filePath)
		{
			var dirs = filePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
			var point = root;
			for (int i = 0; i < dirs.Length - 1; i++)
				point = point.Directories[dirs[i]];
			return point.Files[dirs[^1]].ToString();
		}
	}
}
