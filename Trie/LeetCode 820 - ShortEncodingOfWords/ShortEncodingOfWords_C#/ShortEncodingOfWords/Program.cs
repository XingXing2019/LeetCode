using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ShortEncodingOfWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "time", "me", "bell" };
            Console.WriteLine(MinimumLengthEncoding_Trie(words));
        }
        public int MinimumLengthEncoding(string[] words)
        {
            var remains = new HashSet<string>(words);
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length - 1; i++)
                {
                    var tempWord = word.Substring(word.Length - 1 - i);
                    if (remains.Contains(tempWord))
                        remains.Remove(tempWord);
                }
            }
            int res = remains.Count;
            foreach (var word in remains)
                res += word.Length;
            return res;
        }

        class TrieNode
        {
            public TrieNode[] children;
            public bool isWord;

            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }

        public static int MinimumLengthEncoding_Trie(string[] words)
        {
            var root = new TrieNode();
            words = words.OrderByDescending(x => x.Length).ToArray();
            var res = 0;
            foreach (var word in words)
            {
                var point = root;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    if (point.children[word[i] - 'a'] == null)
                        point.children[word[i] - 'a'] = new TrieNode();
                    point = point.children[word[i] - 'a'];
                    if (i != 0)
                        point.isWord = true;
                }
                if (!point.isWord)
                    res += word.Length + 1;
                point.isWord = true;
            }
            return res;
        }
    }
}
