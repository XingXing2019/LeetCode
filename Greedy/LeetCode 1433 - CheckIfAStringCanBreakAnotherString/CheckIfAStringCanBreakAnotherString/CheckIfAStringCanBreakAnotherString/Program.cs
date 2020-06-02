using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CheckIfAStringCanBreakAnotherString
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "abe";
            string s2 = "acd";
            Console.WriteLine(CheckIfCanBreak(s1, s2));
        }
        static bool CheckIfCanBreak(string s1, string s2)
        {
            return CanBreak(s1, s2) || CanBreak(s2, s1);
        }

        static bool CanBreak(string s1, string s2)
        {
            var letters1 = new int[26];
            var letters2 = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                letters1[s1[i] - 'a']++;
                letters2[s2[i] - 'a']++;
            }
            for (int i = 0; i < 26; i++)
            {
                if(letters1[i] == 0)
                    continue;
                for (int j = i; j < 26; j++)
                {
                    while (letters2[j] > 0 && letters1[i] > 0)
                    {
                        letters1[i]--;
                        letters2[j]--;
                    }
                    if(letters1[i] == 0)
                        break;
                }
            }
            return letters1.All(x => x == 0);
        }
    }
}
