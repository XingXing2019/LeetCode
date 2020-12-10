using System;
using System.Collections.Generic;

namespace SmallestSubsequenceOfDistinctCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            //          01234
            var text = "bcbcbcababa";
            Console.WriteLine(SmallestSubsequence(text));
        }
        static string SmallestSubsequence(string s)
        {
            var record = new int[26];
            foreach (var letter in s)
                record[letter - 'a']++;
            var stack = new Stack<char>();
            foreach (var letter in s)
            {
                record[letter - 'a']--;
                if (stack.Contains(letter)) continue;
                while (stack.Count != 0 && letter < stack.Peek() && record[stack.Peek() - 'a'] > 0)
                    stack.Pop();
                stack.Push(letter);
            }
            var res = "";
            while (stack.Count != 0)
                res = stack.Pop() + res;
            return res;
        }
    }
}
