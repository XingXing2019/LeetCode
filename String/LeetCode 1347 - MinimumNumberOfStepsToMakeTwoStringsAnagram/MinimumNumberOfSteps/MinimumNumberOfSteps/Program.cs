using System;
using System.Linq;

namespace MinimumNumberOfSteps
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "anagram";
            string t = "mangaar";
            Console.WriteLine(MinSteps(s, t));
        }
        static int MinSteps(string s, string t)
        {
            int[] mapS = new int[26];
            int[] mapT = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                mapS[s[i] - 'a']++;
                mapT[t[i] - 'a']++;
            }
            for (int i = 0; i < mapS.Length; i++)
            {
                if (mapS[i] != 0 && mapT[i] != 0)
                {
                    if (mapS[i] > mapT[i])
                    {
                        mapS[i] = mapS[i] - mapT[i];
                        mapT[i] = 0;
                    }
                    else
                    {
                        mapT[i] = mapT[i] - mapS[i];
                        mapS[i] = 0;
                    }
                }
            }
            int res = mapS.Where(x => x != 0).Sum(x => x);
            return res;
        }
    }
}
