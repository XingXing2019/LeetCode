//创建一个TrieNode类，其中包含长度为26的TrieNode数组Children，代表其下一个字母的集合、布尔类型IsWord代表当前节点加上其祖先节点能否组成单词。
//添加单词时。创建一个current指针，一路将单词的所有字母添加进去。
//搜索单词时，创建current指针，一路搜索下去，最后看看IsWord时候为真。搜索途中如果遇到current为空，则证明无法继续搜索，则返回false。
//搜索前缀时，创建一个current指针。一路搜索下去，如果中途搜不下去，则返回false，否则搜索结束后返回true。
using System;

namespace ImplementTrie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Trie
    {
        private class TrieNode
        {
            public bool IsWord { get; set; }
            public TrieNode[] Children { get; set; }
            public TrieNode()
            {
                Children = new TrieNode[26];
            }
        }

        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            var current = root;
            foreach (var letter in word)
            {
                if (current.Children[letter - 'a'] == null)
                    current.Children[letter - 'a'] = new TrieNode();
                current = current.Children[letter - 'a'];
            }
            current.IsWord = true;
        }
        public bool Search(string word)
        {
            var current = root;
            foreach (var letter in word)
            {
                current = current.Children[letter - 'a'];
                if (current == null)
                    return false;
            }
            return current.IsWord;
        }
        public bool StartsWith(string prefix)
        {
            var current = root;
            foreach (var letter in prefix)
            {
                current = current.Children[letter - 'a'];
                if (current == null)
                    return false;
            }
            return true;
        }
    }
}
