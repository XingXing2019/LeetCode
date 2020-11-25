using System;
using System.Collections.Generic;
using System.Text;

namespace TheKthLexicographicalString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1, k = 3;
            Console.WriteLine(GetHappyString(n, k));
        }

        static string GetHappyString(int n, int k)
        {
            var words = new List<string>();
            DFS(n, k, new[] { 'a', 'b', 'c' }, new StringBuilder(), words);
            return k <= words.Count ? words[k - 1] : "";
        }

        static void DFS(int n, int k, char[] letters, StringBuilder str, List<string> words)
        {
            if(words.Count == k) return;
            if (str.Length == n)
            {
                words.Add(str.ToString());
                return;
            }
            for (int i = 0; i < letters.Length; i++)
            {
                if (str.Length == 0 || letters[i] != str[^1])
                {
                    str.Append(letters[i]);
                    DFS(n, k, letters, str, words);
                    str.Remove(str.Length - 1, 1);
                }
            }
        }
    }
}
