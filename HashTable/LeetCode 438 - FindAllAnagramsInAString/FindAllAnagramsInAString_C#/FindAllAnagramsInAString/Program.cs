using System;
using System.Collections.Generic;

namespace FindAllAnagramsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "aa";
            string p = "bb";
            Console.WriteLine(FindAnagrams(s, p));
        }
        static IList<int> FindAnagrams(string s, string p)
        {
            List<int> res = new List<int>();
            if (s.Length < p.Length)
                return res;
            int[] sMap = new int[26];
            int[] pMap = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                sMap[s[i] - 'a']++;
                pMap[p[i] - 'a']++;
            }
            if(CheckSameArray(sMap, pMap))
                res.Add(0);
            for (int i = 1; i < s.Length - p.Length + 1; i++)
            {
                sMap[s[i - 1] - 'a']--;
                sMap[s[i + p.Length - 1] - 'a']++;
                if (CheckSameArray(sMap, pMap))
                    res.Add(i);
            }
            return res;
        }
        static bool CheckSameArray(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != arr2[i])
                    return false;
            return true;
        }
    }
}
