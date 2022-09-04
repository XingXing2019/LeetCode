using System;
using System.Collections.Generic;

namespace CheckDistancesBetweenSameLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CheckDistances(string s, int[] distance)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                    dict[s[i]] = i;
                else
                    dict[s[i]] = i - dict[s[i]] - 1;
            }
            foreach (var l in dict.Keys)
            {
                if (dict[l] == distance[l - 'a']) continue;
                return false;
            }
            return true;
        }
    }
}
