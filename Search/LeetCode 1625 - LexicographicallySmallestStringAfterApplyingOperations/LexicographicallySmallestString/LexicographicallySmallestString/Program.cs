using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LexicographicallySmallestString
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "5525";
            int a = 9, b = 2;
            Console.WriteLine(FindLexSmallestString(s, a, b));
        }
        static string FindLexSmallestString(string s, int a, int b)
        {
            var visit = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(s);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                var add = Add(cur, a);
                if(visit.Add(add))
                    queue.Enqueue(add);
                var rotate = Rotate(cur, b);
                if(visit.Add(rotate))
                    queue.Enqueue(rotate);
            }
            var order = visit.OrderBy(x => x).ToList();
            return order[0];
        }

        static string Add(string s, int a)
        {
            var str = new StringBuilder(s);
            for (int i = 1; i < str.Length; i+=2)
            {
                var digit = str[i] - '0';
                digit = (digit + a) % 10;
                str[i] = (char) (digit + '0');
            }
            return str.ToString();
        }

        static string Rotate(string s, int b) => 
            s.Substring(s.Length - b, b) + s.Substring(0, s.Length - b);
    }
}
