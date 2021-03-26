using System;

namespace ImplementTrieII
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
        class TreeNode
        {
            public int count;
            public int end;
            public TreeNode[] children;

            public TreeNode()
            {
                children = new TreeNode[26];
            }
        }

        private TreeNode root;
        public Trie()
        {
            root = new TreeNode();
        }

        public void Insert(string word)
        {
            var point = root;
            foreach (var l in word)
            {
                if (point.children[l - 'a'] == null)
                    point.children[l - 'a'] = new TreeNode();
                point = point.children[l - 'a'];
                point.count++;
            }
            point.end++;
        }

        public int CountWordsEqualTo(string word)
        {
            var point = root;
            foreach (var l in word)
            {
                if (point.children[l - 'a'] == null)
                    return 0;
                point = point.children[l - 'a'];
            }
            return point.end;
        }

        public int CountWordsStartingWith(string prefix)
        {
            var count = 0;
            var point = root;
            foreach (var l in prefix)
            {
                if (point.children[l - 'a'] == null)
                    return 0;
                point = point.children[l - 'a'];
            }
            return point.count;
        }

        public void Erase(string word)
        {
            var point = root;
            foreach (var l in word)
            {
                point = point.children[l - 'a'];
                point.count--;
            }
            point.end--;
        }
    }
}
