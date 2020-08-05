using System;

namespace AddAndSearchWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class WordDictionary
    {
        class TrieNode
        {
            public TrieNode[] Children { get; set; }
            public bool IsWord { get; set; }
            public TrieNode()
            {
                Children = new TrieNode[26];
            }
        }
        private TrieNode root;
        public WordDictionary()
        {
            root = new TrieNode();
        }
        public void AddWord(String word)
        {
            var cur = root;
            foreach (var letter in word)
            {
                if(cur.Children[letter - 'a'] == null)
                    cur.Children[letter - 'a'] = new TrieNode();
                cur = cur.Children[letter - 'a'];
            }
            cur.IsWord = true;
        }
        public bool Search(String word)
        {
            return DFS(root, word, 0);
        }
        private bool DFS(TrieNode node, string word, int index)
        {
            if (node == null) return false;
            if (index == word.Length) return node.IsWord;
            if (word[index] == '.')
            {
                foreach (var child in node.Children)
                {
                    if (DFS(child, word, index + 1))
                        return true;
                }
                return false;
            }
            return DFS(node.Children[word[index] - 'a'], word, index + 1);
        }
    }
}
