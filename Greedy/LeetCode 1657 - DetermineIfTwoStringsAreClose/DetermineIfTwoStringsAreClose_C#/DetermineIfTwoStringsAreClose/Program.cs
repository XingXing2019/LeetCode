using System;
using System.Collections.Generic;
using System.Linq;

namespace DetermineIfTwoStringsAreClose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length) return false;
            var record1 = new int[26];
            var record2 = new int[26];
            for (int i = 0; i < word1.Length; i++)
            {
                record1[word1[i] - 'a']++;
                record2[word2[i] - 'a']++;
            }
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < record1.Length; i++)
            {
                if (record1[i] == 0 && record2[i] != 0 || record1[i] != 0 && record2[i] == 0)
                    return false;
                if (!dict.ContainsKey(record1[i]))
                    dict[record1[i]] = 0;
                dict[record1[i]]++;
                if (!dict.ContainsKey(record2[i]))
                    dict[record2[i]] = 0;
                dict[record2[i]]--;
            }
            return dict.All(x => x.Value == 0);
        }
    }
}
