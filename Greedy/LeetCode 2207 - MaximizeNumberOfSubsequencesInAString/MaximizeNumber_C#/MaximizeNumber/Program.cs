
using System;
using System.Linq;

namespace MaximizeNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public long MaximumSubsequenceCount(string text, string pattern)
        {
            if (pattern[0] == pattern[1])
            {
                long count = text.Count(x => x == pattern[0]);
                return (1 + count) * count / 2;
            }
            int first = 0, second = 0;
            long addFirst = 0, addSecond = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == pattern[0])
                    first++;
                else if (text[i] == pattern[1])
                    addSecond += first;
                if (text[^(i + 1)] == pattern[1])
                    second++;
                else if (text[^(i + 1)] == pattern[0])
                    addFirst += second;
            }
            return Math.Max(addFirst + first, addSecond + second);
        }
    }
}
