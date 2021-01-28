using System;
using System.Collections.Generic;

namespace PalindromePartitioningIII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int PalindromePartition(string s, int k)
        {
            int min = int.MaxValue;
            DFS(s, new List<string>(), k, ref min);
            return min;
        }

        public void DFS(string remain, List<string> parts, int k, ref int min)
        {
            if(remain.Length < k - parts.Count) return;
            if (parts.Count == k)
            {
                if (remain.Length == 0)
                {
                    int sum = 0;
                    foreach (var part in parts)
                        sum += Count(part);
                    min = Math.Min(min, sum);
                }
                return;
            }
            for (int i = 0; i <= remain.Length; i++)
            {
                var part = remain.Substring(0, i);
                if(Count(part) >= min) continue;
                parts.Add(part);
                DFS(remain.Substring(i), parts, k, ref min);
                parts.RemoveAt(parts.Count - 1);
            }
        }

        public int Count(string s)
        {
            int count = 0, li = 0, hi = s.Length - 1;
            while (li < hi)
                if (s[li++] != s[hi--]) count++;
            return count;
        }
    }
}
