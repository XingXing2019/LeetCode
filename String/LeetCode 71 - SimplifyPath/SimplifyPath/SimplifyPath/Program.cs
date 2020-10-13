using System;
using System.Collections.Generic;
using System.Text;

namespace SimplifyPath
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "/home//foo/";
            Console.WriteLine(SimplifyPath(path));
        }
        static string SimplifyPath(string path)
        {
            var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var record = new List<string>();
            foreach (var part in parts)
            {
                if (part == ".") continue;
                if (part != "..")
                    record.Add(part);
                else if (record.Count != 0)
                    record.RemoveAt(record.Count - 1);
            }
            return $"/{string.Join('/', record)}";
        }
    }
}
