using System;
using System.Collections.Generic;

namespace NumbersWithSameConsecutiveDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 4, K = 7;
            Console.WriteLine(NumsSameConsecDiff(N, K));
        }
        static int[] NumsSameConsecDiff(int N, int K)
        {
            var res = new List<int>();
            DFS(0, 0, N, K, 0, res);
            return res.ToArray();
        }

        static void DFS(int cur, int pre, int N, int K, int len, List<int> res)
        {
            if (len == N)
            {
                res.Add(cur);
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                if(len == 1 && pre == 0) continue;
                if(len > 0 && Math.Abs(i - pre) != K) continue;
                DFS(cur * 10 + i, i, N, K, len + 1, res);
            }
        }
    }
}
