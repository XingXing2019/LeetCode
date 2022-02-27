using System;
using System.ComponentModel.DataAnnotations;

namespace CountingWordsWithAGivenPrefix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class TrieNode
        {
            public TrieNode[] children;
            public int count;

            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }
        public int PrefixCount(string[] words, string pref)
        {
            var root = new TrieNode();
            foreach (var word in words)
            {
                var point = root;
                foreach (var letter in word)
                {
                    if (point.children[letter - 'a'] == null)
                        point.children[letter - 'a'] = new TrieNode();
                    point = point.children[letter - 'a'];
                    point.count++;
                }
            }
            foreach (var letter in pref)
            {
                if (root.children[letter - 'a'] == null)
                    return 0;
                root = root.children[letter - 'a'];
            }
            return root.count;
        }
    }
}
