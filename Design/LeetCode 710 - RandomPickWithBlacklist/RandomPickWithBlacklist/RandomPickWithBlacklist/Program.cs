using System;
using System.Collections.Generic;

namespace RandomPickWithBlacklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            int[] blackList = { 0, 1 };
            var s = new Solution(n, blackList);
        }
    }

    public class Solution
    {
        private Dictionary<int, int> dict;
        private Random random;
        private int len;
        public Solution(int n, int[] blacklist)
        {
            random = new Random();
            dict = new Dictionary<int, int>();
            len = n - blacklist.Length;
            var surplus = new List<int>();
            for (int i = len; i < n; i++)
                surplus.Add(i);
            var banned = new HashSet<int>(blacklist);
            Array.Sort(blacklist);
            var index = 0;
            foreach (var num in surplus)
            {
                if (banned.Contains(num)) continue;
                while (index < blacklist.Length && blacklist[index] >= len)
                    index++;
                dict[blacklist[index++]] = num;
            }
        }

        public int Pick()
        {
            var index = random.Next(len);
            return dict.ContainsKey(index) ? dict[index] : index;
        }
    }
}
