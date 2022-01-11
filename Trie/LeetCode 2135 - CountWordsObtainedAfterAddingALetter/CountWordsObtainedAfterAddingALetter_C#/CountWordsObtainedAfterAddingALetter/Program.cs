using System;
using System.Collections.Generic;
using System.Linq;

namespace CountWordsObtainedAfterAddingALetter
{
    internal class Program
    {
        public class TrieNode
        {
            public TrieNode[] children;
            public bool isWord;
            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }
        static void Main(string[] args)
        {
            string[] startWords = { "bt", "zc" }, targetWords = { "zcb" };
            Console.WriteLine(WordCount(startWords, targetWords));
        }

        public static int WordCount(string[] startWords, string[] targetWords)
        {
            var dict = new Dictionary<int, TrieNode>();
            var res = 0;
            foreach (var start in startWords)
            {
                if (!dict.ContainsKey(start.Length))
                    dict[start.Length] = new TrieNode();
                var point = dict[start.Length];
                Insert(point, start);
            }
            foreach (var target in targetWords)
            {
                if (!dict.ContainsKey(target.Length - 1)) continue;
                var point = dict[target.Length - 1];
                for (int i = 0; i <= target.Length - 1; i++)
                {
                    var word = target.Substring(0, i) + target.Substring(i + 1);
                    if (!Check(point, word)) continue;
                    res++;
                    break;
                }
            }
            return res;
        }

        public static void Insert(TrieNode point, string word)
        {
            var letters = new int[26];
            foreach (var letter in word)
                letters[letter - 'a']++;
            for (int i = 0; i < 26; i++)
            {
                if (letters[i] == 0) continue;
                if (point.children[i] == null)
                    point.children[i] = new TrieNode();
                point = point.children[i];
            }
            point.isWord = true;
        }

        public static bool Check(TrieNode point, string word)
        {
            var letters = new int[26];
            foreach (var letter in word)
                letters[letter - 'a']++;
            for (int i = 0; i < 26; i++)
            {
                if (letters[i] == 0) continue;
                if (point.children[i] == null)
                    return false;
                point = point.children[i];
            }
            return point.isWord;
        }
    }
}
