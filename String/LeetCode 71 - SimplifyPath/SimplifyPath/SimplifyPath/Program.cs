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
            var paths = path.Split("/", StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>();
            foreach (var p in paths)
            {
                if(p == ".")
                    continue;
                if (p != "..")
                    stack.Push(p);
                else if (stack.Count != 0)
                    stack.Pop();
            }
            if (stack.Count == 0)
                return "/";
            var res = "";
            foreach (var str in stack)
                res = "/" + str + res;
            return res;
        }
    }
}
