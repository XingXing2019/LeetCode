using System;
using System.Collections.Generic;
using System.Text;

namespace FindResultantArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<string> RemoveAnagrams(string[] words)
        {
            var stack = new Stack<string[]>();
            for (int i = 0; i < words.Length; i++)
            {
                var code = Encode(words[i]);
                if (stack.Count == 0 || stack.Peek()[0] != code)
                    stack.Push(new []{code, i.ToString()});
            }
            var res = new List<string>();
            while (stack.Count != 0)
                res.Add(words[int.Parse(stack.Pop()[1])]);
            res.Reverse();
            return res;
        }

        public string Encode(string word)
        {
            var letters = new int[26];
            foreach (var letter in word)
                letters[letter - 'a']++;
            var res = new StringBuilder();
            for (int i = 0; i < letters.Length; i++)
                res.Append((char)(i + 'a') + letters[i]);
            return res.ToString();
        }
    }
}
