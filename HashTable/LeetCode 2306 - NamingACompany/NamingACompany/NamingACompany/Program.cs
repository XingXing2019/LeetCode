using System;
using System.Collections.Generic;
using System.Linq;

namespace NamingACompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] ideas = { "coffee", "donuts", "time", "toffee" };
            Console.WriteLine(DistinctNames(ideas));
        }

        public static long DistinctNames(string[] ideas)
        {
            var prefixDict = new HashSet<string>[26];
            long res = 0;
            foreach (var idea in ideas)
            {
                var prefix = idea[0];
                var suffix = idea.Substring(1);
                prefixDict[prefix - 'a'] ??= new HashSet<string>();
                prefixDict[prefix - 'a'].Add(suffix);
            }
            for (int i = 0; i < 26; i++)
            {
                for (int j = i + 1; j < 26; j++)
                {
                    res += 2 * Count(prefixDict[i], prefixDict[j]);
                }
            }
            return res;
        }

        public static long Count(HashSet<string> prefixes1, HashSet<string> prefixes2)
        {
            if (prefixes1 == null || prefixes2 == null) return 0;
            var common = prefixes1.Count(prefixes2.Contains);
            return (prefixes1.Count - common) * (prefixes2.Count - common);
        }
    }
}
