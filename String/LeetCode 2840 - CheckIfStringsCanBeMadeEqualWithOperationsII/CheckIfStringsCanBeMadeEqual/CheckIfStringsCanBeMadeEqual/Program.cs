using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIfStringsCanBeMadeEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s1 = "ublnlasppynwgx";
            var s2 = "ganplbuylnswpx";
            Console.WriteLine(CheckStrings(s1, s2));
        }

        public static bool CheckStrings(string s1, string s2)
        {
            var str1 = new StringBuilder(s1);
            var pos = new SortedSet<int>[26][];
            for (int i = 0; i < 26; i++)
                pos[i] = new[] {new SortedSet<int>(), new SortedSet<int>()};
            for (var i = 0; i < s1.Length; i++)
            {
                if (i % 2 == 0)
                    pos[s1[i] - 'a'][0].Add(i);
                else
                    pos[s1[i] - 'a'][1].Add(i);
            }
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == s2[i]) continue;
                var targets = i % 2 == 0 ? pos[s2[i] - 'a'][0] : pos[s2[i] - 'a'][1];
                while (targets.Count != 0 && targets.Min < i)
                    targets.Remove(targets.Min);
                if (targets.Count == 0) 
                    return false;
                var index = targets.Min;
                targets.Remove(index);
                if (i % 2 == 0)
                {
                    if (index > i)
                        pos[str1[i] - 'a'][0].Add(index);
                    pos[str1[i] - 'a'][0].Remove(i);
                }
                else
                {
                    if (index > i)
                        pos[str1[i] - 'a'][1].Add(index);
                    pos[str1[i] - 'a'][1].Remove(i);
                }
                (str1[i], str1[index]) = (str1[index], str1[i]);
            }
            return true;
        }
    }
}
