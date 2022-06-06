using System;
using System.Linq;
using System.Text;

namespace ShortestWayToFormString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int ShortestWay(string source, string target)
        {
            if (target.Any(x => !source.Contains(x))) return -1;
            var word = new StringBuilder();
            var res = 0;
            foreach (var l in target)
            {
                word.Append(l);
                if (IsSubsequence(source, word.ToString())) continue;
                res++;
                word = new StringBuilder(l.ToString());
            }
            if (IsSubsequence(source, word.ToString()))
                res++;
            return res;
        }

        public bool IsSubsequence(string source, string word)
        {
            int p1 = 0, p2 = 0;
            while (p1 < source.Length && p2 < word.Length)
            {
                if (source[p1] == word[p2])
                    p2++;
                p1++;
            }
            return p2 == word.Length;
        }
    }
}
