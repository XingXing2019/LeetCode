using System;

namespace MinimumAdditionsToMakeValidString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int AddMinimum(string word)
        {
            int last = -1, res = 0;
            foreach (var l in word)
            {
                var cur = l - 'a';
                res += cur > last ? cur - last - 1 : cur + 3 - last - 1;
                last = cur;
            }
            return res + (2 - last);
        }
    }
}
