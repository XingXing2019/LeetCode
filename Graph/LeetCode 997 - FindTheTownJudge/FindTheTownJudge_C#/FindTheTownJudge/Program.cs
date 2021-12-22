using System;
using System.Collections.Generic;
using System.Linq;

namespace FindTheTownJudge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int FindJudge(int N, int[][] trust)
        {
            var dict = new Dictionary<int, HashSet<int>>();
            foreach (var pair in trust)
            {
                if (!dict.ContainsKey(pair[0]))
                    dict[pair[0]] = new HashSet<int> {pair[1]};
                else
                    dict[pair[0]].Add(pair[1]);
            }
            int judge = N * (1 + N) / 2;
            foreach (var kv in dict)
                judge -= kv.Key;
            foreach (var kv in dict)
                if (!kv.Value.Contains(judge))
                    return -1;
            return judge;
        }

        public int FindJudge1(int N, int[][] trust)
        {
            if (N == 1) return 1;
            var votes = new int[N + 1];
            foreach (var pair in trust)
            {
                votes[pair[0]]--;
                votes[pair[1]]++;
            }
            for (int i = 0; i < votes.Length; i++)
                if (votes[i] == N - 1)
                    return i;
            return -1;
        }
    }
}
