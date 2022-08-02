using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderlyQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string OrderlyQueue(string s, int k)
        {
            if (k > 1)
                return string.Join("", s.OrderBy(x => x));
            var visited = new HashSet<string>();
            var res = s;
            while (visited.Add(s))
            {
                s = s.Substring(1) + s[0];
                if (s.CompareTo(res) < 0)
                    res = s;
            }
            return res;
        }
    }
}
