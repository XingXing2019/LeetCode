using System;
using System.Collections.Generic;

namespace ReverseWordsInAStringII
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = {'t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e'};
            ReverseWords(s);
        }
        static void ReverseWords(char[] s)
        {
            var reversed = new char[s.Length];
            var spaceIndex = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == ' ')
                    spaceIndex.Add(i);
            }
            spaceIndex.Add(s.Length);
            int count = 0, index = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (i == spaceIndex[index])
                {
                    index++;
                    count = 0;
                    continue;
                }
                reversed[s.Length - spaceIndex[index] + count] = s[i];
                count++;
            }
            for (int i = 0; i < reversed.Length; i++)
                s[i] = reversed[i] == 0 ? ' ' : reversed[i];
        }
    }
}
