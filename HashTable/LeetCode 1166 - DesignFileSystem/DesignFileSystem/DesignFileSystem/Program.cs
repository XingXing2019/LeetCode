using System;
using System.Collections.Generic;

namespace DesignFileSystem
{
	class Program
	{
		static void Main(string[] args)
		{
			var fileSystem = new FileSystem();
			Console.WriteLine(fileSystem.CreatePath("/a", 1));
			Console.WriteLine(fileSystem.Get("/a"));
		}
	}
	public class FileSystem
	{
		private Dictionary<string, int> dict;
		public FileSystem()
		{
			dict = new Dictionary<string, int>();
		}

		public bool CreatePath(string path, int value)
		{
			if (dict.ContainsKey(path)) return false;
			var parts = path.Split("/", StringSplitOptions.RemoveEmptyEntries);
			var dir = "";
			for (int i = 0; i < parts.Length - 1; i++)
			{
				dir += $"/{parts[i]}";
				if (!dict.ContainsKey(dir))
					return false;
			}
			dict[path] = value;
			return true;
		}

		public int Get(string path)
		{
			return dict.ContainsKey(path) ? dict[path] : -1;
		}
	}
}
