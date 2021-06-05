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
			dict = new Dictionary<string, int> {{"", -1}};
		}

		public bool CreatePath(string path, int value)
		{
			int index = path.LastIndexOf('/');
			if (dict.ContainsKey(path) || !dict.ContainsKey(path.Substring(0, index))) 
				return false;
			dict[path] = value;
			return true;
		}

		public int Get(string path)
		{
			return dict.ContainsKey(path) ? dict[path] : -1;
		}
	}
}
