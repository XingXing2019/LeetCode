using System;
using System.Collections.Generic;
using System.Text;

namespace CheckIfStringsCanBeMadeEqual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CheckStrings(string s1, string s2)
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
                if (targets.Count == 0) 
                    return false;
                var index = targets.Min;
                targets.Remove(index);
                if (i % 2 == 0)
                {
                    pos[str1[i] - 'a'][0].Remove(i);
                    pos[str1[i] - 'a'][0].Add(index);
                }
                else
                {
                    pos[str1[i] - 'a'][1].Remove(i);
                    pos[str1[i] - 'a'][1].Add(index);
                }
                (str1[i], str1[index]) = (str1[index], str1[i]);
            }
            return true;
        }
    }
}
