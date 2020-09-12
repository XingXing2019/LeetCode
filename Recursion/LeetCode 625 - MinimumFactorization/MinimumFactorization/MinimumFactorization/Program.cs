using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumFactorization
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 134217728;
            Console.WriteLine(SmallestFactorization(a));
        }
        static int SmallestFactorization(int a)
        {
            if (a < 10) return a;
            var res = long.MaxValue;
            DFS(a, 0, ref res);
            return res == long.MaxValue || res > int.MaxValue ? 0 : (int)res;
        }

        static void DFS(int a, long num, ref long res)
        {
            if (a == 1)
            {
                res = Math.Min(res, num);
                return;
            }
            for (int i = 2; i < 10; i++)
            {
                if (a % i == 0 && num < int.MaxValue)
                    DFS(a / i, num * 10 + i, ref res);
            }
        }
    }
}
