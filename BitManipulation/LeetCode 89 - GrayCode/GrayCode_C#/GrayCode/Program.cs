using System;
using System.Collections.Generic;

namespace GrayCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static IList<int> GrayCode(int n)
        {
            var res = new List<int>();
            for (int i = 0; i < Math.Pow(2, n); i++)
                res.Add((i >> 1) ^ i);
            return res;
        }
    }
}
