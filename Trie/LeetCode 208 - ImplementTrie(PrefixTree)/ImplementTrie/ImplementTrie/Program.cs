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
        class Node
        {
            public bool IsWord { get; set; }
            public Node[] Children { get; set; }

            public Node()
            {
                Children = new Node[26];
            }
        }

        private Node root;

        public Trie()
        {
            root = new Node();
        }

        public void Insert(string word)
        {
            var point = root;
            foreach (var letter in word)
            {
                if (point.Children[letter - 'a'] == null)
                    point.Children[letter - 'a'] = new Node();
                point = point.Children[letter - 'a'];
            }
            point.IsWord = true;
        }

        public bool Search(string word)
        {
            var point = root;
            foreach (var letter in word)
            {
                if (point.Children[letter - 'a'] == null)
                    return false;
                point = point.Children[letter - 'a'];
            }
            return point.IsWord;
        }

        public bool StartsWith(string prefix)
        {
            var point = root;
            foreach (var letter in prefix)
            {
                if (point.Children[letter - 'a'] == null)
                    return false;
                point = point.Children[letter - 'a'];
            }
            return true;
        }
    }
}
