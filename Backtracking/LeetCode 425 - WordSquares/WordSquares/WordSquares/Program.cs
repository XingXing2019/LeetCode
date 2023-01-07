using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSquares
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public IList<IList<string>> WordSquares(string[] words)
        {
            var res = new List<IList<string>>();
            DFS(words, new List<string>(), res);
            return res;
        }

        public void DFS(string[] words, List<string> combo, List<IList<string>> res)
        {
            if (combo.Count == words[0].Length)
            {
                res.Add(new List<string>(combo));
                return;
            }
            foreach (var word in words)
            {
                if (!IsValid(combo, word)) continue;
                combo.Add(word);
                DFS(words, combo, res);
                combo.RemoveAt(combo.Count - 1);
            }
        }

        public bool IsValid(List<string> combo, string word)
        {
            if (combo.Count == 0)
                return true;
            for (int i = 0; i < combo.Count; i++)
            {
                if (word[i] == combo[i][^(word.Length - combo.Count)]) continue;
                return false;
            }
            return true;
        }
    }
}
