using System;
using System.Collections.Generic;

namespace RingsAndRods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int CountPoints(string rings)
        {
            var record = new int[10];
            var color = new Dictionary<char, int> { { 'R', 1 }, { 'G', 2 }, { 'B', 4 } };
            for (int i = 0; i < rings.Length; i+=2)
            {
                var num = color[rings[i]];
                record[rings[i + 1] - '0'] |= num;
            }
            var res = 0;
            foreach (var r in record)
            {
                if (r == 7)
                    res++;
            }
            return res;
        }
    }
}
