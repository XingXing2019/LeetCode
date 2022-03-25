using System;
using System.Collections.Generic;

namespace LexicographicalNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<int> LexicalOrder(int n)
        {
            var res = new List<int>();
            for (int i = 1; i <= 9; i++)
                DFS(n, i, res);
            return res;
        }

        public void DFS(int n, int num, List<int> res)
        {
            if (num > n) return;
            res.Add(num);
            for (int i = 0; i < 10; i++)
            {
                DFS(n, num * 10 + i, res);
            }
        }
    }
}
