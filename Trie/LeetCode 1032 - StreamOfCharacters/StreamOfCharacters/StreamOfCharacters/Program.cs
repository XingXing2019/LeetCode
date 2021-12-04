using System;
using System.Text;

namespace StreamOfCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class StreamChecker
    {
        class TrieNode
        {
            public TrieNode[] children;
            public bool isWord;
            public TrieNode()
            {
                children = new TrieNode[26];
            }
        }

        private TrieNode root = new TrieNode();
        private StringBuilder str = new StringBuilder();
        public StreamChecker(string[] words)
        {
            foreach (var word in words)
            {
                var point = root;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    if (point.children[word[i] - 'a'] == null)
                        point.children[word[i] - 'a'] = new TrieNode();
                    point = point.children[word[i] - 'a'];
                }
                point.isWord = true;
            }
        }

        public bool Query(char letter)
        {
            str.Append(letter);
            var point = root;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (point.children[str[i] - 'a'] == null)
                    return false;
                point = point.children[str[i] - 'a'];
                if (point.isWord)
                    return true;
            }
            return false;
        }
    }

}
