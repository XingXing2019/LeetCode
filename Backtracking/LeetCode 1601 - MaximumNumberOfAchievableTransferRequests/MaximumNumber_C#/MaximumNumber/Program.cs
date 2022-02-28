using System;
using System.Linq;

namespace MaximumNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[][] requests = new int[][]
            {
                new[] { 2, 1 },
                new[] { 0, 1 },
                new[] { 0, 1 },
            };
            Console.WriteLine(MaximumRequests(n, requests));
        }

        public static int MaximumRequests(int n, int[][] requests)
        {
            var res = 0;
            DFS(requests, 0, 0, 0, new int[n], ref res);
            return res;
        }

        public static void DFS(int[][] requests, int start, int count, int mask, int[] record, ref int res)
        {
            if (mask == 0 && record.All(x => x == 0))
                res = Math.Max(res, count);
            for (int i = start; i < requests.Length; i++)
            {
                record[requests[i][0]]--;
                record[requests[i][1]]++;
                DFS(requests, i + 1, count + 1, mask - (1 << requests[i][0]) + (1 << requests[i][1]), record, ref res);
                record[requests[i][0]]++;
                record[requests[i][1]]--;
            }
        }
    }
}
