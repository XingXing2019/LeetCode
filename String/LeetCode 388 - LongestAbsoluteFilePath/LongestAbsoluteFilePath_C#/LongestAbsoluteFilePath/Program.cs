using System;
using System.Collections.Generic;

namespace LongestAbsoluteFilePath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext";
            Console.WriteLine(LengthLongestPath(input));
        }

        public class Node
        {
            public int Level;
            public string Value;
            public bool IsFile;
            public List<Node> children;
            public Node(int level, string value, bool isFile)
            {
                Level = level;
                Value = value;
                IsFile = isFile;
                children = new List<Node>();
            }
        }
        public static int LengthLongestPath(string input)
        {
            var dirs = input.Split("\n");
            var dict = new Dictionary<int, List<Node>>();
            foreach (var dir in dirs)
            {
                var node = GetNode(dir);
                if (dict.ContainsKey(node.Level - 1))
                {
                    var parent = dict[node.Level - 1][^1];
                    parent.children.Add(node);
                }
                if (!dict.ContainsKey(node.Level))
                    dict[node.Level] = new List<Node>();
                dict[node.Level].Add(node);
            }
            var res = 0;
            foreach (var root in dict[0])
                DFS(root, 0, ref res);
            return res;
        }

        private static void DFS(Node root, int len, ref int max)
        {
            if (root.IsFile)
                max = Math.Max(max, len + root.Value.Length);
            foreach (var child in root.children)
            {
                DFS(child, len + root.Value.Length + 1, ref max);
            }
        }

        public static Node GetNode(string dir)
        {
            int level = 0, index = 0;
            var isFile = false;
            while (index < dir.Length)
            {
                if (dir[index] == '\t')
                    level++;
                else if (dir[index] == '.')
                    isFile = true;
                index++;
            }
            return new Node(level, dir.Substring(level), isFile);
        }
    }
}
