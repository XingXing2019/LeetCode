using System;
using System.Collections.Generic;

namespace CountUniqueCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int UniqueLetterString(string s)
        {
            var positions = new List<int>[26];
            for (int i = 0; i < 26; i++)
                positions[i] = new List<int> { -1 };
            for (int i = 0; i < s.Length; i++)
                positions[s[i] - 'A'].Add(i);
            for (int i = 0; i < 26; i++)
                positions[i].Add(s.Length);
            var res = 0;
            for (int i = 0; i < 26; i++)
            {
                var temp = positions[i];
                for (int j = 1; j < temp.Count - 1; j++)
                    res += (temp[j] - temp[j - 1]) * (temp[j + 1] - temp[j]);
            }
            return res;
        }
    }
}
